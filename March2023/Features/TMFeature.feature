Feature: TMFeature

As a TurnUp portal admin
I would like to create and edit Time and Material records
So that I can manage Employees' Time and Material successfully
 

Scenario: 1 Create time and material records with valid details
	Given I am logged in to TurnUp portal
	When I navigate to Time and Material page
	And Create a new Time and Material record
	Then New record should be created successfully

Scenario Outline: 2 Edit Time and Material record
	Given I am logged in to TurnUp portal
	When I navigate to Time and Material page
	And Update the '<description>', '<code>' and '<price>' on existing record
	Then the record should show updated '<description>', '<code>' and '<price>'

	Examples: 
		| description | code   | price |
		| desc1       | codea  | $10.00|
		| desc2       | codeb  | $20.00|
		| desc3       | codec  | $30.00|

Scenario Outline: 3 Delete the record
	Given I am logged in to TurnUp portal
	When I navigate to Time and Material page
	And Delete the record
	Then The record should be deleted successfully 

Feature: EventCreation
	In order to create meaningful events 
	As a writer
	I want to be able to open a event creation form to set all the items

Background: 
	Given I have created a test database called "eventCreation"	
	And I create the following places
		| name       | history  |
		| testPlace  | history1 |
		| testPlace2 | history1 |
	And I create the following characters
		| name | backstory | race | sex    | place     |
		| jim  | none      | foot | rarley | somewhere |
		| jim2 | none      | foot | rarley | somewhere |
		| jim3 | none      | foot | rarley | somewhere |
		| jim4 | none      | foot | rarley | somewhere |

Scenario: Open Event creation 
	Given I open the view "EventSequencer"
	When I click open Event Creation
	Then I expect to get the "EventCreation" view

Scenario: Open event creation - verify supporting data is correct
	When I open the view "EventCreation"
	Then I expect event creation to have the following places 
	| name       |
	| testPlace  |
	| testPlace2 |
	And I expect event creation to ahve the following characters available
	| name |
	| jim  |
	| jim2 |
	| jim3 |
	| jim4 |

Scenario: Create an event
	Given I open the view "EventCreator"
	When I create the following event
	| name      | Description                          | Outcomes           |  Places               | Duration | Characters | Event Type |
	| testEvent | a test event to show how things work | passed, failed, war|  testPlace,testPlace2 | 3        | jim,jim3   | story      |
	Then I expect the following events to exist
	| name      | Description                          | Outcomes            | Places               | Duration | Characters | Event Type |
	| testEvent | a test event to show how things work | passed, failed, war | testPlace,testPlace2 | 3        | jim,jim3   | story      |

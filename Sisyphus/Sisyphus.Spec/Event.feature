Feature: Event
	In order to describe the structure of a story and tie together interactions of groups of characters
	As a writer
	I want to be able to create events

@mytag
Scenario: Create an event
	Given I have created a test database called "eventsTest"
	And I create the following places
	| name       | history  |
	| testPlace  | history1 |
	| testPlace2 | history1 |
	When I create the sollowing events
	| name      | Description                          | Outcomes            | Places               |
	| testEvent | a test event to show how things work | passed, failed, war | testPlace,testPlace2 |
	Then I expect the following events to exist
	| name      | Description                          | Outcomes            | Places               |
	| testEvent | a test event to show how things work | passed, failed, war | testPlace,testPlace2 |

Scenario: Add a character to an event
	Given I have created a test database called "eventsTest"
	And I create the following places
	| name       | history  |
	| testPlace  | history1 |
	| testPlace2 | history1 |
	And I create the following characters
	| name | backstory    | race | sex   | place     |
	| jim  | is some dude | last | kinda | testPlace |
	And I create the sollowing events
	| name      | Description                          | Outcomes            | Places               |
	| testEvent | a test event to show how things work | passed, failed, war | testPlace,testPlace2 |
	When I add the following characters to the event "testEvent"
	| name |
	| jim  |
	Then I expect the event "testEvent" to contain the following characters
	| name |
	| jim  |
	



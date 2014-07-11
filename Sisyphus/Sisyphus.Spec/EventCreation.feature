Feature: EventCreation
	In order to create meaningful events 
	As a writer
	I want to be able to open a event creation form to set all the items

Background: 
	Given I have set up configuration to use testConfig
	And I have created a test database called "eventCreation"	
	And I create the following places
		| name       | history  |
		| testPlace  | history1 |
		| testPlace2 | history1 |
	And I create the following characters
		| name | backstory | race | sex    |
		| jim  | none      | foot | rarley |
		| jim2 | none      | foot | rarley |
		| jim3 | none      | foot | rarley |
		| jim4 | none      | foot | rarley |

Scenario: Open Event creation 
	When I click create event in the event sequencer
	Then The resulting RedirectToRouteResult should be to controller "Event" action "Create"

Scenario: open event creation - verify the viewmodel
	When I call create on Event controller
	Then  I expect event creation to have the following places 
		| name       |
		| testPlace  |
		| testPlace2 |
	And I expect event creation to have the following characters available
		| name |
		| jim  |
		| jim2 |
		| jim3 |
		| jim4 |

Scenario: Create an event
	When I create the following events
		| name      | Description                          | Outcomes           |  Places               | Duration | Characters | Event Type |
		| testEvent | a test event to show how things work | passed, failed, war|  testPlace,testPlace2 | 3        | jim,jim3   | story      |
	Then I expect the following events to exist
		| name      | Description                          | Outcomes            | Places               | Duration | Characters | Event Type |
		| testEvent | a test event to show how things work | passed, failed, war | testPlace,testPlace2 | 3        | jim,jim3   | story      |

Scenario: Click edit Event - require viewmodel to contain list of all places and characters 
	Given I create the following events
		| name      | Description                          | Outcomes           |  Places               | Duration | Characters | Event Type |
		| testEvent | a test event to show how things work | passed, failed, war|  testPlace,testPlace2 | 3        | jim,jim3   | story      |
	When I edit the Event "testEvent"
	Then I expect event event editor to have the following places
		| name       |
		| testPlace  |
		| testPlace2 |
	And I expect the event editor to have the following characters
		| name |
		| jim  |
		| jim2 |
		| jim3 |
		| jim4 |


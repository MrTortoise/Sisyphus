Feature: EventCreation
	In order to create meaningful events 
	As a writer
	I want to be able to open a event creation form to set all the items

Background: 
	Given I have set up configuration to use testConfig
	And I set the config key "SessionTimeout" to "15"
	And I set ContextWrapper To use TestContextWrapper 
	And I set the user Identity to "writer@admin.com"
	And I have set SisyphusDateTime to TestDateTime
	And I have set the date to year "2014" Month "7" Day "20" hour "19" minute "24" second "12" millisecond "123"
	And I have created a test database called "eventCreation"	
	And I create a user with email "writer@admin.com" with password "testtest"
	And I assign the following roles to user "writer@admin.com"
		| role   |
		| Admin  |
		| Writer |
		| Reader |
	And I log in with the user "writer@admin.com" and password "testtest"
	And I use the controller WriterHome
	And I have created the stories
		| name  | backStory                      |
		| test1 | ooo itS BACK STORY             |
		| test2 | COR HE THINKS ITS A WEAL STOWY |
	And I select the story "test1"
	And I create the following places
		| name       | history  |
		| testPlace  | history1 |
		| testPlace2 | history2 |
	And I create the following races
		| name | backstory        |
		| foot | bulling you rleg |
	And I create the following sexes
		| name     | description |
		| rarley   | nto often   |
		| bannanas | yellowZ     |
	And I create the following characters
		| name | backstory | race | sex      | place     |
		| jim  | none      | foot | rarley   | somewhere |
		| jim2 | none      | foot | bannanas | somewhere |
		| jim3 | none      | foot | rarley   | somewhere |
		| jim4 | none      | foot | bannanas | somewhere |

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
	Given I create the following events
		| name      | Description                          | Outcomes            | Places               | Duration | Characters | Event Type | 
		| testEvent | a test event to show how things work | passed, failed, war | testPlace,testPlace2 | 3        | jim,jim3   | Story      | 
	When I open the event controller
	Then I expec the eventIndexViewModel to contain the following events
		| name      | Description                          | Outcomes            | Places               | Duration | Characters | Event Type |
		| testEvent | a test event to show how things work | passed, failed, war | testPlace,testPlace2 | 3        | jim,jim3   | Story      |
	Then I expect the following events to exist
		| name      | Description                          | Outcomes            | Places               | Duration | Characters | Event Type |
		| testEvent | a test event to show how things work | passed, failed, war | testPlace,testPlace2 | 3        | jim,jim3   | Story      |

Scenario: Click edit Event - require viewmodel to contain list of all places and characters 
	Given I create the following events
		| name      | Description                          | Outcomes           |  Places               | Duration | Characters | Event Type |
		| testEvent | a test event to show how things work | passed, failed, war|  testPlace,testPlace2 | 3        | jim,jim3   | Story      |
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
	And I expect the event editor to have the following Event selected
		| name      | Description                          | Outcomes            | Places               | Duration | Characters | Event Type |
		| testEvent | a test event to show how things work | passed, failed, war | testPlace,testPlace2 | 3        | jim,jim3   | Story      |

Scenario: Click view event details in the list of events
	Given I create the following events
		| name      | Description                          | Outcomes           |  Places               | Duration | Characters | Event Type |
		| testEvent | a test event to show how things work | passed, failed, war|  testPlace,testPlace2 | 3        | jim,jim3   | Story      |
	When I click view event details for event "testEvent"
	Then I expect to see the following event in Event Details
		| name      | Description                          | Outcomes           |  Places               | Duration | Characters | Event Type |
		| testEvent | a test event to show how things work | passed, failed, war|  testPlace,testPlace2 | 3        | jim,jim3   | Story      |

Scenario: click delete event in index expect to get delete event view
	Given I create the following events
		| name      | Description                          | Outcomes           |  Places               | Duration | Characters | Event Type |
		| testEvent | a test event to show how things work | passed, failed, war|  testPlace,testPlace2 | 3        | jim,jim3   | Story      |
	When I click delete event "testEvent" in Index
	Then I expect the delete event view to have the following event selected
		| name      | Description                          | Outcomes           |  Places               | Duration | Characters | Event Type |
		| testEvent | a test event to show how things work | passed, failed, war|  testPlace,testPlace2 | 3        | jim,jim3   | Story      |

Scenario: Delete an event
	Given I create the following events
		| name       | Description                          | Outcomes            | Places               | Duration | Characters | Event Type | 
		| testEvent  | a test event to show how things work | passed, failed, war | testPlace,testPlace2 | 3        | jim,jim3   | Story      | 
		| testEvent2 | a test event to show how things work | passed              | testPlace            | 3        | jim        | Story      | 
	When I delete event "testEvent"
	Then I expect the following events to exist
		| name       | Description                          | Outcomes | Places    | Duration | Characters | Event Type |
		| testEvent2 | a test event to show how things work | passed   | testPlace | 3        | jim        | Story      |
	And I expect the event called "testEvent" to not exist


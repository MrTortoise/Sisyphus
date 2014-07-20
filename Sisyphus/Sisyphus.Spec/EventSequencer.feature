Feature: EventSequencer
	In order to tell a story in terms of sequences of events
	As a writer
	I want to be able to create and chain together events 
	I also want to be able to opent hem in the EventEditor

Background: 
	Given I have set up configuration to use testConfig
	And I set the config key "SessionTimeout" to "15"
	And I set ContextWrapper To use TestContextWrapper 
	And I set the user Identity to "writer@admin.com"
	And I have set SisyphusDateTime to TestDateTime
	And I have set the date to year "2014" Month "7" Day "20" hour "19" minute "24" second "12" millisecond "123"
	And I have created a test database called "eventsTest"	
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
	And I create the following events
		| name       | Description                          | Outcomes            | Places    | Duration | Characters | Event Type |
		| testEvent  | a test event to show how things work |                     | testPlace | 3        | jim,jim3   | story      |
		| testEvent2 | a test event to show how things work |                     | testPlace | 3        | jim,jim4   | story      |
		| testEvent3 | decision event                       | passed, failed, war | testPlace | 3        | jim,jim4   | decision   |
		| testEvent4 | decision event                       | passed, failed, war | testPlace | 3        | jim,jim4   | decision   |

Scenario: Open the event sequencer before anything has been chained should have start node and all events available for selection
	When I open the Event Sequencer Index
	Then I expect the Sequence nodes to contain
		|Name|

Scenario: Open event sequencer and select an event
	Given I open the view "EventSequencer"
	When I select the event "testEvent"
	Then I expect the event sequencer to have the event "testEvent" selected

Scenario: Open the event editor with the correct event
	Given I open the view "EventSequencer"
	And I select the event "testEvent"
	When I click open EventEditor
	Then I expect to get the "EventEditor" view
	And I expect the event editor to have the event "testEvent" selected

Scenario: Select a story event and choose to chain another story event from it
	Given I open the view "EventSequencer"
	And I select the event "testEvent"
	When I select the event "testEvent2" to chain and click chain event
	Then I expect the event "testEvent2" to be chained from event "testEvent"

Scenario: Select a decision event, choose an outcome and assign a story event to it
	Given I open the view "EventSequencer"
	And I select the event "testEvent3"
	When I select the outcome "passed", story event "testEvent" and click chain
	Then I expect the event "TestEvent" to be chained from the event "testEvent3"

Scenario: Fail to chain a decision event to a decision event
	Given I open the view "EventSequencer"
	And I select the event "testEvent3"
	Then I expect an exception when I select the outcome "passed", story event "testEvent4" and click chain






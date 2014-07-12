Feature: WriterIndex
	In order to navigate writer features
	As a writer
	I want to have a list of avaialble tools

Background: 
	Given I have set up configuration to use testConfig
	And I set the config key "SessionTimeout" to "15"
	And I set ContextWrapper To use TestContextWrapper 
	And I set the user Identity to "writer@admin.com"
	And I have set SisyphusDateTime to TestDateTime
	And I have set the date to year "2014" Month "7" Day "20" hour "19" minute "24" second "12" millisecond "123"
	And I have created a test database called "writerTest"
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

Scenario: Expect to see any previously created stories
	Then I expect the WriterHome controller to have the following stories available
	| name  | backStory                      |
	| test1 | ooo itS BACK STORY             |
	| test2 | COR HE THINKS ITS A WEAL STOWY |

Scenario: Select a story verify that that story is the active story
	When I select the story "test1"
	Then I expect the active story to be "test1"	
	

Scenario: Navigate to places page
	When I click open PlacesEditor on the writer index	
	Then The resulting RedirectToRouteResult should be to controller "Place" action "Index"

Scenario: Navigate to chracter Browser 
	When I click open Character browser on the writer index
	Then The resulting RedirectToRouteResult should be to controller "CharacterBrowser" action "Index"

Scenario: Navigate to the Time editor
	When I click open Time editor on the writer index
	Then The resulting RedirectToRouteResult should be to controller "Time" action "Index"

Scenario: Navigate to the Event Sequencer
	When I click open event sequencer on the writer index
	Then The resulting RedirectToRouteResult should be to controller "EventSequencer" action "Index"

Scenario: Navigate to the Race Sequencer
	When I click open race editor on the writer index
	Then The resulting RedirectToRouteResult should be to controller "Race" action "Index"

Scenario: Navigate to the Sex Editor
	When I click open sex editor on the writer index
	Then The resulting RedirectToRouteResult should be to controller "Sex" action "Index"
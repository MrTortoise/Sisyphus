Feature: WriterIndex
	In order to navigate writer features
	As a writer
	I want to have a list of avaialble tools

Background: 
	Given I have set up configuration to use testConfig
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
	Then The resulting RedirectToRouteResult should be to controller "PlacesEditor" action "Index"

Scenario: Navigate to chracter Browser 
	When I click open Character browser on the writer index
	Then The resulting RedirectToRouteResult should be to controller "CharacterBrowser" action "Index"

Scenario: Navigate to the Time editor
	When I click open Time editor on the writer index
	Then The resulting RedirectToRouteResult should be to controller "Time" action "Index"

Scenario: Navigate to the Event Sequencer
	When I click open event sequencer on the writer index
	Then The resulting RedirectToRouteResult should be to controller "EventSequencer" action "Index"
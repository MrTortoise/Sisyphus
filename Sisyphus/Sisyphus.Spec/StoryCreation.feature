Feature: StoryCreation
	In have a story
	As a writer
	I want to be able to create and initialise a story

	Background: 
	Given I have set up configuration to use testConfig
	And I set the config key "SessionTimeout" to "15"
	And I set ContextWrapper To use TestContextWrapper 
	And I set the user Identity to "writer@admin.com"
	And I have set SisyphusDateTime to TestDateTime
	And I have set the date to year "2014" Month "7" Day "20" hour "19" minute "24" second "12" millisecond "123"
	And I have created a test database called "storyCreation"	
	And I create a user with email "writer@admin.com" with password "testtest"
	And I assign the following roles to user "writer@admin.com"
		| role   |
		| Admin  |
		| Writer |
		| Reader |
	And I log in with the user "writer@admin.com" and password "testtest"
	And I use the controller WriterHome

Scenario: Create a story and verify its initialisation state
	When I have created the stories
		| name  | backStory          |
		| test1 | ooo itS BACK STORY |
	And I select the story "test1"
	Then I expect the following events to exist
		| name        | Description | Outcomes | Places | Duration | Characters | Event Type | Story |
		| Story Start | Story Start |          |        | 0        |            | StoryStart | test1 |

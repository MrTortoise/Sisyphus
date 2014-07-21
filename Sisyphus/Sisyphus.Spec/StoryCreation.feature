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

Scenario: Create some stories and verify they are in the index
	Given I have created the stories
		| name  | backStory          |
		| test1 | ooo itS BACK STORY |
		| test2 | ooo itS BACK STORY |
		| test3 | ooo itS BACK STORY |
	When I open the story controller index
	Then I expect the following stories to exist
		| name  | backStory          |
		| test1 | ooo itS BACK STORY |
		| test2 | ooo itS BACK STORY |
		| test3 | ooo itS BACK STORY |

Scenario: view a stories details
	Given I have created the stories
		| name  | backStory          |
		| test1 | ooo itS BACK STORY |
		| test2 | ooo itS BACK STORY |
		| test3 | ooo itS BACK STORY |
	When I view details of the story "test1"
	Then I expect the story in details to be called "test1" and its backstory to be "ooo itS BACK STORY"

Scenario: Select a story to edit
	Given I have created the stories
		| name  | backStory          |
		| test1 | ooo itS BACK STORY |
		| test2 | ooo itS BACK STORY |
		| test3 | ooo itS BACK STORY |
	When I click edit story "test1"
	Then I expect the story editor to have story "test1" with backstory "ooo itS BACK STORY" to be selected

Scenario: Edit a story, save it and verify it has changed
	Given I have created the stories
		| name  | backStory          |
		| test1 | ooo itS BACK STORY |
		| test2 | ooo itS BACK STORY |
		| test3 | ooo itS BACK STORY |
	And I click edit story "test1"
	When I set the story name to "edited" and the backstory to "edited" and save the edit
	And I open the story controller index
	Then I expect the following stories to exist
		| name   | backStory |
		| edited | edited    |

#Scenario: Select a story to delete
#	Given I have created the stories
#		| name  | backStory          |
#		| test1 | ooo itS BACK STORY |
#		| test2 | ooo itS BACK STORY |
#		| test3 | ooo itS BACK STORY |
#	When I click delete story "test1"
#	Then I expect the story deleter to have story "test1" with backstory "ooo itS BACK STORY" to be selected

#Scenario: Delete a story and verify that it no longer exists
#	Given I have created the stories
#		| name  | backStory          |
#		| test1 | ooo itS BACK STORY |
#		| test2 | ooo itS BACK STORY |
#		| test3 | ooo itS BACK STORY |
#	And I click delete story "test1"
#	When I delete the selected story
#	And I open the story controller index
#	Then I expect the followign stories to not exist
#		| name  | backStory          |
#		| test1 | ooo itS BACK STORY |


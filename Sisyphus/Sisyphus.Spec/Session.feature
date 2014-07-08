Feature: Session
	In order to remember what story we are on 
	as a writer
	I need to manage sessions

Background: 
	Given I have set up configuration to use testConfig
	And I have created a test database called "adminTest"
	And I create a user with email "adminfeature@admin.com" with password "testtest"
	And I log in with the user "adminfeature@admin.com" and password "testtest"
	And I have created the stories
	| name  | backStory                      |
	| test1 | ooo itS BACK STORY             |
	| test2 | COR HE THINKS ITS A WEAL STOWY |

@mytag
Scenario: Create a session
	When I create a session for user "adminfeature@admin.com" on story "test1"
	Then I expect the current session for user "adminfeature@admin.com" to be for story "test1"

Scenario: Create a session, wait 10 seconds and varify that 

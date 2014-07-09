Feature: Session
	In order to remember what story we are on 
	as a writer
	I need to manage sessions

Background: 
	Given I have set up configuration to use testConfig
	And I set the config key "SessionTimeout" to "15"
	And I have set SisyphusDateTime to TestDateTime
	And I have set the date to year "2014" Month "7" Day "20" hour "19" minute "24" second "12" millisecond "123"
	And I have created a test database called "sessionTest"
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

Scenario: Create a session, wait 16 mins get session and verify that its a new session
Given I create a session for user "adminfeature@admin.com" on story "test1"
When I increment THe datetime by year "0" month "0" day "0" hour "0" minute "16" second "0" millisecond "0"
And I get the current session for user "adminfeature@admin.com"
Then i expect the second session to be diferent from the first.


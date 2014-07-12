Feature: Places
	In order to have locations characters can interact in
	As a writer
	I want to be to manipulate places

Background: 
	Given I have set up configuration to use testConfig
	And I set the config key "SessionTimeout" to "15"
	And I set ContextWrapper To use TestContextWrapper 
	And I set the user Identity to "writer@admin.com"
	And I have set SisyphusDateTime to TestDateTime
	And I have set the date to year "2014" Month "7" Day "20" hour "19" minute "24" second "12" millisecond "123"
	And I have created a test database called "placesTest"	
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

@mytag
Scenario: Create a new place with a name and history
	When I create a place called "test1" with history "history1"
	Then I expect places to contain
	| name  | history  |
	| test1 | history1 |

Scenario: Create several places and return them
	When I create the following places
	| name  | history  |
	| test1 | history1 |
	| test2 | history2 |
	| test3 | history3 |
	| test4 | history4 |
	Then I expect places to contain
    | name  | history  |
    | test1 | history1 |
    | test2 | history2 |
    | test3 | history3 |
    | test4 | history4 |

Scenario: Create a list of places and return a page
	Given I create the following places
	| name  | history  |
	| test1 | history1 |
	| test2 | history2 |
	| test3 | history3 |
	| test4 | history4 |
	| test5 | history5 |
	| test6 | history6 |
	| test7 | history7 |
	| test8 | history8 |
	When I get 3 places skipping 3 and store them
	Then I expect the stored places to contain the following
	| name  | history  |
	| test4 | history4 |
	| test5 | history5 |
	| test6 | history6 |




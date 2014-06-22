Feature: Places
	In order to have locations characters can interact in
	As a writer
	I want to be to manipulate places

Background: 
	Given I have set up configuration to use testConfig

@mytag
Scenario: Create a new place with a name and history
	Given I have created a test database called "placesTest"	
	When I create a place called "test1" with history "history1"
	Then I expect places to contain
	| name  | history  |
	| test1 | history1 |

Scenario: Create several places and return them
	Given I have created a test database called "placesTest"
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
	Given I have created a test database called "placesTest"
	And I create the following places
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




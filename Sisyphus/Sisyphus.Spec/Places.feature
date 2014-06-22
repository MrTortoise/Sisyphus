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

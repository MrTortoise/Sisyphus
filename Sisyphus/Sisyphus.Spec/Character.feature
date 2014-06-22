Feature: Character
	In order to have a story there needs to be characters interacting
	As a writer
	I want to be able to create and make characters interact

Scenario: Create a Character with a back story
	Given I have created a test database called "characterTest"	
	When I create the following characters
	| name | backstory    | race | sex   | 
	| jim  | is some dude | last | kinda | 
	Then I expect the following characters to exist
	| name | backstory    | race | sex   |
	| jim  | is some dude | last | kinda |	

Scenario: Move a character to a location
	Given I have created a test database called "characterTest"	
	And I havecreated the following places
	| name       | history |
	| testPlace  | noneZ   |
	| testplace2 | noneZ   |
	And I create the following characters
	| name | backstory    | race | sex   | place     |
	| jim  | is some dude | last | kinda | testPlace |
	When I move a character to place "testplace2" in time 
	| bit | bitvalue |
	| 0   | 1        |
	And I wait for time
	| bit | bitvalue |
	| 0   | 2        |
	Then I expect character "jim" to be at place "testplace2"

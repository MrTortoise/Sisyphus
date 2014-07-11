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
	When I create a journey for character to place "testplace2" in time called "journey1" with description "a test journey"
	| bit | bitvalue |
	| 0   | 1        |
	And I wait for a time period         
	| bit | bitvalue |
	| 0   | 2        |
	Then I expect character "jim" to be at place "testplace2"

Scenario: Take a character moving to a location and split journey into 2
	Given I have created a test database called "characterTest"	
	And I havecreated the following places
	| name       | history |
	| testPlace  | noneZ   |
	| testplace2 | noneZ   |
	| testplace3 | noneZ   |
	And I create a time system with the following members
	| bit | bitValue | bitText |
	| 0   | 0        | 0       |
	| 0   | 1        | 1       |
	| 0   | 2        | 2       |
	| 0   | 3        | 3       |
	| 0   | 4        | 4       |
	| 0   | 5        | 5       |	
	And I set the time to
	| bit | bitvalue |
	| 0   | 0        |
	And I create the following characters
	| name | backstory    | race | sex   |
	| jim  | is some dude | last | kinda |
	And I create a journey for character to place "testplace2" in time called "journey1" with description "a test journey"
	| bit | bitvalue |
	| 0   | 5        |
	When I split journey "journey1" at time into "journey1" description "first part" and "journey2" description "second part"
	| bit | bitvalue |
	| 0   | 2        |
	Then I expect character "jim" to have the following journeys
	| name     | startTime | duration | description |
	| journey1 | 0         | 2        | first part  |
	| journey2 | 2         | 3        | second part |

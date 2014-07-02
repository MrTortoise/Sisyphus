﻿Feature: Event
	In order to describe the structure of a story and tie together interactions of groups of characters
	As a writer
	I want to be able to edit events and add dialogue/narrative to them

Background: 
	Given I have created a test database called "eventsTest"
	And I create the following places
	| name       | history  |
	| testPlace  | history1 |
	| testPlace2 | history1 |
	And I create the following characters
	| name | backstory    | race | sex   | place     |
	| jim  | is some dude | last | kinda | testPlace |
	| jim2 | is some dude | last | kinda | testPlace |
	And I create the following events
	| name      | Description                          | Outcomes            | Places               |Duration |
	| testEvent | a test event to show how things work | passed, failed, war | testPlace,testPlace2 |3        |	

Scenario: Add a character to an event
	Given I select the Event "testEvent" in the EventSequencer
	When I open the view "EventEditor" with event "testEvent"
	And I add the following characters to the event "testEvent"
	| name |
	| jim  |
	Then I expect the event "testEvent" to contain the following characters
	| name |
	| jim  |

Scenario: Remove a character to an event
	Given I select the Event "testEvent" in the EventSequencer
	When I open the view "EventEditor" with event "testEvent"
	And I add the following characters to the event "testEvent"
	| name |
	| jim  |
	| jim2 |
	And I remove the following characters from the event "testEvent"
	| name |
	| jim  |
	Then I expect the event "testEvent" to contain the following characters
	| name |
	| jim2  |

Scenario: Add dialogue to an event
	Given I create the following characters
	| name | backstory    | race | sex   | place     |
	| jim  | is some dude | last | kinda | testPlace |
	And I open the view "EventEditor"
	And I create the following events
	| name      | Description                          | Outcomes            | Places               |Duration |
	| testEvent | a test event to show how things work | passed, failed, war | testPlace,testPlace2 |3        |
	And I add the following characters to the event "testEvent"
	| name |
	| jim  |	
	When I add to the event "testEvent" from perspective of "jim" the following lines of dialogue 
	| eventStepId | dialog |
	| 0           |look its some story |
	Then I expect "jim" to have the following story
	| eventStepId | story lines |
	| 0           | Jim says "Its awfully lonley in this scenario"|

Scenario: Add dialogue to an event with multiple characters (dialogue is shared (objective))
	Given 
	And I open the view "EventEditor"
	And I create the following events
	| name      | Description                          | Outcomes            | Places               |Duration |
	| testEvent | a test event to show how things work | passed, failed, war | testPlace,testPlace2 |3        |
	And I add the following characters to the event "testEvent"
	| name |
	| jim  |
	| jim2 |	
	When I add to the event "testEvent" from perspective of "jim" the following lines of dialogue 
	| eventStepId | dialog |
	| 0           | Jim says "Its awfully lonley in this scenario" |
	Then I expect "jim" to have the following story
	| eventStepId | story lines |
	| 0           |Jim says "Its awfully lonley in this scenario"|
	And I expect "jim2" to have the following story
	| eventStepId | story lines |
	| 0           | Jim says "Its awfully lonley in this scenario"|

Scenario: Add Narrative to an event
	Given I create the following characters
	| name | backstory    | race | sex   | place     |
	| jim  | is some dude | last | kinda | testPlace |
	And I open the view "EventEditor"
	And I create the following events
	| name      | Description                          | Outcomes            | Places               |Duration |
	| testEvent | a test event to show how things work | passed, failed, war | testPlace,testPlace2 |3        |
	And I add the following characters to the event "testEvent"
	| name |
	| jim  |	
	When I add to the event "testEvent" from perspective of "jim" the following Narrative
	| eventStepId | narrative |
	| 0           |look its some story |
	Then I expect "jim" to have the following story
	| eventStepId | story lines |
	| 0           | look its some story |

Scenario: Add Narrative to an event with 2 chars - but only 1 narrative (so both get that narrative as a convinience)
	Given I create the following characters
	| name | backstory    | race | sex   | place     |
	| jim  | is some dude | last | kinda | testPlace |
	| jim2 | is some dude | last | kinda | testPlace |
	And I open the view "EventEditor"
	And I create the following events
	| name      | Description                          | Outcomes            | Places               |Duration |
	| testEvent | a test event to show how things work | passed, failed, war | testPlace,testPlace2 |3        |
	And I add the following characters to the event "testEvent"
	| name |
	| jim  |
	| jim2 |
	When I add to the event "testEvent" from perspective of "jim" the following Narrative 
	| eventStepId | narrative |
	| 0           |look its some story |
	Then I expect "jim" to have the following story
	| eventStepId | story lines |
	| 0           | look its some story |
	And I expect "jim" to have the following story
	| eventStepId | story lines |
	| 0           | look its some story |

Scenario: Add narative and dialogue to an event with 2 chars - sequence test
	Given I create the following characters
	| name | backstory    | race | sex   | place     |
	| jim  | is some dude | last | kinda | testPlace |
	| jim2 | is some dude | last | kinda | testPlace |
	And I open the view "EventEditor"
	And I create the following events
	| name      | Description                          | Outcomes            | Places               |Duration |
	| testEvent | a test event to show how things work | passed, failed, war | testPlace,testPlace2 |3        |
	And I add the following characters to the event "testEvent"
	| name |
	| jim  |
	| jim2 |
	When I add to the event "testEvent" from perspective of "jim" the following Narrative 
	| eventStepId | narrative           |
	| 0           | look its some story |
	And I add to the event "testEvent" from perspective of "jim" the following lines of dialogue 
	| eventStepId | dialog                                         |
	| 1           | Jim says "Its awfully lonley in this scenario" |
	And I add to the event "testEvent" from perspective of "jim" the following Narrative 
	| eventStepId | narrative                |
	| 2           | look its some more story |
	Then I expect "jim" to have the following story
	| eventStepId | story lines                                    |
	| 0           | look its some story                            |
	| 1           | Jim says "Its awfully lonley in this scenario" |
	| 2           | look its some more story                       |
	And I expect "jim2" to have the following story
	| eventStepId | story lines                                    |
	| 0           | look its some story                            |
	| 1           | Jim says "Its awfully lonley in this scenario" |
	| 2           | look its some more story                       |

Scenario: 2 characters shared dialog but unique narrative for both
	Given I create the following characters
	| name | backstory    | race | sex   | place     |
	| jim  | is some dude | last | kinda | testPlace |
	| jim2 | is some dude | last | kinda | testPlace |
	And I open the view "EventEditor"
	And I create the following events
	| name      | Description                          | Outcomes            | Places               |Duration |
	| testEvent | a test event to show how things work | passed, failed, war | testPlace,testPlace2 |3        |
	And I add the following characters to the event "testEvent"
	| name |
	| jim  |
	| jim2 |
	When I add to the event "testEvent" from perspective of "jim" the following Narrative 
	| eventStepId | narrative |
	| 0           | look its some story |
	And I add to the event "testEvent" from perspective of "jim2" the following Narrative 
	| eventStepId | narrative |
	| 1           | look its some other story |
	And I add to the event "testEvent" from perspective of "jim" the following lines of dialogue 
	| eventStepId | dialog                                         |
	| 2           | Jim says "Its awfully lonley in this scenario" |
	And I add to the event "testEvent" from perspective of "jim" the following Narrative 
	| eventStepId | narrative                |
	| 3           | look its some more story |
	Then I expect "jim" to have the following story
	| eventStepId | story lines                                    |
	| 0           | look its some story                            |
	| 2           | Jim says "Its awfully lonley in this scenario" |
	| 3           | look its some more story                       |
	And I expect "jim2" to have the following story
	| eventStepId | story lines                                    |
	| 1           | look its some other story                      |
	| 2           | Jim says "Its awfully lonley in this scenario" |

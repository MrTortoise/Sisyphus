Feature: Event
	In order to describe the structure of a story and tie together interactions of groups of characters
	As a writer
	I want to be able to edit events and add dialogue/narrative to them

Background: 
	Given I have set up configuration to use testConfig
	And I set the config key "SessionTimeout" to "15"
	And I set ContextWrapper To use TestContextWrapper 
	And I set the user Identity to "writer@admin.com"
	And I have set SisyphusDateTime to TestDateTime
	And I have set the date to year "2014" Month "7" Day "20" hour "19" minute "24" second "12" millisecond "123"
	And I have created a test database called "eventCreation"	
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
	And I create the following places
		| name       | history  |
		| testPlace  | history1 |
		| testPlace2 | history2 |
	And I create the following races
		| name | backstory        |
		| foot | bulling you rleg |
	And I create the following sexes
		| name     | description |
		| rarley   | nto often   |
		| bannanas | yellowZ     |
	And I create the following characters
		| name | backstory | race | sex      | place     |
		| jim  | none      | foot | rarley   | somewhere |
		| jim2 | none      | foot | bannanas | somewhere |
		| jim3 | none      | foot | rarley   | somewhere |
		| jim4 | none      | foot | bannanas | somewhere |
	And I create the following events
		| name      | Description                          | Outcomes            | Duration |
		| testEvent | a test event to show how things work | passed, failed, war | 3        |
	And I add the following characters to the event "testEvent"
		| name |
		| jim  |
		| jim3 |

Scenario: Add dialogue to an event
	When I add to the event "testEvent" from perspective of "jim" the following lines of dialogue 
	| eventStepIndex | dialog                                         |
	| 0           | Jim says "Its awfully lonley in this scenario" |
	Then I expect "jim" to have the following story for the event "testEvent"
	| eventStepIndex | story lines                                    |
	| 0           | Jim says "Its awfully lonley in this scenario" |

Scenario: Add dialogue to an event with multiple characters (dialogue is shared (objective))
	When I add to the event "testEvent" from perspective of "jim" the following lines of dialogue 
	| eventStepIndex | dialog                                         |
	| 0              | Jim says "Its awfully lonley in this scenario" |
	Then I expect "jim" to have the following story for event "testEvent"
	| eventStepIndex | story lines                                    |
	| 0              | Jim says "Its awfully lonley in this scenario" |
	And I expect "jim3" to have the following story for event "testEvent"
	| eventStepIndex | story lines                                    |
	| 0              | Jim says "Its awfully lonley in this scenario" |

Scenario: Add Narrative to an event
	When I add to the event "testEvent" from perspective of "jim" the following Narrative
	| eventStepIndex | narrative           |
	| 0              | look its some story |
	Then I expect "jim" to have the following story for event "testEvent"
	| eventStepIndex | story lines         |
	| 0              | look its some story |

Scenario: Add Narrative to an event with 2 chars - but only 1 narrative (so both get that narrative as a convinience)
	When I add to the event "testEvent" from perspective of "jim" the following Narrative 
	| eventStepIndex | narrative           |
	| 0              | look its some story |
	Then I expect "jim" to have the following story for event "testEvent"
	| eventStepIndex | story lines         |
	| 0              | look its some story |
	And I expect "jim3" to have the following story for event "testEvent"
	| eventStepIndex | story lines         |
	| 0              | look its some story |

Scenario: Add narative and dialogue to an event with 2 chars - sequence test
	When I add to the event "testEvent" from perspective of "jim" the following Narrative 
	| eventStepIndex | narrative           |
	| 0              | look its some story |
	And I add to the event "testEvent" from perspective of "jim" the following lines of dialogue 
	| eventStepIndex | dialog                                         |
	| 1              | Jim says "Its awfully lonley in this scenario" |
	And I add to the event "testEvent" from perspective of "jim" the following Narrative 
	| eventStepIndex | narrative                |
	| 2              | look its some more story |
	Then I expect "jim" to have the following story for event "testEvent"
	| eventStepIndex | story lines                                    |
	| 0              | look its some story                            |
	| 1              | Jim says "Its awfully lonley in this scenario" |
	| 2              | look its some more story                       |
	And I expect "jim3" to have the following story for event "testEvent"
	| eventStepIndex | story lines                                    |
	| 0              | look its some story                            |
	| 1              | Jim says "Its awfully lonley in this scenario" |
	| 2              | look its some more story                       |

Scenario: 2 characters shared dialog but unique narrative for both
	When I add to the event "testEvent" from perspective of "jim" the following Narrative 
	| eventStepIndex | narrative |
	| 0           | look its some story |
	And I add to the event "testEvent" from perspective of "jim3" the following Narrative 
	| eventStepIndex | narrative |
	| 1           | look its some other story |
	And I add to the event "testEvent" from perspective of "jim" the following lines of dialogue 
	| eventStepIndex | dialog                                         |
	| 2           | Jim says "Its awfully lonley in this scenario" |
	And I add to the event "testEvent" from perspective of "jim" the following Narrative 
	| eventStepIndex | narrative                |
	| 3           | look its some more story |
	Then I expect "jim" to have the following story for event "testEvent"
	| eventStepIndex | story lines                                    |
	| 0           | look its some story                            |
	| 2           | Jim says "Its awfully lonley in this scenario" |
	| 3           | look its some more story                       |
	And I expect "jim3" to have the following story for event "testEvent"
	| eventStepIndex | story lines                                    |
	| 1           | look its some other story                      |
	| 2           | Jim says "Its awfully lonley in this scenario" |


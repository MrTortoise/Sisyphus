Feature: EventSequencer
	In order to tell a story in terms of sequences of events
	As a writer
	I want to be able to chain together events

@mytag
Scenario: Add two numbers
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen

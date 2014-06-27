 Feature: Player
	In order to record decisions, and track progress
	As a player
	I want to be bale to record progress

Scenario: Create a player
	Given I have created a test database called "playerTest"	
	Given I have created player instance
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen

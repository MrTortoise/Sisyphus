 Feature: Player
	In order to record decisions, and track progress
	As a player
	I want to be bale to record progress

Background: 
	Given I have set up configuration to use testConfig
	And I have created a test database called "playerTest"
	And I create a user with email "adminfeature@admin.com" with password "testtest"

Scenario: Create a player
	
	Given I remove all player instances for user "adminfeature@admin.com"
	When I have created the following player instances
	| user                   | instance |
	| adminfeature@admin.com | test     |
	Then I expect the current time value to be
		 | bit | bitvalue |
		 | 0   | 0        |



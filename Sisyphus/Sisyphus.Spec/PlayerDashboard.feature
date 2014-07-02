Feature: PlayerDashboard
	In order to go back and follow on old stories and curent ones
	As a reader
	I want to a dashboard so i can list my previous adventurings

Background: 
	Given I have set up configuration to use testConfig
	And I have created a test database called "adminTest"
	And I create a user with email "adminfeature@admin.com" with password "testtest"

@mytag
Scenario: Log in and be presented with the dashboard
	Given  have created the following player instances
	| user                   | instance |
	| adminfeature@admin.com | test     |
	| adminfeature@admin.com | test2    |
	| adminfeature@admin.com | test2    |
	And I open the view "Login"
	When I click open PLayerDashboard
	Then I expect the list of instances to include
	| instances |
	| test      |
	| test2     |
	| test3     |

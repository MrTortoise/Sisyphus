﻿Feature: WriterIndex
	In order to navigate writer features
	As a writer
	I want to have a list of avaialble tools

Background: 
	Given I have set up configuration to use testConfig
	And I have created a test database called "writerTest"
	And I create a user with email "writer@admin.com" with password "testtest"
	And I assign the following roles to user "writer@admin.com"
		| role   |
		| Admin  |
		| Writer |
		| Reader |
	And I log in with the user "writer@admin.com" and password "testtest"
	And I use the controller WriterHome

Scenario: Navigate to places page
	When I click open PlacesEditor	
	Then The resulting Action result should be PlacesEditorIndex

Scenario: Navigate to chracter Browser 
	When I click open Character browser on the Places Editor
	Then The resulting Action result should be CharacterBrowserIndex

Scenario: Navigate to the Time editor
	When I click open Time editor on the places editor
	Then The resulting Action result should be TimeEditor

Scenario: Navigate to the Event Sequencer
	When I click open event sequencer on the places controller
	Then The resulting Action result shuold be TimeEditor
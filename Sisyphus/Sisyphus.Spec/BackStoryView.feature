Feature: BackStoryView
	In order to decide how and where i want to start the story from
	As a consumer
	I want to be able to disseminate the back story

Background: 
	Given I have created a test database called "backstoryTest"	
	And I have set the world narrative to "this is the world backstory"

Scenario: Browse the narrative of the world
	Given I have chosen to start a story 
	Then I expect the BAckStoryView to have the narrative "this is the world backstory"

Scenario: Open the character browser from the BAck story view
	Given I have chosen to start a story  
	When I click open Character browser
	Then I expect to get the "CharacterBrowser" view







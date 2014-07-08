Feature: ContextWrapper
	In order to test controllers that depend on principal in httpcontext
	As a haxor
	I want to abstract away from it to simple classes

Background: 
	Given I set ContextWrapper To use TestContextWrapper 

Scenario: Set logged in user and return it	
	When I set the user Identity to "fred"
	Then I expect the logged in user to be "fred"

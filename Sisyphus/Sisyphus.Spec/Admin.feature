Feature: Admin
	In order to manage player accounts
	As an admin
	I want to be an admin

	Background: 
	Given I have set up configuration to use testConfig
	And I have created a test database called "adminTest"
	And I create a user with email "adminfeature@admin.com" with password "testtest"

Scenario: Create a user
	Then I expect the user "adminfeature@admin.com" to exist
	And I log in with the user "adminfeature@admin.com" and password "testtest"

Scenario: View user list
	When I get the user list
	Then I expect the followign users to be in the user list
	| name                   |
	| adminfeature@admin.com |

Scenario: I need to view all roles so i can assign one ot a user
	When I get the role list
	Then I expect there to be the following roles
	| role   |
	| Reader |
	| Writer |
	| Admin  |

Scenario: Assign roles to user
	When I assign the following roles to user "adminfeature@admin.com"
		| role   |
		| Admin  |
		| Writer |
		| Reader |
	Then I expect the user "adminfeature@admin.com" to have the following roles
		| role   |
		| Admin  |
		| Writer |
		| Reader |

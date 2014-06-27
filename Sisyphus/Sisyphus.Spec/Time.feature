Feature: Time
	In order to have events happen 
	As a being in time
	I need for the term happen to have context

Background: 
	Given I have created a test database called "timeTest"		
	And I have created player instance

Scenario: Create a single digit time system 	
	Given I create a time system with the following members
		| bit | bitValue | bitText |
		| 0   | 0        | 0       |
		| 0   | 1        | 1       |
		| 0   | 2        | 2       |
		| 0   | 3        | 3       |
		| 0   | 4        | 4       |
		| 0   | 5        | 5       |	
	When I set the time to 
		| bit | bitvalue |
		| 0   | 2        |
	Then I expect the current time value to be 
		| bit | bitvalue |
		| 0   | 2        |

Scenario: Create a single digit time system with named members and return value by name
	Given I have created a test database called "timeTest"		
	And I create a time system with the following members
		| bit | bitValue | bitText |
		| 0   | 0        | zeroth  |
		| 0   | 1        | first   |
		| 0   | 2        | second  |
		| 0   | 3        | third   |
		| 1   | 0        | Zenith  |
		| 1   | 1        | summit  |  
	When I set the time to "first,zenith"
	Then I expect the current time value to be 
		| bit | bitvalue |
		| 0   | 1        |
		| 1   | 0        |

	Scenario: Create a single digit time system with named members and return name by value
	Given I have created a test database called "timeTest"		
	And I create a time system with the following members
		| bit | bitValue | bitText |
		| 0   | 0        | zeroth  |
		| 0   | 1        | first   |
		| 0   | 2        | second  |
		| 0   | 3        | third   |
		| 1   | 0        | Zenith  |
		| 1   | 1        | summit  |  
	When I set the time to 
		| bit | bitvalue |
		| 0   | 1        |
		| 1   | 0        |
	Then The current time should be "first, Zenith"

	Scenario: Create a time system, wait for a period and ensure time is correct
	Given I have created a test database called "timeTest"		
	And I create a time system with the following members
		| bit | bitValue | bitText |
		| 0   | 0        | zeroth  |
		| 0   | 1        | first   |
		| 1   | 0        | zennith |
		| 1   | 1        | shlart  |
		| 2   | 0        | barty   |
		| 2   | 1        | fooity  |
	And I set the time to
		| bit | bitvalue |
		| 0   | 0        |
		| 1   | 0        |
		| 2   | 0        |
	When I wait for a time period
		| bit | bitvalue |
		| 0   | 5        |
	Then I expect the current time value to be 
		| bit | bitvalue |
		| 2   | 0        |

Feature: DateTime
	In order to manipulate time for testing
	As a haxor
	I want to be able to return and set datetiem to whatever i like

Background: 
	Given I have set SisyphusDateTime to TestDateTime

Scenario: Set DateTime and return it
	When I have set the date to year "2014" Month "7" Day "20" hour "19" minute "24" second "12" millisecond "123"
	Then I expect the date to be year "2014" Month "7" Day "20" hour "19" minute "24" second "12" millisecond "123"

Scenario: Set date time, increment it and return it
	Given I have set the date to year "2014" Month "7" Day "20" hour "19" minute "24" second "12" millisecond "123"
	When I increment THe datetime by year "1" month "-1" day "1" hour "1" minute "-1" second "1" millisecond "1"
	Then I expect the date to be year "2015" Month "6" Day "21" hour "20" minute "23" second "13" millisecond "124"

	

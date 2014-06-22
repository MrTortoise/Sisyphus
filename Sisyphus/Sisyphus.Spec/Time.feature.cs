﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.18444
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Sisyphus.Spec
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Time")]
    public partial class TimeFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Time.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Time", "In order to have events happen \r\nAs a being in time\r\nI need for the term happen t" +
                    "o have context", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create a single digit time system")]
        public virtual void CreateASingleDigitTimeSystem()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create a single digit time system", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.Given("I have created a test database called \"timeTest\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "bit",
                        "bitValue",
                        "bitText"});
            table1.AddRow(new string[] {
                        "0",
                        "0",
                        "0"});
            table1.AddRow(new string[] {
                        "0",
                        "1",
                        "1"});
            table1.AddRow(new string[] {
                        "0",
                        "2",
                        "2"});
            table1.AddRow(new string[] {
                        "0",
                        "3",
                        "3"});
            table1.AddRow(new string[] {
                        "0",
                        "4",
                        "4"});
            table1.AddRow(new string[] {
                        "0",
                        "5",
                        "5"});
#line 8
 testRunner.And("I create a time system with the following members", ((string)(null)), table1, "And ");
#line 16
 testRunner.When("I set the time to \"0,2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "bit",
                        "bitvalue"});
            table2.AddRow(new string[] {
                        "0",
                        "2"});
#line 17
 testRunner.Then("I expect the current time value to be", ((string)(null)), table2, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create a single digit time system with named members and return value by name")]
        public virtual void CreateASingleDigitTimeSystemWithNamedMembersAndReturnValueByName()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create a single digit time system with named members and return value by name", ((string[])(null)));
#line 21
this.ScenarioSetup(scenarioInfo);
#line 22
 testRunner.Given("I have created a test database called \"timeTest\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "bit",
                        "bitValue",
                        "bitText"});
            table3.AddRow(new string[] {
                        "0",
                        "0",
                        "zeroth"});
            table3.AddRow(new string[] {
                        "0",
                        "1",
                        "first"});
            table3.AddRow(new string[] {
                        "0",
                        "2",
                        "second"});
            table3.AddRow(new string[] {
                        "0",
                        "3",
                        "third"});
            table3.AddRow(new string[] {
                        "1",
                        "0",
                        "Zenith"});
            table3.AddRow(new string[] {
                        "1",
                        "1",
                        "summit"});
#line 23
 testRunner.And("I create a time system with the following members", ((string)(null)), table3, "And ");
#line 31
 testRunner.When("I set the time to \"first,zenith\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "bit",
                        "bitvalue"});
            table4.AddRow(new string[] {
                        "0",
                        "1"});
            table4.AddRow(new string[] {
                        "1",
                        "0"});
#line 32
 testRunner.Then("I expect the current time value to be", ((string)(null)), table4, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create a single digit time system with named members and return name by value")]
        public virtual void CreateASingleDigitTimeSystemWithNamedMembersAndReturnNameByValue()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create a single digit time system with named members and return name by value", ((string[])(null)));
#line 37
 this.ScenarioSetup(scenarioInfo);
#line 38
 testRunner.Given("I have created a test database called \"timeTest\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "bit",
                        "bitValue",
                        "bitText"});
            table5.AddRow(new string[] {
                        "0",
                        "0",
                        "zeroth"});
            table5.AddRow(new string[] {
                        "0",
                        "1",
                        "first"});
            table5.AddRow(new string[] {
                        "0",
                        "2",
                        "second"});
            table5.AddRow(new string[] {
                        "0",
                        "3",
                        "third"});
            table5.AddRow(new string[] {
                        "1",
                        "0",
                        "Zenith"});
            table5.AddRow(new string[] {
                        "1",
                        "1",
                        "summit"});
#line 39
 testRunner.And("I create a time system with the following members", ((string)(null)), table5, "And ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "bit",
                        "bitvalue"});
            table6.AddRow(new string[] {
                        "0",
                        "1"});
            table6.AddRow(new string[] {
                        "1",
                        "0"});
#line 47
 testRunner.When("I set the time to", ((string)(null)), table6, "When ");
#line 51
 testRunner.Then("The current time should be \"first, Zenith\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create a time system, wait for a period and ensure time is correct")]
        public virtual void CreateATimeSystemWaitForAPeriodAndEnsureTimeIsCorrect()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create a time system, wait for a period and ensure time is correct", ((string[])(null)));
#line 53
 this.ScenarioSetup(scenarioInfo);
#line 54
 testRunner.Given("I have created a test database called \"timeTest\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "bit",
                        "bitValue",
                        "bitText"});
            table7.AddRow(new string[] {
                        "0",
                        "0",
                        "zeroth"});
            table7.AddRow(new string[] {
                        "0",
                        "1",
                        "first"});
            table7.AddRow(new string[] {
                        "1",
                        "0",
                        "zennith"});
            table7.AddRow(new string[] {
                        "1",
                        "1",
                        "shlart"});
            table7.AddRow(new string[] {
                        "2",
                        "0",
                        "barty"});
            table7.AddRow(new string[] {
                        "2",
                        "1",
                        "fooity"});
#line 55
 testRunner.And("I create a time system with the following members", ((string)(null)), table7, "And ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "bit",
                        "bitvalue"});
            table8.AddRow(new string[] {
                        "0",
                        "0"});
            table8.AddRow(new string[] {
                        "1",
                        "0"});
            table8.AddRow(new string[] {
                        "2",
                        "0"});
#line 63
 testRunner.And("I set the time to", ((string)(null)), table8, "And ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "bit",
                        "bitvalue"});
            table9.AddRow(new string[] {
                        "0",
                        "5"});
#line 68
 testRunner.When("I wait for a tiem period", ((string)(null)), table9, "When ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "bit",
                        "bitvalue"});
            table10.AddRow(new string[] {
                        "2",
                        "0"});
#line 71
 testRunner.Then("I expect the current time value to be", ((string)(null)), table10, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion

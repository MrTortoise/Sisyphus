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
        
        public virtual void FeatureBackground()
        {
#line 6
#line 7
 testRunner.Given("I have created a test database called \"timeTest\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.And("I have created player instance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create a single digit time system")]
        public virtual void CreateASingleDigitTimeSystem()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create a single digit time system", ((string[])(null)));
#line 10
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
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
#line 11
 testRunner.Given("I create a time system with the following members", ((string)(null)), table1, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "bit",
                        "bitvalue"});
            table2.AddRow(new string[] {
                        "0",
                        "2"});
#line 19
 testRunner.When("I set the time to", ((string)(null)), table2, "When ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "bit",
                        "bitvalue"});
            table3.AddRow(new string[] {
                        "0",
                        "2"});
#line 22
 testRunner.Then("I expect the current time value to be", ((string)(null)), table3, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create a single digit time system with named members and return value by name")]
        public virtual void CreateASingleDigitTimeSystemWithNamedMembersAndReturnValueByName()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create a single digit time system with named members and return value by name", ((string[])(null)));
#line 26
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 27
 testRunner.Given("I have created a test database called \"timeTest\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "bit",
                        "bitValue",
                        "bitText"});
            table4.AddRow(new string[] {
                        "0",
                        "0",
                        "zeroth"});
            table4.AddRow(new string[] {
                        "0",
                        "1",
                        "first"});
            table4.AddRow(new string[] {
                        "0",
                        "2",
                        "second"});
            table4.AddRow(new string[] {
                        "0",
                        "3",
                        "third"});
            table4.AddRow(new string[] {
                        "1",
                        "0",
                        "Zenith"});
            table4.AddRow(new string[] {
                        "1",
                        "1",
                        "summit"});
#line 28
 testRunner.And("I create a time system with the following members", ((string)(null)), table4, "And ");
#line 36
 testRunner.When("I set the time to \"first,zenith\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "bit",
                        "bitvalue"});
            table5.AddRow(new string[] {
                        "0",
                        "1"});
            table5.AddRow(new string[] {
                        "1",
                        "0"});
#line 37
 testRunner.Then("I expect the current time value to be", ((string)(null)), table5, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create a single digit time system with named members and return name by value")]
        public virtual void CreateASingleDigitTimeSystemWithNamedMembersAndReturnNameByValue()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create a single digit time system with named members and return name by value", ((string[])(null)));
#line 42
 this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 43
 testRunner.Given("I have created a test database called \"timeTest\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "bit",
                        "bitValue",
                        "bitText"});
            table6.AddRow(new string[] {
                        "0",
                        "0",
                        "zeroth"});
            table6.AddRow(new string[] {
                        "0",
                        "1",
                        "first"});
            table6.AddRow(new string[] {
                        "0",
                        "2",
                        "second"});
            table6.AddRow(new string[] {
                        "0",
                        "3",
                        "third"});
            table6.AddRow(new string[] {
                        "1",
                        "0",
                        "Zenith"});
            table6.AddRow(new string[] {
                        "1",
                        "1",
                        "summit"});
#line 44
 testRunner.And("I create a time system with the following members", ((string)(null)), table6, "And ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "bit",
                        "bitvalue"});
            table7.AddRow(new string[] {
                        "0",
                        "1"});
            table7.AddRow(new string[] {
                        "1",
                        "0"});
#line 52
 testRunner.When("I set the time to", ((string)(null)), table7, "When ");
#line 56
 testRunner.Then("The current time should be \"first, Zenith\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create a time system, wait for a period and ensure time is correct")]
        public virtual void CreateATimeSystemWaitForAPeriodAndEnsureTimeIsCorrect()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create a time system, wait for a period and ensure time is correct", ((string[])(null)));
#line 58
 this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 59
 testRunner.Given("I have created a test database called \"timeTest\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "bit",
                        "bitValue",
                        "bitText"});
            table8.AddRow(new string[] {
                        "0",
                        "0",
                        "zeroth"});
            table8.AddRow(new string[] {
                        "0",
                        "1",
                        "first"});
            table8.AddRow(new string[] {
                        "1",
                        "0",
                        "zennith"});
            table8.AddRow(new string[] {
                        "1",
                        "1",
                        "shlart"});
            table8.AddRow(new string[] {
                        "2",
                        "0",
                        "barty"});
            table8.AddRow(new string[] {
                        "2",
                        "1",
                        "fooity"});
#line 60
 testRunner.And("I create a time system with the following members", ((string)(null)), table8, "And ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "bit",
                        "bitvalue"});
            table9.AddRow(new string[] {
                        "0",
                        "0"});
            table9.AddRow(new string[] {
                        "1",
                        "0"});
            table9.AddRow(new string[] {
                        "2",
                        "0"});
#line 68
 testRunner.And("I set the time to", ((string)(null)), table9, "And ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "bit",
                        "bitvalue"});
            table10.AddRow(new string[] {
                        "0",
                        "5"});
#line 73
 testRunner.When("I wait for a time period", ((string)(null)), table10, "When ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "bit",
                        "bitvalue"});
            table11.AddRow(new string[] {
                        "2",
                        "0"});
#line 76
 testRunner.Then("I expect the current time value to be", ((string)(null)), table11, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion

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
    [NUnit.Framework.DescriptionAttribute("EventCreation")]
    public partial class EventCreationFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "EventCreation.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "EventCreation", "In order to create meaningful events \r\nAs a writer\r\nI want to be able to open a e" +
                    "vent creation form to set all the items", ProgrammingLanguage.CSharp, ((string[])(null)));
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
 testRunner.Given("I have set up configuration to use testConfig", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.And("I have created a test database called \"eventCreation\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "history"});
            table1.AddRow(new string[] {
                        "testPlace",
                        "history1"});
            table1.AddRow(new string[] {
                        "testPlace2",
                        "history1"});
#line 9
 testRunner.And("I create the following places", ((string)(null)), table1, "And ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "backstory",
                        "race",
                        "sex",
                        "place"});
            table2.AddRow(new string[] {
                        "jim",
                        "none",
                        "foot",
                        "rarley",
                        "testPlace"});
            table2.AddRow(new string[] {
                        "jim2",
                        "none",
                        "foot",
                        "rarley",
                        "testPlace"});
            table2.AddRow(new string[] {
                        "jim3",
                        "none",
                        "foot",
                        "rarley",
                        "testPlace2"});
            table2.AddRow(new string[] {
                        "jim4",
                        "none",
                        "foot",
                        "rarley",
                        "testPlace2"});
#line 13
 testRunner.And("I create the following characters", ((string)(null)), table2, "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Open Event creation")]
        public virtual void OpenEventCreation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Open Event creation", ((string[])(null)));
#line 20
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 21
 testRunner.When("I click create event in the event sequencer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 22
 testRunner.Then("The resulting RedirectToRouteResult should be to controller \"Event\" action \"Creat" +
                    "e\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("open event creation - verify the viewmodel")]
        public virtual void OpenEventCreation_VerifyTheViewmodel()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("open event creation - verify the viewmodel", ((string[])(null)));
#line 24
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 25
 testRunner.When("I call create on Event controller", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "name"});
            table3.AddRow(new string[] {
                        "testPlace"});
            table3.AddRow(new string[] {
                        "testPlace2"});
#line 26
 testRunner.Then("I expect event creation to have the following places", ((string)(null)), table3, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "name"});
            table4.AddRow(new string[] {
                        "jim"});
            table4.AddRow(new string[] {
                        "jim2"});
            table4.AddRow(new string[] {
                        "jim3"});
            table4.AddRow(new string[] {
                        "jim4"});
#line 30
 testRunner.And("I expect event creation to have the following characters available", ((string)(null)), table4, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create an event")]
        public virtual void CreateAnEvent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create an event", ((string[])(null)));
#line 37
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "Description",
                        "Outcomes",
                        "Places",
                        "Duration",
                        "Characters",
                        "Event Type"});
            table5.AddRow(new string[] {
                        "testEvent",
                        "a test event to show how things work",
                        "passed, failed, war",
                        "testPlace,testPlace2",
                        "3",
                        "jim,jim3",
                        "story"});
#line 38
 testRunner.When("I create the following events", ((string)(null)), table5, "When ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "Description",
                        "Outcomes",
                        "Places",
                        "Duration",
                        "Characters",
                        "Event Type"});
            table6.AddRow(new string[] {
                        "testEvent",
                        "a test event to show how things work",
                        "passed, failed, war",
                        "testPlace,testPlace2",
                        "3",
                        "jim,jim3",
                        "story"});
#line 41
 testRunner.Then("I expect the following events to exist", ((string)(null)), table6, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Click edit Event - require viewmodel to contain list of all places and characters" +
            "")]
        public virtual void ClickEditEvent_RequireViewmodelToContainListOfAllPlacesAndCharacters()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Click edit Event - require viewmodel to contain list of all places and characters" +
                    "", ((string[])(null)));
#line 45
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "Description",
                        "Outcomes",
                        "Places",
                        "Duration",
                        "Characters",
                        "Event Type"});
            table7.AddRow(new string[] {
                        "testEvent",
                        "a test event to show how things work",
                        "passed, failed, war",
                        "testPlace,testPlace2",
                        "3",
                        "jim,jim3",
                        "story"});
#line 46
 testRunner.Given("I create the following events", ((string)(null)), table7, "Given ");
#line 49
 testRunner.When("I edit the Event \"testEvent\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "name"});
            table8.AddRow(new string[] {
                        "testPlace"});
            table8.AddRow(new string[] {
                        "testPlace2"});
#line 50
 testRunner.Then("I expect event event editor to have the following places", ((string)(null)), table8, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "name"});
            table9.AddRow(new string[] {
                        "jim"});
            table9.AddRow(new string[] {
                        "jim2"});
            table9.AddRow(new string[] {
                        "jim3"});
            table9.AddRow(new string[] {
                        "jim4"});
#line 54
 testRunner.And("I expect the event editor to have the following characters", ((string)(null)), table9, "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion

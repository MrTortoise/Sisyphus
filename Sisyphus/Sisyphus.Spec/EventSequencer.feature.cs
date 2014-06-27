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
    [NUnit.Framework.DescriptionAttribute("EventSequencer")]
    public partial class EventSequencerFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "EventSequencer.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "EventSequencer", "In order to tell a story in terms of sequences of events\r\nAs a writer\r\nI want to " +
                    "be able to create and chain together events \r\nI also want to be able to opent he" +
                    "m in the EventEditor", ProgrammingLanguage.CSharp, ((string[])(null)));
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
#line 7
#line 8
 testRunner.Given("I have created a test database called \"eventsTest\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
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
                        "somewhere"});
            table2.AddRow(new string[] {
                        "jim2",
                        "none",
                        "foot",
                        "rarley",
                        "somewhere"});
            table2.AddRow(new string[] {
                        "jim3",
                        "none",
                        "foot",
                        "rarley",
                        "somewhere"});
            table2.AddRow(new string[] {
                        "jim4",
                        "none",
                        "foot",
                        "rarley",
                        "somewhere"});
#line 13
 testRunner.And("I create the following characters", ((string)(null)), table2, "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "Description",
                        "Outcomes",
                        "Places",
                        "Duration",
                        "Characters",
                        "Event Type"});
            table3.AddRow(new string[] {
                        "testEvent",
                        "a test event to show how things work",
                        "",
                        "testPlace",
                        "3",
                        "jim,jim3",
                        "story"});
            table3.AddRow(new string[] {
                        "testEvent2",
                        "a test event to show how things work",
                        "",
                        "testPlace",
                        "3",
                        "jim,jim4",
                        "story"});
            table3.AddRow(new string[] {
                        "testEvent3",
                        "decision event",
                        "passed, failed, war",
                        "testPlace",
                        "3",
                        "jim,jim4",
                        "decision"});
            table3.AddRow(new string[] {
                        "testEvent4",
                        "decision event",
                        "passed, failed, war",
                        "testPlace",
                        "3",
                        "jim,jim4",
                        "decision"});
#line 19
 testRunner.And("I create the following events", ((string)(null)), table3, "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Open event sequencer and select an event")]
        public virtual void OpenEventSequencerAndSelectAnEvent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Open event sequencer and select an event", ((string[])(null)));
#line 26
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 27
 testRunner.Given("I open the view \"EventSequencer\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 28
 testRunner.When("I select the event \"testEvent\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 29
 testRunner.Then("I expect the event sequencer to have the event \"testEvent\" selected", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Open the event editor with the correct event")]
        public virtual void OpenTheEventEditorWithTheCorrectEvent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Open the event editor with the correct event", ((string[])(null)));
#line 31
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 32
 testRunner.Given("I open the view \"EventSequencer\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 33
 testRunner.And("I select the event \"testEvent\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
 testRunner.When("I click open EventEditor", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 35
 testRunner.Then("I expect to get the \"EventEditor\" view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 36
 testRunner.And("I expect the event editor to have the event \"testEvent\" selected", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Select a story event and choose to chain another story event from it")]
        public virtual void SelectAStoryEventAndChooseToChainAnotherStoryEventFromIt()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Select a story event and choose to chain another story event from it", ((string[])(null)));
#line 38
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 39
 testRunner.Given("I open the view \"EventSequencer\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 40
 testRunner.And("I select the event \"testEvent\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
 testRunner.When("I select the event \"testEvent2\" to chain and click chain event", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 42
 testRunner.Then("I expect the event \"testEvent2\" to be chained from event \"testEvent\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Select a decision event, choose an outcome and assign a story event to it")]
        public virtual void SelectADecisionEventChooseAnOutcomeAndAssignAStoryEventToIt()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Select a decision event, choose an outcome and assign a story event to it", ((string[])(null)));
#line 44
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 45
 testRunner.Given("I open the view \"EventSequencer\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 46
 testRunner.And("I select the event \"testEvent3\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
 testRunner.When("I select the outcome \"passed\", story event \"testEvent\" and click chain", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 48
 testRunner.Then("I expect the event \"TestEvent\" to be chained from the event \"testEvent3\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Fail to chain a decision event to a decision event")]
        public virtual void FailToChainADecisionEventToADecisionEvent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Fail to chain a decision event to a decision event", ((string[])(null)));
#line 50
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 51
 testRunner.Given("I open the view \"EventSequencer\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 52
 testRunner.And("I select the event \"testEvent3\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
 testRunner.Then("I expect an exception when I select the outcome \"passed\", story event \"testEvent4" +
                    "\" and click chain", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion

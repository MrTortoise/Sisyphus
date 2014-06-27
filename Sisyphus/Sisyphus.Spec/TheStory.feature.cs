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
    [NUnit.Framework.DescriptionAttribute("TheStory")]
    public partial class TheStoryFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "TheStory.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "TheStory", "In order to consume sisyphus I need a guiding frameork that will take me through " +
                    "it\r\nAs a consumer\r\nI want to be able to traverse the time, decision space, local" +
                    "ity and characters of Sisyphus", ProgrammingLanguage.CSharp, ((string[])(null)));
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
 testRunner.Given("I have created a test database called \"storyTest\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "history"});
            table1.AddRow(new string[] {
                        "test1",
                        "history1"});
#line 8
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
#line 11
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
                        "another test",
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
            table3.AddRow(new string[] {
                        "testEvent5",
                        "yet another test",
                        "",
                        "testPlace",
                        "3",
                        "jim,jim4",
                        "story"});
#line 14
 testRunner.And("I create the following events", ((string)(null)), table3, "And ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "parent",
                        "outcome",
                        "child"});
            table4.AddRow(new string[] {
                        "testEvent",
                        "",
                        "testEvent3"});
            table4.AddRow(new string[] {
                        "testEvent3",
                        "passed",
                        "testEvent2"});
            table4.AddRow(new string[] {
                        "testEvent2",
                        "",
                        "testEvent4"});
            table4.AddRow(new string[] {
                        "testEvent3",
                        "failed",
                        "testEvent5"});
#line 21
 testRunner.And("I chain the following events", ((string)(null)), table4, "And ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "eventStepId",
                        "narrative"});
            table5.AddRow(new string[] {
                        "0",
                        "look its some story"});
#line 27
 testRunner.And("I add to the event \"testEvent3\" from perspective of \"jim\" the following Narrative" +
                    "", ((string)(null)), table5, "And ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "eventStepId",
                        "dialog"});
            table6.AddRow(new string[] {
                        "1",
                        "Jim says \"Its awfully lonley in this scenario\""});
#line 30
 testRunner.And("I add to the event \"testEvent3\" from perspective of \"jim\" the following lines of " +
                    "dialogue", ((string)(null)), table6, "And ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "eventStepId",
                        "narrative"});
            table7.AddRow(new string[] {
                        "2",
                        "look its some more story"});
#line 33
 testRunner.And("I add to the event \"testEvent3\" from perspective of \"jim\" the following Narrative" +
                    "", ((string)(null)), table7, "And ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "eventStepId",
                        "narrative"});
            table8.AddRow(new string[] {
                        "0",
                        "boom we made it a long way"});
#line 36
 testRunner.And("I add to the event \"testEvent5\" from perspective of \"jim\" the following Narrative" +
                    "", ((string)(null)), table8, "And ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "bit",
                        "bitValue",
                        "bitText"});
            table9.AddRow(new string[] {
                        "0",
                        "0",
                        "0"});
            table9.AddRow(new string[] {
                        "0",
                        "1",
                        "1"});
            table9.AddRow(new string[] {
                        "0",
                        "2",
                        "2"});
            table9.AddRow(new string[] {
                        "0",
                        "3",
                        "3"});
            table9.AddRow(new string[] {
                        "0",
                        "4",
                        "4"});
            table9.AddRow(new string[] {
                        "0",
                        "5",
                        "5"});
            table9.AddRow(new string[] {
                        "0",
                        "6",
                        "6"});
#line 39
 testRunner.And("I create a time system with the following members", ((string)(null)), table9, "And ");
#line 48
 testRunner.And("I have set the world narrative to \"this is the world backstory\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Start a path in the story")]
        public virtual void StartAPathInTheStory()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Start a path in the story", ((string[])(null)));
#line 50
this.ScenarioSetup(scenarioInfo);
#line 6
 this.FeatureBackground();
#line 51
 testRunner.Given("I have created a test database called \"placesTest\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 52
 testRunner.When("I start the starting point process off", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 53
 testRunner.Then("I expect to be on the \"BackStory\" view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Select one or more characters to follow and start a story")]
        public virtual void SelectOneOrMoreCharactersToFollowAndStartAStory()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Select one or more characters to follow and start a story", ((string[])(null)));
#line 55
this.ScenarioSetup(scenarioInfo);
#line 6
 this.FeatureBackground();
#line 56
 testRunner.Given("I have chosen to start a story", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 57
 testRunner.And("I open the view \"CharacterBrowser\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "name"});
            table10.AddRow(new string[] {
                        "jim"});
#line 58
 testRunner.And("I Choose to follow the following characters in the character browser", ((string)(null)), table10, "And ");
#line 61
 testRunner.When("I select StartStory", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 62
 testRunner.Then("I expect to get the \"StoryNavigator\" view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Ask storyNavigator for next set to interactions")]
        public virtual void AskStoryNavigatorForNextSetToInteractions()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Ask storyNavigator for next set to interactions", ((string[])(null)));
#line 64
this.ScenarioSetup(scenarioInfo);
#line 6
 this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "bit",
                        "bitvalue"});
            table11.AddRow(new string[] {
                        "0",
                        "0"});
#line 65
 testRunner.Given("I set the time to", ((string)(null)), table11, "Given ");
#line 68
 testRunner.And("I open the view \"StoryNavigator\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 69
 testRunner.When("I step the story", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "bit",
                        "bitvalue"});
            table12.AddRow(new string[] {
                        "0",
                        "3"});
#line 70
 testRunner.Then("I expect the current time value to be", ((string)(null)), table12, "Then ");
#line 73
 testRunner.And("I expect the current event to be \"testEvent3\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "eventStepId",
                        "story lines"});
            table13.AddRow(new string[] {
                        "0",
                        "look its some story"});
            table13.AddRow(new string[] {
                        "1",
                        "Jim says \"Its awfully lonley in this scenario\""});
            table13.AddRow(new string[] {
                        "2",
                        "look its some more story"});
#line 74
 testRunner.And("Then I expect \"jim\" to have the following story", ((string)(null)), table13, "And ");
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "outcome"});
            table14.AddRow(new string[] {
                        "failed"});
            table14.AddRow(new string[] {
                        "passed"});
            table14.AddRow(new string[] {
                        "war"});
#line 79
 testRunner.And("I expect \"jim\" to have the following outcomes", ((string)(null)), table14, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get to first decision make decision wait 3 verify at next event")]
        public virtual void GetToFirstDecisionMakeDecisionWait3VerifyAtNextEvent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get to first decision make decision wait 3 verify at next event", ((string[])(null)));
#line 85
this.ScenarioSetup(scenarioInfo);
#line 6
 this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                        "bit",
                        "bitvalue"});
            table15.AddRow(new string[] {
                        "0",
                        "0"});
#line 86
 testRunner.Given("I set the time to", ((string)(null)), table15, "Given ");
#line 89
 testRunner.And("I open the view \"StoryNavigator\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 90
 testRunner.And("I step the story", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 91
 testRunner.When("I choose the outcome \"failed\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                        "bit",
                        "bitvalue"});
            table16.AddRow(new string[] {
                        "0",
                        "6"});
#line 92
 testRunner.Then("I expect the current time value to be", ((string)(null)), table16, "Then ");
#line 95
 testRunner.And("I expect the current event to be \"testEvent5\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                        "eventStepId",
                        "story lines"});
            table17.AddRow(new string[] {
                        "0",
                        "Boom we made it a long way"});
#line 96
 testRunner.And("I expect \"jim\" to have the following story", ((string)(null)), table17, "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion

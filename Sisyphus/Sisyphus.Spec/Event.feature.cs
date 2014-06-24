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
    [NUnit.Framework.DescriptionAttribute("Event")]
    public partial class EventFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Event.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Event", "In order to describe the structure of a story and tie together interactions of gr" +
                    "oups of characters\r\nAs a writer\r\nI want to be able to create events", ProgrammingLanguage.CSharp, ((string[])(null)));
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
#line 8
 testRunner.And("I create the following places", ((string)(null)), table1, "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create an event")]
        public virtual void CreateAnEvent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create an event", ((string[])(null)));
#line 13
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 14
 testRunner.Given("I open the view \"EventEditor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "Description",
                        "Outcomes",
                        "Places"});
            table2.AddRow(new string[] {
                        "testEvent",
                        "a test event to show how things work",
                        "passed, failed, war",
                        "testPlace,testPlace2"});
#line 15
 testRunner.When("I create the following events", ((string)(null)), table2, "When ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "Description",
                        "Outcomes",
                        "Places"});
            table3.AddRow(new string[] {
                        "testEvent",
                        "a test event to show how things work",
                        "passed, failed, war",
                        "testPlace,testPlace2"});
#line 18
 testRunner.Then("I expect the following events to exist", ((string)(null)), table3, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Add a character to an event")]
        public virtual void AddACharacterToAnEvent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add a character to an event", ((string[])(null)));
#line 22
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "backstory",
                        "race",
                        "sex",
                        "place"});
            table4.AddRow(new string[] {
                        "jim",
                        "is some dude",
                        "last",
                        "kinda",
                        "testPlace"});
#line 23
 testRunner.Given("I create the following characters", ((string)(null)), table4, "Given ");
#line 26
 testRunner.And("I open the view \"EventEditor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "Description",
                        "Outcomes",
                        "Places"});
            table5.AddRow(new string[] {
                        "testEvent",
                        "a test event to show how things work",
                        "passed, failed, war",
                        "testPlace,testPlace2"});
#line 27
 testRunner.And("I create the following events", ((string)(null)), table5, "And ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "name"});
            table6.AddRow(new string[] {
                        "jim"});
#line 30
 testRunner.When("I add the following characters to the event \"testEvent\"", ((string)(null)), table6, "When ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "name"});
            table7.AddRow(new string[] {
                        "jim"});
#line 33
 testRunner.Then("I expect the event \"testEvent\" to contain the following characters", ((string)(null)), table7, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Add dialogue to an event")]
        public virtual void AddDialogueToAnEvent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add dialogue to an event", ((string[])(null)));
#line 37
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "backstory",
                        "race",
                        "sex",
                        "place"});
            table8.AddRow(new string[] {
                        "jim",
                        "is some dude",
                        "last",
                        "kinda",
                        "testPlace"});
#line 38
 testRunner.Given("I create the following characters", ((string)(null)), table8, "Given ");
#line 41
 testRunner.And("I open the view \"EventEditor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "Description",
                        "Outcomes",
                        "Places"});
            table9.AddRow(new string[] {
                        "testEvent",
                        "a test event to show how things work",
                        "passed, failed, war",
                        "testPlace,testPlace2"});
#line 42
 testRunner.And("I create the following events", ((string)(null)), table9, "And ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "name"});
            table10.AddRow(new string[] {
                        "jim"});
#line 45
 testRunner.And("I add the following characters to the event \"testEvent\"", ((string)(null)), table10, "And ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "dialog"});
            table11.AddRow(new string[] {
                        "look its some story"});
#line 48
 testRunner.When("I add to the event \"testEvent\" from perspective of \"jim\" the following lines of d" +
                    "ialogue", ((string)(null)), table11, "When ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "story lines"});
            table12.AddRow(new string[] {
                        "Jim says \"Its awfully lonley in this scenario\""});
#line 51
 testRunner.Then("I expect \"jim\" to have the following story", ((string)(null)), table12, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Add dialogue to an event with multiple characters (dialogue is shared (objective)" +
            ")")]
        public virtual void AddDialogueToAnEventWithMultipleCharactersDialogueIsSharedObjective()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add dialogue to an event with multiple characters (dialogue is shared (objective)" +
                    ")", ((string[])(null)));
#line 55
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "backstory",
                        "race",
                        "sex",
                        "place"});
            table13.AddRow(new string[] {
                        "jim",
                        "is some dude",
                        "last",
                        "kinda",
                        "testPlace"});
            table13.AddRow(new string[] {
                        "jim2",
                        "is some dude",
                        "last",
                        "kinda",
                        "testPlace"});
#line 56
 testRunner.Given("I create the following characters", ((string)(null)), table13, "Given ");
#line 60
 testRunner.And("I open the view \"EventEditor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "Description",
                        "Outcomes",
                        "Places"});
            table14.AddRow(new string[] {
                        "testEvent",
                        "a test event to show how things work",
                        "passed, failed, war",
                        "testPlace,testPlace2"});
#line 61
 testRunner.And("I create the following events", ((string)(null)), table14, "And ");
#line hidden
            TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                        "name"});
            table15.AddRow(new string[] {
                        "jim"});
            table15.AddRow(new string[] {
                        "jim2"});
#line 64
 testRunner.And("I add the following characters to the event \"testEvent\"", ((string)(null)), table15, "And ");
#line hidden
            TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                        "dialog"});
            table16.AddRow(new string[] {
                        "Jim says \"Its awfully lonley in this scenario\""});
#line 68
 testRunner.When("I add to the event \"testEvent\" from perspective of \"jim\" the following lines of d" +
                    "ialogue", ((string)(null)), table16, "When ");
#line hidden
            TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                        "story lines"});
            table17.AddRow(new string[] {
                        "Jim says \"Its awfully lonley in this scenario\""});
#line 71
 testRunner.Then("I expect \"jim\" to have the following story", ((string)(null)), table17, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table18 = new TechTalk.SpecFlow.Table(new string[] {
                        "story lines"});
            table18.AddRow(new string[] {
                        "Jim says \"Its awfully lonley in this scenario\""});
#line 74
 testRunner.And("I expect \"jim2\" to have the following story", ((string)(null)), table18, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Add Narrative to an event")]
        public virtual void AddNarrativeToAnEvent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add Narrative to an event", ((string[])(null)));
#line 78
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table19 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "backstory",
                        "race",
                        "sex",
                        "place"});
            table19.AddRow(new string[] {
                        "jim",
                        "is some dude",
                        "last",
                        "kinda",
                        "testPlace"});
#line 79
 testRunner.Given("I create the following characters", ((string)(null)), table19, "Given ");
#line 82
 testRunner.And("I open the view \"EventEditor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table20 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "Description",
                        "Outcomes",
                        "Places"});
            table20.AddRow(new string[] {
                        "testEvent",
                        "a test event to show how things work",
                        "passed, failed, war",
                        "testPlace,testPlace2"});
#line 83
 testRunner.And("I create the following events", ((string)(null)), table20, "And ");
#line hidden
            TechTalk.SpecFlow.Table table21 = new TechTalk.SpecFlow.Table(new string[] {
                        "name"});
            table21.AddRow(new string[] {
                        "jim"});
#line 86
 testRunner.And("I add the following characters to the event \"testEvent\"", ((string)(null)), table21, "And ");
#line hidden
            TechTalk.SpecFlow.Table table22 = new TechTalk.SpecFlow.Table(new string[] {
                        "narrative"});
            table22.AddRow(new string[] {
                        "look its some story"});
#line 89
 testRunner.When("I add to the event \"testEvent\" from perspective of \"jim\" the following Narrative", ((string)(null)), table22, "When ");
#line hidden
            TechTalk.SpecFlow.Table table23 = new TechTalk.SpecFlow.Table(new string[] {
                        "story lines"});
            table23.AddRow(new string[] {
                        "look its some story"});
#line 92
 testRunner.Then("I expect \"jim\" to have the following Narrative", ((string)(null)), table23, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Add Narrative to an event with 2 chars - but only 1 narrative (so both get that n" +
            "arrative as a convinience)")]
        public virtual void AddNarrativeToAnEventWith2Chars_ButOnly1NarrativeSoBothGetThatNarrativeAsAConvinience()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add Narrative to an event with 2 chars - but only 1 narrative (so both get that n" +
                    "arrative as a convinience)", ((string[])(null)));
#line 96
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table24 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "backstory",
                        "race",
                        "sex",
                        "place"});
            table24.AddRow(new string[] {
                        "jim",
                        "is some dude",
                        "last",
                        "kinda",
                        "testPlace"});
            table24.AddRow(new string[] {
                        "jim2",
                        "is some dude",
                        "last",
                        "kinda",
                        "testPlace"});
#line 97
 testRunner.Given("I create the following characters", ((string)(null)), table24, "Given ");
#line 101
 testRunner.And("I open the view \"EventEditor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table25 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "Description",
                        "Outcomes",
                        "Places"});
            table25.AddRow(new string[] {
                        "testEvent",
                        "a test event to show how things work",
                        "passed, failed, war",
                        "testPlace,testPlace2"});
#line 102
 testRunner.And("I create the following events", ((string)(null)), table25, "And ");
#line hidden
            TechTalk.SpecFlow.Table table26 = new TechTalk.SpecFlow.Table(new string[] {
                        "name"});
            table26.AddRow(new string[] {
                        "jim"});
            table26.AddRow(new string[] {
                        "jim2"});
#line 105
 testRunner.And("I add the following characters to the event \"testEvent\"", ((string)(null)), table26, "And ");
#line hidden
            TechTalk.SpecFlow.Table table27 = new TechTalk.SpecFlow.Table(new string[] {
                        "narrative"});
            table27.AddRow(new string[] {
                        "look its some story"});
#line 109
 testRunner.When("I add to the event \"testEvent\" from perspective of \"jim\" the following Narrative", ((string)(null)), table27, "When ");
#line hidden
            TechTalk.SpecFlow.Table table28 = new TechTalk.SpecFlow.Table(new string[] {
                        "story lines"});
            table28.AddRow(new string[] {
                        "look its some story"});
#line 112
 testRunner.Then("I expect \"jim\" to have the following Narrative", ((string)(null)), table28, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table29 = new TechTalk.SpecFlow.Table(new string[] {
                        "story lines"});
            table29.AddRow(new string[] {
                        "look its some story"});
#line 115
 testRunner.And("I expect \"jim\" to have the following Narrative", ((string)(null)), table29, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Add narative and dialogue to an event with 2 chars - sequence test")]
        public virtual void AddNarativeAndDialogueToAnEventWith2Chars_SequenceTest()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add narative and dialogue to an event with 2 chars - sequence test", ((string[])(null)));
#line 119
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table30 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "backstory",
                        "race",
                        "sex",
                        "place"});
            table30.AddRow(new string[] {
                        "jim",
                        "is some dude",
                        "last",
                        "kinda",
                        "testPlace"});
            table30.AddRow(new string[] {
                        "jim2",
                        "is some dude",
                        "last",
                        "kinda",
                        "testPlace"});
#line 120
 testRunner.Given("I create the following characters", ((string)(null)), table30, "Given ");
#line 124
 testRunner.And("I open the view \"EventEditor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table31 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "Description",
                        "Outcomes",
                        "Places"});
            table31.AddRow(new string[] {
                        "testEvent",
                        "a test event to show how things work",
                        "passed, failed, war",
                        "testPlace,testPlace2"});
#line 125
 testRunner.And("I create the following events", ((string)(null)), table31, "And ");
#line hidden
            TechTalk.SpecFlow.Table table32 = new TechTalk.SpecFlow.Table(new string[] {
                        "name"});
            table32.AddRow(new string[] {
                        "jim"});
            table32.AddRow(new string[] {
                        "jim2"});
#line 128
 testRunner.And("I add the following characters to the event \"testEvent\"", ((string)(null)), table32, "And ");
#line hidden
            TechTalk.SpecFlow.Table table33 = new TechTalk.SpecFlow.Table(new string[] {
                        "narrative"});
            table33.AddRow(new string[] {
                        "look its some story"});
#line 132
 testRunner.When("I add to the event \"testEvent\" from perspective of \"jim\" the following Narrative", ((string)(null)), table33, "When ");
#line hidden
            TechTalk.SpecFlow.Table table34 = new TechTalk.SpecFlow.Table(new string[] {
                        "dialog"});
            table34.AddRow(new string[] {
                        "Jim says \"Its awfully lonley in this scenario\""});
#line 135
 testRunner.And("I add to the event \"testEvent\" from perspective of \"jim\" the following lines of d" +
                    "ialogue", ((string)(null)), table34, "And ");
#line hidden
            TechTalk.SpecFlow.Table table35 = new TechTalk.SpecFlow.Table(new string[] {
                        "narrative"});
            table35.AddRow(new string[] {
                        "look its some more story"});
#line 138
 testRunner.And("I add to the event \"testEvent\" from perspective of \"jim\" the following Narrative", ((string)(null)), table35, "And ");
#line hidden
            TechTalk.SpecFlow.Table table36 = new TechTalk.SpecFlow.Table(new string[] {
                        "story lines"});
            table36.AddRow(new string[] {
                        "look its some story"});
            table36.AddRow(new string[] {
                        "Jim says \"Its awfully lonley in this scenario\""});
            table36.AddRow(new string[] {
                        "look its some more story"});
#line 141
 testRunner.Then("I expect \"jim\" to have the following Narrative", ((string)(null)), table36, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table37 = new TechTalk.SpecFlow.Table(new string[] {
                        "story lines"});
            table37.AddRow(new string[] {
                        "look its some story"});
            table37.AddRow(new string[] {
                        "Jim says \"Its awfully lonley in this scenario\""});
            table37.AddRow(new string[] {
                        "look its some more story"});
#line 146
 testRunner.And("I expect \"jim\" to have the following Narrative", ((string)(null)), table37, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("2 characters shared dialog but unique narrative for both")]
        public virtual void _2CharactersSharedDialogButUniqueNarrativeForBoth()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("2 characters shared dialog but unique narrative for both", ((string[])(null)));
#line 152
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table38 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "backstory",
                        "race",
                        "sex",
                        "place"});
            table38.AddRow(new string[] {
                        "jim",
                        "is some dude",
                        "last",
                        "kinda",
                        "testPlace"});
            table38.AddRow(new string[] {
                        "jim2",
                        "is some dude",
                        "last",
                        "kinda",
                        "testPlace"});
#line 153
 testRunner.Given("I create the following characters", ((string)(null)), table38, "Given ");
#line 157
 testRunner.And("I open the view \"EventEditor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table39 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "Description",
                        "Outcomes",
                        "Places"});
            table39.AddRow(new string[] {
                        "testEvent",
                        "a test event to show how things work",
                        "passed, failed, war",
                        "testPlace,testPlace2"});
#line 158
 testRunner.And("I create the following events", ((string)(null)), table39, "And ");
#line hidden
            TechTalk.SpecFlow.Table table40 = new TechTalk.SpecFlow.Table(new string[] {
                        "name"});
            table40.AddRow(new string[] {
                        "jim"});
            table40.AddRow(new string[] {
                        "jim2"});
#line 161
 testRunner.And("I add the following characters to the event \"testEvent\"", ((string)(null)), table40, "And ");
#line hidden
            TechTalk.SpecFlow.Table table41 = new TechTalk.SpecFlow.Table(new string[] {
                        "narrative"});
            table41.AddRow(new string[] {
                        "look its some story"});
#line 165
 testRunner.When("I add to the event \"testEvent\" from perspective of \"jim\" the following Narrative", ((string)(null)), table41, "When ");
#line hidden
            TechTalk.SpecFlow.Table table42 = new TechTalk.SpecFlow.Table(new string[] {
                        "narrative"});
            table42.AddRow(new string[] {
                        "look its some other story"});
#line 168
 testRunner.And("I add to the event \"testEvent\" from perspective of \"jim2\" the following Narrative" +
                    "", ((string)(null)), table42, "And ");
#line hidden
            TechTalk.SpecFlow.Table table43 = new TechTalk.SpecFlow.Table(new string[] {
                        "dialog"});
            table43.AddRow(new string[] {
                        "Jim says \"Its awfully lonley in this scenario\""});
#line 171
 testRunner.And("I add to the event \"testEvent\" from perspective of \"jim\" the following lines of d" +
                    "ialogue", ((string)(null)), table43, "And ");
#line hidden
            TechTalk.SpecFlow.Table table44 = new TechTalk.SpecFlow.Table(new string[] {
                        "narrative"});
            table44.AddRow(new string[] {
                        "look its some more story"});
#line 174
 testRunner.And("I add to the event \"testEvent\" from perspective of \"jim\" the following Narrative", ((string)(null)), table44, "And ");
#line hidden
            TechTalk.SpecFlow.Table table45 = new TechTalk.SpecFlow.Table(new string[] {
                        "story lines"});
            table45.AddRow(new string[] {
                        "look its some story"});
            table45.AddRow(new string[] {
                        "Jim says \"Its awfully lonley in this scenario\""});
            table45.AddRow(new string[] {
                        "look its some more story"});
#line 177
 testRunner.Then("I expect \"jim\" to have the following Narrative", ((string)(null)), table45, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table46 = new TechTalk.SpecFlow.Table(new string[] {
                        "story lines"});
            table46.AddRow(new string[] {
                        "look its some other story"});
            table46.AddRow(new string[] {
                        "Jim says \"Its awfully lonley in this scenario\""});
#line 182
 testRunner.And("I expect \"jim\" to have the following Narrative", ((string)(null)), table46, "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion

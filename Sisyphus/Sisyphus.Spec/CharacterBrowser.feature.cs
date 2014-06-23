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
    [NUnit.Framework.DescriptionAttribute("CharacterBrowser")]
    public partial class CharacterBrowserFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CharacterBrowser.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CharacterBrowser", "In order to view a story from a character centric perspective or just explore a c" +
                    "haracter\r\nAs a consumer \r\nI want to select and view a character to see its histo" +
                    "ry", ProgrammingLanguage.CSharp, ((string[])(null)));
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
 testRunner.Given("I have created a test database called \"characterBrowserTest\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
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
#line 11
 testRunner.And("I create the following characters", ((string)(null)), table2, "And ");
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
            table3.AddRow(new string[] {
                        "StoryStart",
                        "the start of the story",
                        "started",
                        "testPlace,testPlace2"});
#line 17
 testRunner.And("I create the sollowing events", ((string)(null)), table3, "And ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "name"});
            table4.AddRow(new string[] {
                        "jim"});
#line 21
 testRunner.And("I add the following characters to the event \"testEvent\"", ((string)(null)), table4, "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Open character browser and look at characters")]
        public virtual void OpenCharacterBrowserAndLookAtCharacters()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Open character browser and look at characters", ((string[])(null)));
#line 25
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 26
 testRunner.Given("I open the view \"CharacterBrowser\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "backstory",
                        "race",
                        "sex",
                        "place"});
            table5.AddRow(new string[] {
                        "jim",
                        "none",
                        "foot",
                        "rarley",
                        "somewhere"});
            table5.AddRow(new string[] {
                        "jim2",
                        "none",
                        "foot",
                        "rarley",
                        "somewhere"});
            table5.AddRow(new string[] {
                        "jim3",
                        "none",
                        "foot",
                        "rarley",
                        "somewhere"});
            table5.AddRow(new string[] {
                        "jim4",
                        "none",
                        "foot",
                        "rarley",
                        "somewhere"});
#line 27
 testRunner.Then("I expect the character browser to contain the following characters", ((string)(null)), table5, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Open a specific character from the browser")]
        public virtual void OpenASpecificCharacterFromTheBrowser()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Open a specific character from the browser", ((string[])(null)));
#line 34
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 35
 testRunner.Given("I open the view \"CharacterBrowser\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 36
 testRunner.When("I select the character \"jim\" in the character browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 37
 testRunner.Then("I expect to get the \"CharacterInformation\" view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 38
 testRunner.And("I expect the chatacter \"jim\" to be the CharacterInformation views subject", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("View a specific characters involvement in events")]
        public virtual void ViewASpecificCharactersInvolvementInEvents()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("View a specific characters involvement in events", ((string[])(null)));
#line 40
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 41
 testRunner.Given("I have chosen to start a story", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 42
 testRunner.And("I open the view \"CharacterBrowser\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
 testRunner.And("I select the character \"jim\" in the character browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
 testRunner.When("I select view events in the character browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 45
 testRunner.Then("I expect to see the events browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "name"});
            table6.AddRow(new string[] {
                        "testEvent"});
#line 46
 testRunner.And("I expect the events in the events browser to be", ((string)(null)), table6, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Add characters to a following list")]
        public virtual void AddCharactersToAFollowingList()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add characters to a following list", ((string[])(null)));
#line 50
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 51
 testRunner.Given("I have chosen to start a story", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 52
 testRunner.And("I open the view \"CharacterBrowser\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "name"});
            table7.AddRow(new string[] {
                        "jim"});
            table7.AddRow(new string[] {
                        "jim2"});
#line 53
 testRunner.When("I select the following characters to be followed", ((string)(null)), table7, "When ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "name"});
            table8.AddRow(new string[] {
                        "jim"});
            table8.AddRow(new string[] {
                        "jim2"});
#line 57
 testRunner.Then("I expect the following characters to be followed", ((string)(null)), table8, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion

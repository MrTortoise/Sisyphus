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
    [NUnit.Framework.DescriptionAttribute("StoryCreation")]
    public partial class StoryCreationFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "StoryCreation.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "StoryCreation", "In have a story\r\nAs a writer\r\nI want to be able to create and initialise a story", ProgrammingLanguage.CSharp, ((string[])(null)));
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
 testRunner.And("I set the config key \"SessionTimeout\" to \"15\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
 testRunner.And("I set ContextWrapper To use TestContextWrapper", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
 testRunner.And("I set the user Identity to \"writer@admin.com\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.And("I have set SisyphusDateTime to TestDateTime", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.And("I have set the date to year \"2014\" Month \"7\" Day \"20\" hour \"19\" minute \"24\" secon" +
                    "d \"12\" millisecond \"123\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 testRunner.And("I have created a test database called \"storyCreation\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.And("I create a user with email \"writer@admin.com\" with password \"testtest\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "role"});
            table1.AddRow(new string[] {
                        "Admin"});
            table1.AddRow(new string[] {
                        "Writer"});
            table1.AddRow(new string[] {
                        "Reader"});
#line 15
 testRunner.And("I assign the following roles to user \"writer@admin.com\"", ((string)(null)), table1, "And ");
#line 20
 testRunner.And("I log in with the user \"writer@admin.com\" and password \"testtest\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
 testRunner.And("I use the controller WriterHome", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create a story and verify its initialisation state")]
        public virtual void CreateAStoryAndVerifyItsInitialisationState()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create a story and verify its initialisation state", ((string[])(null)));
#line 23
this.ScenarioSetup(scenarioInfo);
#line 6
 this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "backStory"});
            table2.AddRow(new string[] {
                        "test1",
                        "ooo itS BACK STORY"});
#line 24
 testRunner.When("I have created the stories", ((string)(null)), table2, "When ");
#line 27
 testRunner.And("I select the story \"test1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "Description",
                        "Outcomes",
                        "Duration",
                        "Story"});
            table3.AddRow(new string[] {
                        "Story Start",
                        "Story Start",
                        "StoryStartOutcome",
                        "0",
                        "test1"});
#line 28
 testRunner.Then("I expect the following events to exist", ((string)(null)), table3, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create some stories and verify they are in the index")]
        public virtual void CreateSomeStoriesAndVerifyTheyAreInTheIndex()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create some stories and verify they are in the index", ((string[])(null)));
#line 32
this.ScenarioSetup(scenarioInfo);
#line 6
 this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "backStory"});
            table4.AddRow(new string[] {
                        "test1",
                        "ooo itS BACK STORY"});
            table4.AddRow(new string[] {
                        "test2",
                        "ooo itS BACK STORY"});
            table4.AddRow(new string[] {
                        "test3",
                        "ooo itS BACK STORY"});
#line 33
 testRunner.Given("I have created the stories", ((string)(null)), table4, "Given ");
#line 38
 testRunner.When("I open the story controller index", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "backStory"});
            table5.AddRow(new string[] {
                        "test1",
                        "ooo itS BACK STORY"});
            table5.AddRow(new string[] {
                        "test2",
                        "ooo itS BACK STORY"});
            table5.AddRow(new string[] {
                        "test3",
                        "ooo itS BACK STORY"});
#line 39
 testRunner.Then("I expect the following stories to exist", ((string)(null)), table5, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("view a stories details")]
        public virtual void ViewAStoriesDetails()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("view a stories details", ((string[])(null)));
#line 45
this.ScenarioSetup(scenarioInfo);
#line 6
 this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "backStory"});
            table6.AddRow(new string[] {
                        "test1",
                        "ooo itS BACK STORY"});
            table6.AddRow(new string[] {
                        "test2",
                        "ooo itS BACK STORY"});
            table6.AddRow(new string[] {
                        "test3",
                        "ooo itS BACK STORY"});
#line 46
 testRunner.Given("I have created the stories", ((string)(null)), table6, "Given ");
#line 51
 testRunner.When("I view details of the story \"test1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 52
 testRunner.Then("I expect the story in details to be called \"test1\" and its backstory to be \"ooo i" +
                    "tS BACK STORY\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Select a story to edit")]
        public virtual void SelectAStoryToEdit()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Select a story to edit", ((string[])(null)));
#line 54
this.ScenarioSetup(scenarioInfo);
#line 6
 this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "backStory"});
            table7.AddRow(new string[] {
                        "test1",
                        "ooo itS BACK STORY"});
            table7.AddRow(new string[] {
                        "test2",
                        "ooo itS BACK STORY"});
            table7.AddRow(new string[] {
                        "test3",
                        "ooo itS BACK STORY"});
#line 55
 testRunner.Given("I have created the stories", ((string)(null)), table7, "Given ");
#line 60
 testRunner.When("I click edit story \"test1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 61
 testRunner.Then("I expect the story editor to have story \"test1\" with backstory \"ooo itS BACK STOR" +
                    "Y\" to be selected", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Edit a story, save it and verify it has changed")]
        public virtual void EditAStorySaveItAndVerifyItHasChanged()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Edit a story, save it and verify it has changed", ((string[])(null)));
#line 63
this.ScenarioSetup(scenarioInfo);
#line 6
 this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "backStory"});
            table8.AddRow(new string[] {
                        "test1",
                        "ooo itS BACK STORY"});
            table8.AddRow(new string[] {
                        "test2",
                        "ooo itS BACK STORY"});
            table8.AddRow(new string[] {
                        "test3",
                        "ooo itS BACK STORY"});
#line 64
 testRunner.Given("I have created the stories", ((string)(null)), table8, "Given ");
#line 69
 testRunner.And("I click edit story \"test1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
 testRunner.When("I set the story name to \"edited\" and the backstory to \"edited\" and save the edit", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 71
 testRunner.And("I open the story controller index", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "backStory"});
            table9.AddRow(new string[] {
                        "edited",
                        "edited"});
#line 72
 testRunner.Then("I expect the following stories to exist", ((string)(null)), table9, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion

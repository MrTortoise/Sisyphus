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
    [NUnit.Framework.DescriptionAttribute("Places")]
    public partial class PlacesFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Places.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Places", "In order to have locations characters can interact in\r\nAs a writer\r\nI want to be " +
                    "to manipulate places", ProgrammingLanguage.CSharp, ((string[])(null)));
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
 testRunner.And("I have created a test database called \"placesTest\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
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
#line 14
 testRunner.And("I assign the following roles to user \"writer@admin.com\"", ((string)(null)), table1, "And ");
#line 19
 testRunner.And("I log in with the user \"writer@admin.com\" and password \"testtest\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "backStory"});
            table2.AddRow(new string[] {
                        "test1",
                        "ooo itS BACK STORY"});
            table2.AddRow(new string[] {
                        "test2",
                        "COR HE THINKS ITS A WEAL STOWY"});
#line 20
 testRunner.And("I have created the stories", ((string)(null)), table2, "And ");
#line 24
 testRunner.And("I select the story \"test1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create a new place with a name and history")]
        [NUnit.Framework.CategoryAttribute("mytag")]
        public virtual void CreateANewPlaceWithANameAndHistory()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create a new place with a name and history", new string[] {
                        "mytag"});
#line 27
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 28
 testRunner.When("I create a place called \"test1\" with history \"history1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "history"});
            table3.AddRow(new string[] {
                        "test1",
                        "history1"});
#line 29
 testRunner.Then("I expect places to contain", ((string)(null)), table3, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create several places and return them")]
        public virtual void CreateSeveralPlacesAndReturnThem()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create several places and return them", ((string[])(null)));
#line 33
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "history"});
            table4.AddRow(new string[] {
                        "test1",
                        "history1"});
            table4.AddRow(new string[] {
                        "test2",
                        "history2"});
            table4.AddRow(new string[] {
                        "test3",
                        "history3"});
            table4.AddRow(new string[] {
                        "test4",
                        "history4"});
#line 34
 testRunner.When("I create the following places", ((string)(null)), table4, "When ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "history"});
            table5.AddRow(new string[] {
                        "test1",
                        "history1"});
            table5.AddRow(new string[] {
                        "test2",
                        "history2"});
            table5.AddRow(new string[] {
                        "test3",
                        "history3"});
            table5.AddRow(new string[] {
                        "test4",
                        "history4"});
#line 40
 testRunner.Then("I expect places to contain", ((string)(null)), table5, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create a list of places and return a page")]
        public virtual void CreateAListOfPlacesAndReturnAPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create a list of places and return a page", ((string[])(null)));
#line 47
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "history"});
            table6.AddRow(new string[] {
                        "test1",
                        "history1"});
            table6.AddRow(new string[] {
                        "test2",
                        "history2"});
            table6.AddRow(new string[] {
                        "test3",
                        "history3"});
            table6.AddRow(new string[] {
                        "test4",
                        "history4"});
            table6.AddRow(new string[] {
                        "test5",
                        "history5"});
            table6.AddRow(new string[] {
                        "test6",
                        "history6"});
            table6.AddRow(new string[] {
                        "test7",
                        "history7"});
            table6.AddRow(new string[] {
                        "test8",
                        "history8"});
#line 48
 testRunner.Given("I create the following places", ((string)(null)), table6, "Given ");
#line 58
 testRunner.When("I get 3 places skipping 3 and store them", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "history"});
            table7.AddRow(new string[] {
                        "test4",
                        "history4"});
            table7.AddRow(new string[] {
                        "test5",
                        "history5"});
            table7.AddRow(new string[] {
                        "test6",
                        "history6"});
#line 59
 testRunner.Then("I expect the stored places to contain the following", ((string)(null)), table7, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion

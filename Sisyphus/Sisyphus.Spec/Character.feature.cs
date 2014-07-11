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
    [NUnit.Framework.DescriptionAttribute("Character")]
    public partial class CharacterFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Character.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Character", "In order to have a story there needs to be characters interacting\r\nAs a writer\r\nI" +
                    " want to be able to create and make characters interact", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("Create a Character with a back story")]
        public virtual void CreateACharacterWithABackStory()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create a Character with a back story", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.Given("I have created a test database called \"characterTest\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "backstory",
                        "race",
                        "sex"});
            table1.AddRow(new string[] {
                        "jim",
                        "is some dude",
                        "last",
                        "kinda"});
#line 8
 testRunner.When("I create the following characters", ((string)(null)), table1, "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "backstory",
                        "race",
                        "sex"});
            table2.AddRow(new string[] {
                        "jim",
                        "is some dude",
                        "last",
                        "kinda"});
#line 11
 testRunner.Then("I expect the following characters to exist", ((string)(null)), table2, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Move a character to a location")]
        public virtual void MoveACharacterToALocation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Move a character to a location", ((string[])(null)));
#line 15
this.ScenarioSetup(scenarioInfo);
#line 16
 testRunner.Given("I have created a test database called \"characterTest\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "history"});
            table3.AddRow(new string[] {
                        "testPlace",
                        "noneZ"});
            table3.AddRow(new string[] {
                        "testplace2",
                        "noneZ"});
#line 17
 testRunner.And("I havecreated the following places", ((string)(null)), table3, "And ");
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
#line 21
 testRunner.And("I create the following characters", ((string)(null)), table4, "And ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "bit",
                        "bitvalue"});
            table5.AddRow(new string[] {
                        "0",
                        "1"});
#line 24
 testRunner.When("I create a journey for character to place \"testplace2\" in time called \"journey1\" " +
                    "with description \"a test journey\"", ((string)(null)), table5, "When ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "bit",
                        "bitvalue"});
            table6.AddRow(new string[] {
                        "0",
                        "2"});
#line 27
 testRunner.And("I wait for a time period", ((string)(null)), table6, "And ");
#line 30
 testRunner.Then("I expect character \"jim\" to be at place \"testplace2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Take a character moving to a location and split journey into 2")]
        public virtual void TakeACharacterMovingToALocationAndSplitJourneyInto2()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Take a character moving to a location and split journey into 2", ((string[])(null)));
#line 32
this.ScenarioSetup(scenarioInfo);
#line 33
 testRunner.Given("I have created a test database called \"characterTest\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "history"});
            table7.AddRow(new string[] {
                        "testPlace",
                        "noneZ"});
            table7.AddRow(new string[] {
                        "testplace2",
                        "noneZ"});
            table7.AddRow(new string[] {
                        "testplace3",
                        "noneZ"});
#line 34
 testRunner.And("I havecreated the following places", ((string)(null)), table7, "And ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "bit",
                        "bitValue",
                        "bitText"});
            table8.AddRow(new string[] {
                        "0",
                        "0",
                        "0"});
            table8.AddRow(new string[] {
                        "0",
                        "1",
                        "1"});
            table8.AddRow(new string[] {
                        "0",
                        "2",
                        "2"});
            table8.AddRow(new string[] {
                        "0",
                        "3",
                        "3"});
            table8.AddRow(new string[] {
                        "0",
                        "4",
                        "4"});
            table8.AddRow(new string[] {
                        "0",
                        "5",
                        "5"});
#line 39
 testRunner.And("I create a time system with the following members", ((string)(null)), table8, "And ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "bit",
                        "bitvalue"});
            table9.AddRow(new string[] {
                        "0",
                        "0"});
#line 47
 testRunner.And("I set the time to", ((string)(null)), table9, "And ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "backstory",
                        "race",
                        "sex"});
            table10.AddRow(new string[] {
                        "jim",
                        "is some dude",
                        "last",
                        "kinda"});
#line 50
 testRunner.And("I create the following characters", ((string)(null)), table10, "And ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "bit",
                        "bitvalue"});
            table11.AddRow(new string[] {
                        "0",
                        "5"});
#line 53
 testRunner.And("I create a journey for character to place \"testplace2\" in time called \"journey1\" " +
                    "with description \"a test journey\"", ((string)(null)), table11, "And ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "bit",
                        "bitvalue"});
            table12.AddRow(new string[] {
                        "0",
                        "2"});
#line 56
 testRunner.When("I split journey \"journey1\" at time into \"journey1\" description \"first part\" and \"" +
                    "journey2\" description \"second part\"", ((string)(null)), table12, "When ");
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "startTime",
                        "duration",
                        "description"});
            table13.AddRow(new string[] {
                        "journey1",
                        "0",
                        "2",
                        "first part"});
            table13.AddRow(new string[] {
                        "journey2",
                        "2",
                        "3",
                        "second part"});
#line 59
 testRunner.Then("I expect character \"jim\" to have the following journeys", ((string)(null)), table13, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion

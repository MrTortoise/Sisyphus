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
    [NUnit.Framework.DescriptionAttribute("CharacterBrowserWriter")]
    public partial class CharacterBrowserWriterFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CharacterBrowserWriter.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CharacterBrowserWriter", "In order to view a story from a character centric perspective or just explore a c" +
                    "haracter\r\nAs a writer \r\nI want to Create and edit characters", ProgrammingLanguage.CSharp, ((string[])(null)));
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
 testRunner.And("I have created a test database called \"characterBrowserTest\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
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
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "backStory"});
            table2.AddRow(new string[] {
                        "test1",
                        "ooo itS BACK STORY"});
            table2.AddRow(new string[] {
                        "test2",
                        "COR HE THINKS ITS A WEAL STOWY"});
#line 22
 testRunner.And("I have created the stories", ((string)(null)), table2, "And ");
#line 26
 testRunner.And("I select the story \"test1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "history"});
            table3.AddRow(new string[] {
                        "test1",
                        "history1"});
#line 27
 testRunner.And("I create the following places", ((string)(null)), table3, "And ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "backstory"});
            table4.AddRow(new string[] {
                        "foot",
                        "bulling you rleg"});
#line 30
 testRunner.And("I create the following races", ((string)(null)), table4, "And ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "description"});
            table5.AddRow(new string[] {
                        "rarley",
                        "nto often"});
            table5.AddRow(new string[] {
                        "bannanas",
                        "yellowZ"});
#line 33
 testRunner.And("I create the following sexes", ((string)(null)), table5, "And ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "backstory",
                        "race",
                        "sex",
                        "place"});
            table6.AddRow(new string[] {
                        "jim",
                        "none",
                        "foot",
                        "rarley",
                        "somewhere"});
            table6.AddRow(new string[] {
                        "jim2",
                        "none",
                        "foot",
                        "bannanas",
                        "somewhere"});
            table6.AddRow(new string[] {
                        "jim3",
                        "none",
                        "foot",
                        "rarley",
                        "somewhere"});
            table6.AddRow(new string[] {
                        "jim4",
                        "none",
                        "foot",
                        "bannanas",
                        "somewhere"});
#line 37
 testRunner.And("I create the following characters", ((string)(null)), table6, "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Open character browser and look at characters")]
        public virtual void OpenCharacterBrowserAndLookAtCharacters()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Open character browser and look at characters", ((string[])(null)));
#line 44
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 45
 testRunner.When("I open the view Character Browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "backstory",
                        "race",
                        "sex"});
            table7.AddRow(new string[] {
                        "jim",
                        "none",
                        "foot",
                        "rarley"});
            table7.AddRow(new string[] {
                        "jim2",
                        "none",
                        "foot",
                        "bannanas"});
            table7.AddRow(new string[] {
                        "jim3",
                        "none",
                        "foot",
                        "rarley"});
            table7.AddRow(new string[] {
                        "jim4",
                        "none",
                        "foot",
                        "bannanas"});
#line 46
 testRunner.Then("I expect the character browser to contain the following characters", ((string)(null)), table7, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Open a specific character from the browser")]
        public virtual void OpenASpecificCharacterFromTheBrowser()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Open a specific character from the browser", ((string[])(null)));
#line 53
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 54
 testRunner.Given("I open the view Character Browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 55
 testRunner.When("I select the character \"jim\" in the character browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 56
 testRunner.Then("I expect the chatacter \"jim\" to be the Character Details views subject", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Open a character in the editor")]
        public virtual void OpenACharacterInTheEditor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Open a character in the editor", ((string[])(null)));
#line 58
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 59
 testRunner.Given("I open the character editor with \"jim\" selected", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "backstory",
                        "race",
                        "sex"});
            table8.AddRow(new string[] {
                        "jim",
                        "none",
                        "foot",
                        "rarley"});
#line 60
 testRunner.Then("I expect the following character to be int he editor", ((string)(null)), table8, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "backstory"});
            table9.AddRow(new string[] {
                        "foot",
                        "bulling you rleg"});
#line 63
 testRunner.And("I expect the races to be the following", ((string)(null)), table9, "And ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "description"});
            table10.AddRow(new string[] {
                        "rarley",
                        "nto often"});
            table10.AddRow(new string[] {
                        "bannanas",
                        "yellowZ"});
#line 66
 testRunner.And("I expect the sexes to the be the following", ((string)(null)), table10, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Edit a character, save and confirm changtes")]
        public virtual void EditACharacterSaveAndConfirmChangtes()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Edit a character, save and confirm changtes", ((string[])(null)));
#line 71
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 72
 testRunner.Given("I open the character editor with \"jim\" selected", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 73
 testRunner.When("I save that character with info name \"test\" backstory \"test\" raceid \"1\" and sexid" +
                    " \"2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "backstory",
                        "race",
                        "sex"});
            table11.AddRow(new string[] {
                        "test",
                        "test",
                        "foot",
                        "bannanas"});
#line 74
 testRunner.Then("I expect the following characters to exist", ((string)(null)), table11, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion

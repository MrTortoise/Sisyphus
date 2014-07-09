namespace Sisyphus.Spec
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using Sisyphus.Core;

    using TechTalk.SpecFlow;

    [Binding]
    public class ConfigSteps
    {
        [Given(@"I have set up configuration to use testConfig")]
        public void GivenIHaveSetUpConfigurationToUseTestConfig()
        {
            Config.Source = new TestConfigSource();
        }

        [Given(@"I set the config key ""(.*)"" to ""(.*)""")]
        public void GivenISetTheConfigKeyTo(string key, string value)
        {
            var source = (TestConfigSource)Config.Source;
            source.Set(key, value);
        }

    }

    public class TestConfigSource : IConfigSource
    {
        private readonly Dictionary<string,string> values = new Dictionary<string, string>();

        public const string SqlInstance = "SqlInstance";

        public void Set(string key, string value)
        {
            this.values.Add(key, value);
        }

        public string Get(string key)
        {
            switch (key)
            {
                case Config.ConnectionStringName:
                {
                    throw new InvalidOperationException("use connection string for connection strings");
                }
            }

            if (values.ContainsKey(key))
            {
                return values[key];
            }

            throw new ArgumentOutOfRangeException("key", "didnt match any expected config values");
        }

        public ConnectionStringSettings GetConnectionString(string key)
        {
            string serverAddress = ConfigurationManager.AppSettings[SqlInstance];
            var database = (string)ScenarioContext.Current[DatabaseSteps.DatabaseName];

            string conString = DatabaseSteps.CreateConnectionString(serverAddress, database);
            return new ConnectionStringSettings("test", conString);
        }
    }
}
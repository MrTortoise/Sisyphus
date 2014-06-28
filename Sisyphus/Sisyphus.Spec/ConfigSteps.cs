using System;
using TechTalk.SpecFlow;

namespace Sisyphus.Spec
{
    using System.Configuration;

    using Sisyphus.Core;

    [Binding]
    public class ConfigSteps
    {
        [Given(@"I have set up configuration to use testConfig")]
        public void GivenIHaveSetUpConfigurationToUseTestConfig()
        {
            Config.Source = new TestConfigSource();
        }
    }

    public class TestConfigSource : IConfigSource
    {
        public const string SqlInstance = "SqlInstance";

        public string Get(string key)
        {
            switch (key)
            {
                case Config.ConnectionStringName:
                {
                    throw new InvalidOperationException("use connection string for connection strings");
                }
            }

            throw new ArgumentOutOfRangeException("key", "didnt match any expected config values");
        }

        public ConnectionStringSettings GetConnectionString(string key)
        {
            var serverAddress = ConfigurationManager.AppSettings[SqlInstance];
            var database = (string)ScenarioContext.Current[DatabaseSteps.DatabaseName];

            string conString = DatabaseSteps.CreateConnectionString(serverAddress, database);
            return new ConnectionStringSettings("test", conString);
        }
    }
}

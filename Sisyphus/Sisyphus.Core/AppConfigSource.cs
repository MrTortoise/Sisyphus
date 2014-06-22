namespace Sisyphus.Core
{
    using System.Configuration;

    class AppConfigSource : IConfigSource
    {
        public string Get(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
namespace Sisyphus.Core
{
    using System.Configuration;

    public class AppConfigSource : IConfigSource
    {
        #region Public Methods and Operators

        public string Get(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public ConnectionStringSettings GetConnectionString(string key)
        {
            return ConfigurationManager.ConnectionStrings[key];
        }

        #endregion
    }
}
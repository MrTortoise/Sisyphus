namespace Sisyphus.Core
{
    using System.Configuration;

  public  class AppConfigSource : IConfigSource
    {
        public string Get(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

      public ConnectionStringSettings GetConnectionString(string key)
      {
          return ConfigurationManager.ConnectionStrings[key];
      }
    }
}
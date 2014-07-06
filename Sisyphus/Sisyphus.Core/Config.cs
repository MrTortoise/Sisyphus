namespace Sisyphus.Core
{
    using System;
    using System.Configuration;
    using System.Diagnostics;

    public static class Config
    {
        #region Constants

        public const string ConnectionStringName = "DefaultConnection";

        #endregion

        #region Public Properties

        public static IConfigSource Source { get; set; }

        #endregion

        #region Public Methods and Operators

        public static string Get(string key)
        {
            return Source.Get(key);
        }

        public static string GetConnectionString()
        {
            ConnectionStringSettings connectionStringSettings = GetConnectionStringSettings(ConnectionStringName);
            if (connectionStringSettings == null)
            {
                throw new InvalidOperationException(
                    "Connection string settings was null. Type of Source is: " + Source.GetType().ToString()
                    + "Connection string name: " + ConnectionStringName);
            }
            var conString = connectionStringSettings.ConnectionString;
            return conString;
        }

        #endregion

        #region Methods

        private static ConnectionStringSettings GetConnectionStringSettings(string key)
        {
            if (Source == null)
            {
                Debug.WriteLine("Config source was null settign to default");
                Source = new AppConfigSource();
            }

            return Source.GetConnectionString(key);
        }

        #endregion
    }
}
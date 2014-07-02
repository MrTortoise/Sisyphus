namespace Sisyphus.Core
{
    using System.Configuration;

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
            return GetConnectionStringSettings(ConnectionStringName).ConnectionString;
        }

        #endregion

        #region Methods

        private static ConnectionStringSettings GetConnectionStringSettings(string key)
        {
            return Source.GetConnectionString(key);
        }

        #endregion
    }
}
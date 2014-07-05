namespace Sisyphus.Core
{
    using System;
    using System.Configuration;

    public static class Config
    {
        static Config()
        {
            Source = new AppConfigSource();
        }

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
            //try
            //{
                var conString = GetConnectionStringSettings(ConnectionStringName).ConnectionString;
                return conString;
            //}
            //catch (Exception)
            //{
                
            //   return @"Data Source=WINGAY-PC\SQLEXPRESS;Initial Catalog=Sisyphus;Integrated Security=True";
            //}
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
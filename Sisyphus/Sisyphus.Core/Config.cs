namespace Sisyphus.Core
{
    using System.Configuration;

    public static class Config
    {
        public const string ConnectionStringName = "DefaultConnection";

        public static IConfigSource Source { get; set; }

        public static string Get(string key)
        {
            return Source.Get(key);
        }

        private static ConnectionStringSettings GetConnectionStringSettings(string key)
        {
            return Source.GetConnectionString(key);
        }

        public static string GetConnectionString()
        {
            return GetConnectionStringSettings(Config.ConnectionStringName).ConnectionString;
        }
    }
}
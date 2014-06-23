namespace Sisyphus.Core
{
    using System.Configuration;

    public static class Config
    {
        public const string ConnectionString = "DefaultConnection";

        public static IConfigSource Source { get; set; }

        public static string Get(string key)
        {
            return Source.Get(key);
        }

        public static ConnectionStringSettings GetConnectionString(string key)
        {
            return Source.GetConnectionString(key);
        }
    }
}
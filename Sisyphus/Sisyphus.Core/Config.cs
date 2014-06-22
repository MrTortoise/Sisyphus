namespace Sisyphus.Core
{
    public static class Config
    {
        public const string ConnectionString = "connectionString";

        public static IConfigSource Source { get; set; }

        public static string Get(string key)
        {
            return Source.Get(key);
        }
    }
}
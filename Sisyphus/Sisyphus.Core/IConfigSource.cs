namespace Sisyphus.Core
{
    using System.Configuration;

    public interface IConfigSource
    {
        string Get(string key);

        ConnectionStringSettings GetConnectionString(string key);
    }
}
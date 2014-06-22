namespace Sisyphus.Core
{
    public interface IConfigSource
    {
        string Get(string key);
    }
}
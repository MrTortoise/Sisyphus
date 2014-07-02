namespace Sisyphus.Core
{
    using System.Configuration;

    public interface IConfigSource
    {
        #region Public Methods and Operators

        string Get(string key);

        ConnectionStringSettings GetConnectionString(string key);

        #endregion
    }
}
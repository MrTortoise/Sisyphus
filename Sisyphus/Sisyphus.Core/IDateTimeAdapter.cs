namespace Sisyphus.Core
{
    using System;

    public interface IDateTimeAdapter
    {
        DateTime Now { get; }
    }
}
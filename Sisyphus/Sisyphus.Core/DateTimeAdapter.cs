namespace Sisyphus.Core
{
    using System;

    public class DateTimeAdapter : IDateTimeAdapter
    {
        public DateTime Now
        {
            get
            {
                return DateTime.Now;
            }
        }
    }
}
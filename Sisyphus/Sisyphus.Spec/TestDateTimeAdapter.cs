namespace Sisyphus.Spec
{
    using System;

    using Sisyphus.Core;

    public class TestDateTimeAdapter : IDateTimeAdapter
    {
        private DateTime now;

        public DateTime Now
        {
            get
            {
                return this.now;
            }
            set
            {
                this.now = value;
            }
        }
    }
}
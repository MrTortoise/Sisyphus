namespace Sisyphus.Core.Repository
{
    public class TimeRepository
    {
        #region Fields

        private readonly SisyphusContext context;

        #endregion

        #region Constructors and Destructors

        public TimeRepository(SisyphusContext context)
        {
            this.context = context;
        }

        #endregion
    }
}
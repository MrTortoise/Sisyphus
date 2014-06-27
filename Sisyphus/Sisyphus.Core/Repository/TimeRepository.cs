namespace Sisyphus.Core.Repository
{
    public class TimeRepository
    {
        private readonly SisyphusContext context;

        public TimeRepository(SisyphusContext context)
        {
            this.context = context;
        }
    }
}
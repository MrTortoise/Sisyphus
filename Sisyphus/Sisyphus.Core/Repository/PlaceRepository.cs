namespace Sisyphus.Core.Repository
{
    using Sisyphus.Core.Model;

    public class PlaceRepository
    {
        #region Fields

        private readonly SisyphusContext context;

        #endregion

        #region Constructors and Destructors

        public PlaceRepository(SisyphusContext context)
        {
            this.context = context;
        }

        #endregion

        #region Public Methods and Operators

        public void CreatePlace(Place place)
        {
            this.context.Places.Add(place);
        }

        #endregion
    }
}
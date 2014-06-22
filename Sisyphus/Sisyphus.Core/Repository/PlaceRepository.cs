namespace Sisyphus.Core.Repository
{
    using Sisyphus.Core.Model;

    public class PlaceRepository
    {
        private readonly SisyphusContext context;

        public PlaceRepository(SisyphusContext context)
        {
            this.context = context;
        }

        public void CreatePlace(Place place)
        {
            this.context.Places.Add(place);
        }
    }
}
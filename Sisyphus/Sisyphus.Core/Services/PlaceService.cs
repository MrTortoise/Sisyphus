namespace Sisyphus.Core.Services
{
    using System.Linq;

    using Sisyphus.Core;
    using Sisyphus.Core.Model;
    using Sisyphus.Core.Repository;

    public class PlaceService
    {
        public void CreatePlace(Place place)
        {
            var conString = Config.Get(Config.ConnectionString);
            var context = new SisyphusContext(conString);
            using (var tran = context.Database.BeginTransaction())
            {
                var placeRepository = new PlaceRepository(context);
                placeRepository.CreatePlace(place);
                context.SaveChanges();
                tran.Commit();
            }
        }

        public Place GetPlace(string name)
        {
            var conString = Config.Get(Config.ConnectionString);
            var context = new SisyphusContext(conString);
            var place = context.Places.SingleOrDefault(p => p.Name.ToLower().Equals(name.ToLower()));
            return place;
        }
    }
}
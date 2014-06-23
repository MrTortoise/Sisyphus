namespace Sisyphus.Core.Services
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using Sisyphus.Core;
    using Sisyphus.Core.Model;
    using Sisyphus.Core.Repository;

    public class PlaceService
    {
        public Place CreatePlace(Place place)
        {
            var conString = Config.GetConnectionString(Config.ConnectionString);
            var context = new SisyphusContext(conString.ConnectionString);
            using (var tran = context.Database.BeginTransaction())
            {
                var placeRepository = new PlaceRepository(context);
                placeRepository.CreatePlace(place);
                context.SaveChanges();
                tran.Commit();
            }

            return place;
        }

        public Place GetPlace(string name)
        {
            var conString = Config.GetConnectionString(Config.ConnectionString);
            var context = new SisyphusContext(conString.ConnectionString);
            var place = context.Places.SingleOrDefault(p => p.Name.ToLower().Equals(name.ToLower()));
            return place;
        }

        public Place GetPlace(int id)
        {
            var conString = Config.GetConnectionString(Config.ConnectionString);
            var context = new SisyphusContext(conString.ConnectionString);
            var place = context.Places.SingleOrDefault(p => p.Id == id);
            return place;
        }

        public List<Place> Places(int skip, int pageSize)
        {
            var conString = Config.GetConnectionString(Config.ConnectionString);
            var context = new SisyphusContext(conString.ConnectionString);
            var places = context.Places.OrderBy(i => i.Name).Skip(skip).Take(pageSize);
            return places.ToList();
        }

        public void EditPlace(Place place)
        {
            var conString = Config.GetConnectionString(Config.ConnectionString);
            var context = new SisyphusContext(conString.ConnectionString);
            using (var tran = context.Database.BeginTransaction())
            {
                context.Entry(place).State = EntityState.Modified;
                context.SaveChanges();
                tran.Commit();
            }
        }

        public void Delete(Place place)
        {
            var conString = Config.GetConnectionString(Config.ConnectionString);
            var context = new SisyphusContext(conString.ConnectionString);
            using (var tran = context.Database.BeginTransaction())
            {
                context.Entry(place).State = EntityState.Deleted;
                context.SaveChanges();
                tran.Commit();
            }
        }
    }
}
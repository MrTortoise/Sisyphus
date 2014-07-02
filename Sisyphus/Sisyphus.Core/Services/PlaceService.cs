namespace Sisyphus.Core.Services
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using Sisyphus.Core.Model;
    using Sisyphus.Core.Repository;

    public class PlaceService
    {
        #region Public Methods and Operators

        public Place CreatePlace(Place place)
        {
            string conString = Config.GetConnectionString();
            var context = new SisyphusContext(conString);
            using (DbContextTransaction tran = context.Database.BeginTransaction())
            {
                var placeRepository = new PlaceRepository(context);
                placeRepository.CreatePlace(place);
                context.SaveChanges();
                tran.Commit();
            }

            return place;
        }

        public void Delete(Place place)
        {
            string conString = Config.GetConnectionString();
            var context = new SisyphusContext(conString);
            using (DbContextTransaction tran = context.Database.BeginTransaction())
            {
                context.Entry(place).State = EntityState.Deleted;
                context.SaveChanges();
                tran.Commit();
            }
        }

        public void EditPlace(Place place)
        {
            string conString = Config.GetConnectionString();
            var context = new SisyphusContext(conString);
            using (DbContextTransaction tran = context.Database.BeginTransaction())
            {
                context.Entry(place).State = EntityState.Modified;
                context.SaveChanges();
                tran.Commit();
            }
        }

        public Place GetPlace(string name)
        {
            string conString = Config.GetConnectionString();
            var context = new SisyphusContext(conString);
            Place place = context.Places.SingleOrDefault(p => p.Name.ToLower().Equals(name.ToLower()));
            return place;
        }

        public Place GetPlace(int id)
        {
            string conString = Config.GetConnectionString();
            var context = new SisyphusContext(conString);
            Place place = context.Places.SingleOrDefault(p => p.Id == id);
            return place;
        }

        public List<Place> Places(int skip, int pageSize)
        {
            string conString = Config.GetConnectionString();
            var context = new SisyphusContext(conString);
            IQueryable<Place> places = context.Places.OrderBy(i => i.Name).Skip(skip).Take(pageSize);
            return places.ToList();
        }

        #endregion
    }
}
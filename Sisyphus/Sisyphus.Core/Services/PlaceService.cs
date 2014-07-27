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

        public Place CreatePlace(Place place, string userName)
        {
            string conString = Config.GetConnectionString();
            var context = new SisyphusContext(conString);
            using (DbContextTransaction tran = context.Database.BeginTransaction())
            {
                var placeRepository = new PlaceRepository(context);
                var session = context.GetSessionForUser(userName);
                place.Story = session.Story;
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
            using (var context = new SisyphusContext(conString))
            {
                using (DbContextTransaction tran = context.Database.BeginTransaction())
                {
                    context.Entry(place).State = EntityState.Modified;
                    context.SaveChanges();
                    tran.Commit();
                }
            }
        }

        public Place GetPlace(string name,string userName)
        {
            string conString = Config.GetConnectionString();
            Place place;
            using (var context = new SisyphusContext(conString))
            {
                var session = context.GetSessionForUser(userName);
                place =
                    context.Places.SingleOrDefault(
                        p => p.Name.ToLower().Equals(name.ToLower()) && p.StoryId == session.StoryId);
            }
            return place;
        }

        public Place GetPlace(int id, string userName)
        {
            string conString = Config.GetConnectionString();
            Place place;
            using (var context = new SisyphusContext(conString))
            {
                var session = context.GetSessionForUser(userName);
                place = context.Places.SingleOrDefault(p => p.Id == id && p.StoryId == session.StoryId);
            }
            return place;
        }

        public List<Place> Places(int skip, int pageSize, string userName)
        {
            string conString = Config.GetConnectionString();
            using (var context = new SisyphusContext(conString))
            {
                var session = context.GetSessionForUser(userName);

                IQueryable<Place> places =
                    context.Places.Where(p => p.Story.Id == session.StoryId)
                        .OrderBy(i => i.Name)
                        .Skip(skip)
                        .Take(pageSize);
                return places.ToList();
            }
        }

        #endregion

        public List<Place> GetPlaces(string userName)
        {
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                var session = context.GetSessionForUser(userName);
                var places = context.Places.Where(p => p.StoryId == session.StoryId).ToList();
                return places;
            }
        }
    }
}
namespace Sisyphus.Core.Services
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using Sisyphus.Core.Model;
    using Sisyphus.Core.Repository;

    public class RaceService
    {
        public void CreateRace(string name, string backStory, string userName)
        {
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                var session = context.GetSessionForUser(userName);
                var race = new Race() { BackStory = backStory, Name = name, Story = session.Story };
                context.Races.Add(race);
                context.SaveChanges();
            }
        }

        public List<Race> GetRaces(string userName)
        {
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                var session = context.GetSessionForUser(userName);
                var races = context.Races.Where(r => r.Story.Id == session.StoryId);
                return races.ToList();
            }
        }

        public Race GetRace(string userName)
        {
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                var session = context.GetSessionForUser(userName);
                var race = context.Races.SingleOrDefault(r => r.Story.Id == session.StoryId);
                return race;
            }
        }

        public void EditRace(Race race, string userName)
        {
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    context.Races.Attach(race);
                    context.Entry(race).State = EntityState.Modified;
                    context.SaveChanges();
                    tran.Commit();
                }
            }
        }
    }
}
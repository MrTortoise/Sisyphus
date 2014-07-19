namespace Sisyphus.Core.Services
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Security.Cryptography;
    using System.Security.Policy;

    using Sisyphus.Core.Model;
    using Sisyphus.Core.Repository;

    public class EventService
    {
        public GameEvent CreateEvent(
            string name,
            string description,
            List<string> outcomes,
            List<string> places,
            int duration,
            List<string> characters,
            EventType eventType,
            string userName)
        {
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    var placeEntities = context.Places.Where(p => places.Contains(p.Name)).ToList();
                    var characterEntities = context.Characters.Where(c => characters.Contains(c.Name)).ToList();
                    var outcomeEntities = outcomes.Select(o => new Outcome() { Name = o }).ToList();

                    var session = context.GetSessionForUser(userName);

                    var gameEvent = new GameEvent()
                                    {
                                        Name = name,
                                        Description = description,
                                        Outcomes = new HashSet<Outcome>(outcomeEntities),
                                        Places = new HashSet<Place>(placeEntities),
                                        Duration = duration,
                                        Characters = new HashSet<Character>(characterEntities),
                                        EventType = eventType,
                                        Story = session.Story
                                    };
                    context.GameEvents.Add(gameEvent);
                    context.SaveChanges();
                    tran.Commit();

                    return gameEvent;
                }
            }
        }

        public GameEvent AddCharacterToEvent(string characterName, GameEvent gameEvent)
        {
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    var character = context.Characters.SingleOrDefault(c => c.Name == characterName);
                    context.GameEvents.Attach(gameEvent);
                    gameEvent.Characters.Add(character);
                    context.Entry(gameEvent).State = EntityState.Modified;
                    context.SaveChanges();
                    tran.Commit();
                    return gameEvent;
                }
            }
        }

        public GameEvent GetEvent(string eventName, string userName)
        {
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                var session = context.GetSessionForUser(userName);
                var retVal =
                    context.GameEvents.Where(e => e.Name == eventName && e.StoryId == session.StoryId)
                        .Include(e => e.Outcomes)
                        .Include(e => e.Places)
                        .Include(e => e.Characters)
                        .SingleOrDefault();
                return retVal;
            }
        }

        public List<GameEvent> GetEvents(string userName)
        {
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                var session = context.GetSessionForUser(userName);
                var events =
                    context.GameEvents.Where(e => e.StoryId == session.StoryId)
                        .Include(e => e.Outcomes)
                        .Include(e => e.Places)
                        .Include(e => e.Characters)
                        .OrderBy(e => e.Name);
                return events.ToList();
            }
        }

        public void Delete(string name, string userName)
        {
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    var session = context.GetSessionForUser(userName);
                    var gameEvent = context.GameEvents.Single(e => e.Name == name && session.StoryId == e.StoryId);
                    var outcomes = gameEvent.Outcomes.ToList();
                    foreach (var outcome in outcomes)
                    {
                        gameEvent.Outcomes.Remove(outcome);
                        context.Outcomes.Remove(outcome);
                    }

                    context.Entry(gameEvent).State = EntityState.Deleted;
                    context.SaveChanges();
                    tran.Commit();
                }
            }
        }

        public void Delete(GameEvent model)
        {
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    context.Entry(model).State = EntityState.Deleted;
                    context.SaveChanges();
                    tran.Commit();
                }
            }
        }
    }
}

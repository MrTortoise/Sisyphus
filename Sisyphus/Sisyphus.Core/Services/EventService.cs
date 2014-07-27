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
        //public GameEvent CreateEvent(
        //    string name,
        //    string description,
        //    List<string> outcomes,
        //    List<string> places,
        //    int duration,
        //    List<string> characters,
        //    EventType eventType,
        //    string userName)
        //{
        //    var conStr = Config.GetConnectionString();
        //    using (var context = new SisyphusContext(conStr))
        //    {
        //        using (var tran = context.Database.BeginTransaction())
        //        {
        //            var placeEntities = context.Places.Where(p => places.Contains(p.Name)).ToList();
        //            var characterEntities = context.Characters.Where(c => characters.Contains(c.Name)).ToList();
        //            var outcomeEntities = outcomes.Select(o => new Outcome() {Name = o}).ToList();

        //            var session = context.GetSessionForUser(userName);

        //            var gameEvent = new GameEvent()
        //            {
        //                Name = name,
        //                Description = description,
        //                Outcomes = new HashSet<Outcome>(outcomeEntities),
        //                Places = new HashSet<Place>(placeEntities),
        //                Duration = duration,
        //                Characters = new HashSet<Character>(characterEntities),
        //                EventType = eventType,
        //                Story = session.Story
        //            };
        //            context.GameEvents.Add(gameEvent);
        //            context.SaveChanges();
        //            tran.Commit();

        //            return gameEvent;
        //        }
        //    }
        //}



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
                        .Include(e => e.Characters.Select(c=>c.Race))
                         .Include(e => e.Characters.Select(c=>c.Sex))
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
                    var gameEvent = context.GameEvents.Single(e => e.Id == model.Id);
                    var outcomes = gameEvent.Outcomes.ToList();
                    foreach (var outcome in outcomes)
                    {
                        context.Outcomes.Remove(outcome);
                    }
                    context.GameEvents.Remove(gameEvent);
                    context.SaveChanges();
                    tran.Commit();
                }
            }
        }


        public GameEvent AddCharacterToEvent(int characterId, int eventId)
        {
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                var gameEvent = context.GameEvents.Single(e => e.Id == eventId);

                if (gameEvent.Characters.All(c => c.Id != characterId))
                {
                    var character = context.Characters.Single(c => c.Id == characterId);
                    gameEvent.Characters.Add(character);
                }

                context.SaveChanges();

                return gameEvent;
            }
        }

        public GameEvent RemoveCharacterFromEvent(int eventId, int characterId)
        {
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                var gameEvent = context.GameEvents.Single(e => e.Id == eventId);

                if (gameEvent.Characters.Any(c => c.Id == characterId))
                {
                    var character = context.Characters.Single(c => c.Id == characterId);
                    gameEvent.Characters.Remove(character);
                }

                context.SaveChanges();
                return gameEvent;
            }
        }

        public GameEvent CreateEvent(string eventName, string description, int duration, EventType eventType,
            List<string> outcomes, string userName)
        {
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    var gameEvent = new GameEvent()
                    {
                        Name = eventName,
                        Description = description,
                        EventType = eventType,
                        Duration = duration
                    };
                    var session = context.GetSessionForUser(userName);

                    gameEvent.Story = session.Story;
                    context.GameEvents.Add(gameEvent);

                    foreach (var outcome in outcomes)
                    {
                        var o = new Outcome()
                        {
                            GameEvent = gameEvent,
                            Name = outcome
                        };

                        context.Outcomes.Add(o);
                    }

                    context.SaveChanges();
                    tran.Commit();

                    return gameEvent;
                }
            }
        }

        public GameEvent UpdateEvent(int gameEventId, string name, string description, int duration, EventType eventType,
            string outcomes)
        {
            var outcomeNameList = outcomes.Split(',');
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    var ge = context.GameEvents.Single(e => e.Id == gameEventId);
                    var eventOutcomes = ge.Outcomes.ToList();

                    //remove deleted
                    var deleted = eventOutcomes.Where(o => !outcomeNameList.Contains(o.Name));
                    foreach (var delItem in deleted)
                    {
                        ge.Outcomes.Remove(delItem);
                        context.Outcomes.Remove(delItem);
                    }

                    //add new
                    var added = outcomeNameList.Where(i => !eventOutcomes.Select(o => o.Name).Contains(i));
                    foreach (var i in added)
                    {
                        var add = new Outcome() {GameEvent = ge, Name = i, GameEventId = ge.Id};
                        context.Outcomes.Add(add);
                    }

                    ge.Name = name;
                    ge.Description = description;
                    ge.EventType = eventType;
                    ge.Duration = duration;

                    context.SaveChanges();
                    tran.Commit();
                    return ge;
                }
            }
        }

        public GameEvent AddPlaceToEvent(int eventId, int placeId)
        {
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                var gameEvent = context.GameEvents.Single(e => e.Id == eventId);

                if (gameEvent.Places.All(p => p.Id != eventId))
                {
                    var place= context.Places.Single(c => c.Id == placeId);
                    gameEvent.Places.Add(place);
                }

                context.SaveChanges();

                return gameEvent;
            }
        }

        public GameEvent RemovePlaceFromEvent(int eventId, int placeId)
        {
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                var gameEvent = context.GameEvents.Single(e => e.Id == eventId);

                if (gameEvent.Places.Any(c => c.Id == placeId))
                {
                    var place = context.Places.Single(c => c.Id == placeId);
                    gameEvent.Places.Remove(place);
                }

                context.SaveChanges();
                return gameEvent;
            }
        }
    }
}

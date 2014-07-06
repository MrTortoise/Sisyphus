namespace Sisyphus.Core.Services
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Security.Cryptography;

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
            EventType eventType)
        {
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    var placeEntities = context.Places.Where(p => places.Contains(p.Name)).ToList();
                    var characterEntities = context.Characters.Where(c => characters.Contains(c.Name)).ToList();
                    var outcomeEntities = outcomes.Select(o => new Outcome(o)).ToList();

                    var gameEvent = new GameEvent(
                        name,
                        description,
                        outcomeEntities,
                        placeEntities,
                        duration,
                        characterEntities,
                        eventType);
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
                    gameEvent.CharacterEntities.Add(character);
                    context.Entry(gameEvent).State = EntityState.Modified;
                    context.SaveChanges();
                    tran.Commit();
                    return gameEvent;
                }
            }
        }

        public GameEvent GetEvent(string eventName)
        {
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                var retVal = context.GameEvents.SingleOrDefault(e => e.Name == eventName);
                return retVal;
            }
        }
    }
}

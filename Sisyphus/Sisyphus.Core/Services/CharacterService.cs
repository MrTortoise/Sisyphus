namespace Sisyphus.Core.Services
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using Sisyphus.Core.Model;
    using Sisyphus.Core.Repository;

    public class CharacterService
    {
        private const string ThePlaceDoesNotExist = "the place: {0} Does not exist";

        public void CreateChraracter(string name, string backStory, int raceId, int sexId, string userName)
        {
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                var session = context.GetSessionForUser(userName);

                using (var tran = context.Database.BeginTransaction())
                {
                    var R = context.Races.Single(r => r.Id == raceId && r.StoryId == session.StoryId);
                    var S = context.Sexes.Single(s => s.Id == sexId && s.StoryId == session.StoryId);
                    var character = new Character()
                                    {
                                        Name = name,
                                        BackStory = backStory,
                                        Race = R,
                                        Sex = S,
                                        Story = session.Story
                                    };
                    context.Characters.Add(character);
                    context.SaveChanges();
                    tran.Commit();
                }
            }
        }

        public List<Character> GetCharacters(string userName)
        {
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                var session = context.GetSessionForUser(userName);

                var characters =
                    context.Characters.Include(c => c.Sex)
                        .Include(c => c.Race)
                        .Include(c => c.Story)
                        .Where(c => c.Story.Id == session.StoryId)
                        .ToList();

                return characters;
            }
        }

        public Character GetCharacter(string character, string userName)
        {
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                var session = context.GetSessionForUser(userName);
                var ch =
                    context.Characters.Include(c => c.Sex)
                        .Include(c => c.Race)
                        .Include(c => c.Story)
                        .SingleOrDefault(c => c.Name == character && c.Story.Id == session.StoryId);
                return ch;
            }
        }

        public void Delete(int id)
        {
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                var character = context.Characters.Single(c => c.Id == id);
                context.Characters.Remove(character);
            }
        }

        public void Update(Character character)
        {
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                var R = context.Races.Single(r => r.Id == character.RaceId);
                var S = context.Sexes.Single(s => s.Id == character.SexId);
                var story = context.Stories.Single(s => s.Id == character.StoryId);
                character.Race = R;
                character.Sex = S;
                character.Story = story;
                context.Entry(character).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
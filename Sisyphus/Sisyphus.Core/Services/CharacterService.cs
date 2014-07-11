namespace Sisyphus.Core.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Sisyphus.Core.Model;
    using Sisyphus.Core.Repository;

    public class CharacterService
    {
        private const string ThePlaceDoesNotExist = "the place: {0} Does not exist";

        public void CreateChraracter(string name, string backStory, string race, string sex,  string userName)
        {
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                var session = context.GetSessionForUser(userName);

                using (var tran = context.Database.BeginTransaction())
                {
                    var character = new Character()
                                    {
                                        Name = name,
                                        BackStory = backStory,
                                        Race = race,
                                        Sex = sex,
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

                var characters = context.Characters.Where(c => c.Story.Id == session.StoryId).ToList();

                return characters;
            }
        }
    }
}
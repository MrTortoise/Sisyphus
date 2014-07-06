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

        public void CreateChraracter(string name, string backStory, string race, string sex, string place)
        {
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                var placeEntity = context.Places.SingleOrDefault(p => p.Name == place);
                if (placeEntity == null)
                {
                    throw new ArgumentOutOfRangeException("place",string.Format(ThePlaceDoesNotExist, place));
                }

                using (var tran = context.Database.BeginTransaction())
                {
                    var character = new Character(name, backStory, race, sex, placeEntity);
                    context.Characters.Add(character);
                    context.SaveChanges();
                    tran.Commit();
                }
            }
        }

        public List<Character> GetCharacters()
        {
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                var characters = context.Characters.ToList();
                return characters;
            }
        }
    }
}
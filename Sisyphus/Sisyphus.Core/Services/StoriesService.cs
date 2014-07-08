namespace Sisyphus.Core.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Sisyphus.Core.Model;
    using Sisyphus.Core.Repository;

    public class StoriesService
    {
        public List<Story> GetStories()
        {
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                var stories = context.Stories.ToList();
                return stories;
            }
        }

        public void CreateStory(string name, string backstory)
        {
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                context.Stories.Add(new Story() { Name = name, BackStory = backstory });
                context.SaveChanges();
            }
        }
    }
}
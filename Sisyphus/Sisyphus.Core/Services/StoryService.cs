namespace Sisyphus.Core.Services
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using Sisyphus.Core.Model;
    using Sisyphus.Core.Repository;

    public class StoryService
    {
        public const string StoryStartString = "Story Start";

        public void CreateStory(string name, string backstory, string userName)
        {
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    var story = new Story() { BackStory = backstory, Name = name };
                    context.Stories.Add(story);

                    var startEvent = new GameEvent()
                                     {
                                         Description = StoryStartString,
                                         Name = StoryStartString,
                                         Story = story,
                                         EventType = EventType.StoryStart
                                     };
                    context.GameEvents.Add(startEvent);

                    var user = context.Users.Single(u => u.UserName == userName);
                    story.Users.Add(user);

                    context.SaveChanges();
                    tran.Commit();
                }
            }
        }

        public List<Story> GetStories(string userName)
        {
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                var stories = context.Stories.Where(s => s.Users.Any(u => u.UserName == userName)).ToList();
                return stories;
            }
        }

        public Story GetStory(string name, string userName)
        {
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                var story =
                    context.Stories.SingleOrDefault(s => s.Users.Any(u => u.UserName == userName) && s.Name == name);
                return story;
            }
        }

        public void UpdateStory(Story story)
        {
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                context.Entry(story).State=EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Story story)
        {
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                context.Entry(story).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
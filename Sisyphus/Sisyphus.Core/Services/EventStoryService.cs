using System.Linq;
using Sisyphus.Core.Model;
using Sisyphus.Core.Repository;

namespace Sisyphus.Core.Services
{
    public class StoryItemService
    {
        public StoryItem CreateStoryItem(string eventName, string characterName, int storyItemIndex, string text,
            StoryItemType storyItemType, string userName)
        {
            string conString = Config.GetConnectionString();
            using (var context = new SisyphusContext(conString))
            {
                var session = context.GetSessionForUser(userName);
                var ge = context.GameEvents.Single(e => e.Name == eventName && e.StoryId == session.StoryId);
                var character = context.Characters.Single(c => c.Name == characterName && c.StoryId == session.StoryId);

                var si = new StoryItem()
                {
                    GameEvent = ge,
                    Character = character,
                    ItemIndex = storyItemIndex,
                    Text = text,
                    StoryItemType = storyItemType
                };

                context.StoryItems.Add(si);
                context.SaveChanges();
            }
        }
    }
}
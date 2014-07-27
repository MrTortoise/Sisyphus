using System.Text;
using WebGrease.Css.Extensions;

namespace Sisyphus.Web.Models
{
    using System.Collections.Generic;

    using Sisyphus.Core.Model;

    public class EventIndexViewModel
    {
        private List<GameEvent> _events;

        public List<GameEvent> Events
        {
            get { return _events; }
            set
            {
                _events = value;
                OutcomeStrings = new Dictionary<string, string>();
                foreach (var gameEvent in _events)
                {
                    var outcomeString = gameEvent.ConstructOutcomeString();
                    OutcomeStrings.Add(gameEvent.Name, outcomeString);
                }
            }
        }

        public Dictionary<string, string> OutcomeStrings { get; set; }
    }
}
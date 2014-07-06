namespace Sisyphus.Web.Models
{
    using System.Collections.Generic;

    using Sisyphus.Core.Model;

    public class GameEventEditViewModel 
    {
        public List<Place> Places { get; set; }

        public List<Character> Characters { get; set; }

        public GameEvent GameEvent { get; set; }
    }
}
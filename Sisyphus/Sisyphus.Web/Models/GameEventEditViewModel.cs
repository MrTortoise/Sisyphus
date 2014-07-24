namespace Sisyphus.Web.Models
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Sisyphus.Core.Model;

    public class GameEventEditViewModel 
    {
        public GameEvent GameEvent { get; set; }

        public List<Place> Places { get; set; }

        public IEnumerable<SelectListItem> PlacesItems
        {
            get
            {
                 return new SelectList(Places, "Id", "Name");
            }
        }

        public List<Character> Characters { get; set; }

        public IEnumerable<SelectListItem> CharactersItems
        {
            get
            {
                return new SelectList(Places, "Id", "Name");
            }
        }
      
    }
}
namespace Sisyphus.Web.Models
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Sisyphus.Core.Model;

    public class CharacterEditViewModel
    {
        public Character Character { get; set; }

        public List<Sex> Sexes { get; set; }

        public List<Race> Races { get; set; }

        public IEnumerable<SelectListItem> SexListItems
        {
            get
            {
                return new SelectList(Sexes,"Id","Name");
            }
        }

        public IEnumerable<SelectListItem> RaceListItems
        {
            get
            {
                return new SelectList(Races, "Id", "Name");
            }
        }
    }
}
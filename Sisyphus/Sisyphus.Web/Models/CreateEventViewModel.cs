namespace Sisyphus.Web.Models
{
    using System.Collections.Generic;

    using Sisyphus.Core.Model;

    public class CreateEventViewModel
    {
        public List<Place> Places { get; set; }

        public List<Character> Characters { get; set; }
    }
}
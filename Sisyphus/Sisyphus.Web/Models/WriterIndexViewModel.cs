namespace Sisyphus.Web.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using Sisyphus.Core.Model;

    public class WriterIndexViewModel 
    {
        public IEnumerable<SelectListItem> StoryListItems {
            get
            {
                return new SelectList(Stories, "Name", "Name");
            }}

        public List<Story> Stories { get; set; }

        [Display(Name = "Story")]
        public string SelectedStoryName { get; set; }

        [Display(Name = "Back Story")]
        public string BackStory { get; set; }
    }
}
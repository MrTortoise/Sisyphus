namespace Sisyphus.Web.Models
{
    using System.Collections.Generic;

    using Sisyphus.Core.Model;

    public class WriterIndexViewModel 
    {
        public List<Story> Stories { get; set; }

        public Story SelectedStory { get; set; }
    }
}
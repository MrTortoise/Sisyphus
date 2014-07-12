namespace Sisyphus.Core.Model
{
    using System.ComponentModel.DataAnnotations;

    public class Race
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string BackStory { get; set; }

        public virtual Story Story { get; set; }
    }
}
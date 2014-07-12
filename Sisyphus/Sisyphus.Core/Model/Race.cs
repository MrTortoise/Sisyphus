namespace Sisyphus.Core.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Race
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(25)]
        [Column("RaceName")]
        [Index("SexUnique", 1, IsUnique = true)]
        public string Name { get; set; }

        public string BackStory { get; set; }

        public virtual Story Story { get; set; }

        [Index("SexUnique", 2, IsUnique = true)]
        public int StoryId { get; set; }
    }
}
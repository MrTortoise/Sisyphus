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
        [Index("RaceUnique", 1, IsUnique = true)]
        [Required]
        [Display(Name = "Name of Race")]
        public string Name { get; set; }

        public string BackStory { get; set; }

        [Required]
        public virtual Story Story { get; set; }

        [Index("RaceUnique", 2, IsUnique = true)]
        [Required]
        public int StoryId { get; set; }
    }
}
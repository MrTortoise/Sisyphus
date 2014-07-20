namespace Sisyphus.Core.Model
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Story
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("StoryName", TypeName = "nvarchar")]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public string BackStory { get; set; }

        public virtual ICollection<Place> Places { get; set; }
        public virtual ICollection<GameEvent> Events { get; set; }
        public virtual ICollection<TimeUnit> TimeUnits { get; set; }
        public virtual ICollection<Character> Characters { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }

        public Story()
        {
            Places = new HashSet<Place>();
            Events = new HashSet<GameEvent>();
            TimeUnits = new HashSet<TimeUnit>();
            Characters = new HashSet<Character>();
            Sessions = new HashSet<Session>();
            Users = new HashSet<ApplicationUser>();
        }

    }
}
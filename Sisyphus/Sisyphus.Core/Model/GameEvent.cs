namespace Sisyphus.Core.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class GameEvent
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Index("GameEventUnique",1,IsUnique = true)]
        [Column("GameEventName", TypeName = "nvarchar")]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Outcome> Outcomes { get; set; }

        public virtual ICollection<Place> Places { get; set; }

        [Required]
        public int Duration { get; set; }

        public virtual ICollection<Character> Characters { get; set; }

        [Required]
        public EventType EventType { get; set; }

        [Timestamp]
        public Byte[] TimeStamp { get; set; }

        public virtual Story Story { get; set; }

        [Index("GameEventUnique", 2, IsUnique = true)]
        [Required]
        public int StoryId { get; set; }
    }
}
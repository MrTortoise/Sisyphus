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
        [Index(IsUnique = true)]
        [Column("GameEventName", TypeName = "nvarchar")]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Outcome> OutcomeEntities { get; set; }

        public virtual ICollection<Place> PlaceEntities { get; set; }

        [Required]
        public int Duration { get; set; }

        public virtual ICollection<Character> CharacterEntities { get; set; }

        [Required]
        public EventType EventType { get; set; }

        [Timestamp]
        public Byte[] TimeStamp { get; set; }

        public GameEvent()
        {
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            this.OutcomeEntities = new HashSet<Outcome>();
            this.PlaceEntities = new HashSet<Place>();
            this.CharacterEntities = new HashSet<Character>();
            // ReSharper restore DoNotCallOverridableMethodsInConstructor
        }

        public GameEvent(string name, string description, List<Outcome> outcomeEntities, List<Place> placeEntities, int duration, List<Character> characterEntities, EventType eventType)
        {
            this.Name = name;
            this.Description = description;
            this.Duration = duration;
            this.EventType = eventType;

            outcomeEntities.ForEach(o => this.OutcomeEntities.Add(o));
            placeEntities.ForEach(p => this.PlaceEntities.Add(p));
            characterEntities.ForEach(c => this.CharacterEntities.Add(c));
        }
    }
}
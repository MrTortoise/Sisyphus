using System.Text;

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
        [Index("GameEventUnique", 1, IsUnique = true)]
        [Column("GameEventName", TypeName = "nvarchar")]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public int Duration { get; set; }

        //[Required]
        //public EventType EventType { get; set; }

        public virtual Story Story { get; set; }

        [Index("GameEventUnique", 2, IsUnique = true)]
        [Required]
        public int StoryId { get; set; }

        public virtual ICollection<Character> Characters { get; set; }


        [InverseProperty("TargetGameEvent")]
        public virtual ICollection<Outcome> ParentOutcomes { get; set; }

        [InverseProperty("ParentGameEvent")]
        public virtual ICollection<Outcome> TargetOutcomes { get; set; }

        public virtual ICollection<Place> Places { get; set; }

        public virtual ICollection<StoryItem> StoryItems { get; set; }

        [Timestamp]
        public Byte[] TimeStamp { get; set; }



        public GameEvent()
        {
            TargetOutcomes=new HashSet<Outcome>();
            Places = new HashSet<Place>();
            Characters=new HashSet<Character>();
        }

        public string ConstructOutcomeString()
        {
            var sb = new StringBuilder();
            TargetOutcomes.ToList().ForEach(o => sb.Append(o.Name + ", "));
            var outcomeString = sb.ToString();
            if (!string.IsNullOrWhiteSpace(outcomeString))
            {
                outcomeString = outcomeString.Substring(0, outcomeString.Length - 2);
            }

            return outcomeString;
        }
    }
}
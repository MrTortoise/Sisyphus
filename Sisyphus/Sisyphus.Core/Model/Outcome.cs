namespace Sisyphus.Core.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines an outcome of an event, used to chain events together.
    /// </summary>
    public class Outcome
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("OutcomeName",TypeName = "nvarchar")]
        public string Name { get; set; }

        public string FriendlyName { get; set; }

        [ForeignKey("ParentGameEventId")]
        [Required]
        public virtual GameEvent ParentGameEvent { get; set; }

        public int ParentGameEventId { get; set; }

        [ForeignKey("TargetGameEventId")]
        public virtual GameEvent TargetGameEvent { get; set; }

        public int TargetGameEventId { get; set; }

        [Timestamp]
        public Byte[] TimeStamp { get; set; }
    }
}
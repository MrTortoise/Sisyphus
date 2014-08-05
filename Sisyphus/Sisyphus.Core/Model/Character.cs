namespace Sisyphus.Core.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Character in a story.
    /// </summary>
    public class Character
    {
        [Key]
        public int Id { get; set; }

        public string BackStory { get; set; }

        [Required]
        public virtual Sex Sex { get; set; }

        [Required]
        public int SexId { get; set; }

        [Required]
        public virtual Race Race { get; set; }

        [Required]
        public int RaceId { get; set; }

        [Required]
        [Index("CharacterUnique", 1, IsUnique = true)]
        [MaxLength(40, ErrorMessage = "Character name length has max of 40 characters")]
        [Column("CharacterName", TypeName = "nvarchar")]
        public string Name { get; set; }

        [Timestamp]
        public Byte[] TimeStamp { get; set; }

        [Required]
        public virtual Story Story { get; set; }

        [Required]
        [Index("CharacterUnique", 2, IsUnique = true)]
        public int StoryId { get; set; }
    }
}
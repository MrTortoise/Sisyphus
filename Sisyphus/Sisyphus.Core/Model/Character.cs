namespace Sisyphus.Core.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Character
    {
        [Key]
        public int Id { get; set; }

        public string BackStory { get; set; }

        public virtual Sex Sex { get; set; }

        public virtual Race Race { get; set; }

        [Required]
        [Index("CharacterUnique", 1, IsUnique = true)]
        [MaxLength(40, ErrorMessage = "Character name length has max of 40 characters")]
        [Column("CharacterName", TypeName = "nvarchar")]
        public string Name { get; set; }

        [Timestamp]
        public Byte[] TimeStamp { get; set; }

        public virtual Story Story { get; set; }

        [Index("CharacterUnique", 2, IsUnique = true)]
        public int StoryId { get; set; }
    }
}
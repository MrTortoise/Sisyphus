using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sisyphus.Core.Model
{
    public class StoryItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Index("StoryItemUnique", 1, IsUnique = true)]
        public int GameEventId { get; set; }

        public virtual GameEvent GameEvent { get; set; }

        [Required]
        public int CharacterId { get; set; }

        public virtual Character Character { get; set; }

        [Required]
        [Index("StoryItemUnique", 2, IsUnique = true)]
        public int ItemIndex { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public StoryItemType StoryItemType { get; set; }

        [Timestamp]
        public Byte[] TimeStamp { get; set; }
    }
}
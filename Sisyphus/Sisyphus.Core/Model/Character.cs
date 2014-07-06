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

        [MaxLength(40, ErrorMessage = "Race length has max of 40 characters")]
        public string Race { get; set; }

        [MaxLength(40, ErrorMessage = "Sex length has max of 40 characters")]
        public string Sex { get; set; }

        [Required]
        public virtual Place Place { get; set; }

        [Required]
        [Index("CharacterName",IsUnique = true)]
        [MaxLength(40,ErrorMessage = "Character name length has max of 40 characters")]
        [Column("CharacterName",TypeName = "nvarchar")]
        public string Name { get; set; }

        [Timestamp]
        public Byte[] TimeStamp { get; set; }

        public Character()
        {
            
        }

        public Character(string name, string backStory, string race, string sex, Place placeEntity)
        {
            this.Name = name;
            this.BackStory = backStory;
            this.Race = race;
            this.Sex = sex;
            this.Place = placeEntity;
        }
    }
}
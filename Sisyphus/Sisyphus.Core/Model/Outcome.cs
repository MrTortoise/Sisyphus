namespace Sisyphus.Core.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Outcome
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("OutcomeName",TypeName = "nvarchar")]
        public string Name { get; set; }

        [Timestamp]
        public Byte[] TimeStamp { get; set; }

        public virtual GameEvent GameEvent { get; set; }

        public Outcome()
        {
            
        }

        public Outcome(string name)
        {
            this.Name = name;
        }
    }
}
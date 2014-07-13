using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisyphus.Core.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Sex
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(25)]
        [Column("SexName")]
        [Index("SexUnique", 1, IsUnique = true)]
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public virtual Story Story { get; set; }

        [Index("SexUnique", 2, IsUnique = true)]
        [Required]
        public int StoryId { get; set; }
    }
}

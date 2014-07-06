namespace Sisyphus.Core.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Place
    {
        #region Constructors and Destructors

        public Place()
        {
        }

        public Place(string name, string history)
        {
            this.Name = name;
            this.History = history;
        }

        #endregion

        #region Public Properties

        [Timestamp]
        public Byte[] TimeStamp { get; set; }

        /// <summary>
        ///     The history of the place, make it good.
        /// </summary>
        public string History { get; set; }

        [Key]
        public int Id { get; set; }

        /// <summary>
        ///     The name of the place
        /// </summary>
        [Required]
        [Index(IsUnique = true)]
        [Column("PlaceName",TypeName = "nvarchar")]
        [MaxLength(100)]
        public string Name { get; set; }

        

        #endregion
    }
}
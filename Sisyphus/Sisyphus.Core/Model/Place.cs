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

        #endregion

        #region Public Properties

        [Key]
        public int Id { get; set; }

        /// <summary>
        ///     The name of the place
        /// </summary>
        [Required]
        [Index(IsUnique = true)]
        [Column("PlaceName", TypeName = "nvarchar")]
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        ///     The history of the place, make it good.
        /// </summary>
        public string History { get; set; }

        /// <summary>
        /// The story the place belongs to
        /// </summary>
        public virtual Story Story { get; set; }

        /// <summary>
        /// The Id of the story the place belongs to
        /// </summary>
        public int StoryId { get; set; }

        [Timestamp]
        public Byte[] TimeStamp { get; set; }


        

        #endregion
    }
}
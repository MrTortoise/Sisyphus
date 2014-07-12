namespace Sisyphus.Core.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class TimeUnit
    {
        #region Constructors and Destructors

        public TimeUnit()
        {
        }

        public TimeUnit(int bit, int value, string text)
        {
            this.Bit = bit;
            this.Value = value;
            this.Text = text;
        }

        #endregion

        #region Public Properties

        [Timestamp]
        public Byte[] TimeStamp { get; set; }

        /// <summary>
        ///     The bit against the value is set
        /// </summary>
        [Required]
        [Index("bitValue",1,IsUnique = true)]
        public int Bit { get; set; }

        [Key]
        public int Id { get; set; }

        /// <summary>
        ///     The textual name of the bit that will be displayed.
        /// </summary>
        [Required]
        public string Text { get; set; }

        /// <summary>
        ///     The index/value of the bit
        /// </summary>
        [Required]
        [Index("bitValue", 2, IsUnique = true)]
        public int Value { get; set; }

        public virtual Story Story { get; set; }

        [Index("bitValue", 3, IsUnique = true)]
        public int StoryId { get; set; }

        #endregion
    }
}
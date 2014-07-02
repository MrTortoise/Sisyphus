namespace Sisyphus.Core.Model
{
    using System.ComponentModel.DataAnnotations;

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

        /// <summary>
        ///     The bit against the value is set
        /// </summary>
        public int Bit { get; set; }

        [Key]
        public int Id { get; set; }

        /// <summary>
        ///     The textual name of the bit that will be displayed.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        ///     The index/value of the bit
        /// </summary>
        public int Value { get; set; }

        #endregion
    }
}
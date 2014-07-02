namespace Sisyphus.Core.Model
{
    using System.ComponentModel.DataAnnotations;

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

        /// <summary>
        ///     The history of the place, make it good.
        /// </summary>
        public string History { get; set; }

        [Key]
        public int Id { get; set; }

        /// <summary>
        ///     The name of the place
        /// </summary>
        public string Name { get; set; }

        #endregion
    }
}
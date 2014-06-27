namespace Sisyphus.Core.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.Data;

    public class Place
    {
        public Place()
        {

        }

        public Place(string name, string history)
        {
            this.Name = name;
            this.History = history;
        }

        [Key]
        public int Id { get; set; }
      
        /// <summary>
        /// The name of the place
        /// </summary>
        public string Name { get;  set; }

        /// <summary>
        /// The history of the place, make it good.
        /// </summary>
        public string History { get;  set; }
    }
}
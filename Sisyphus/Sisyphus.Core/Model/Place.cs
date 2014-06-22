namespace Sisyphus.Core.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.Data;

    public class Place
    {
        [Key]
        public int Id { get; set; }
      
        public string Name { get; private set; }

        public string History { get; private set; }

        public Place()
        {
            
        }

        public Place(string name, string history)
        {
            this.Name = name;
            this.History = history;
        }
    }
}
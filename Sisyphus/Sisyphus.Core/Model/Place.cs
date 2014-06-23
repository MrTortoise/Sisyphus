namespace Sisyphus.Core.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.Data;

    public class Place
    {
        [Key]
        public int Id { get; set; }
      
        public string Name { get;  set; }

        public string History { get;  set; }

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
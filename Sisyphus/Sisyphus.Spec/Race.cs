namespace Sisyphus.Spec
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security;

    using Sisyphus.Core.Model;

    public class Race
    {
        [Key]
        public int Id
        {
            get; set;
            
        }
        public string Name { get; set; }

        public string BackStory { get; set; }

        public virtual ICollection<Story> 
        {
            get;
            {
                set;
            }
        }
    }
    }
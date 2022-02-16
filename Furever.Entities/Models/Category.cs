using System.Collections.Generic;

namespace Furever.Entities.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Species { get; set; }

        public ICollection<Animal> Animals { get; set; }
    }
}

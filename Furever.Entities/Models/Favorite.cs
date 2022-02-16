using System.ComponentModel.DataAnnotations.Schema;

namespace Furever.Entities.Models
{
    public class Favorite
    {
        [ForeignKey(nameof(Animal))]
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }


        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}

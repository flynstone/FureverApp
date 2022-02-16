using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Furever.Entities.Models
{
    public class Animal
    {
        // Primary Key
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// Link tables
        /// </summary>
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        /// <summary>
        /// Link tables
        /// </summary>
        [ForeignKey(nameof(Refuge))]
        public int RefugeId { get; set; }
        public Refuge Refuge { get; set; }
        

        // True or False
        public bool IsAvailable { get; set; }

        // Nullable DoB
        public int Age { get; set; }

        
        public DateTime CreatedDate { get; set; }

        public ICollection<Photo> Photos { get; set; }

        // Collection of user's that liked the animal
        public ICollection<Favorite> Favorites { get; set; }
    }
}

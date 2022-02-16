﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Furever.Entities.Models
{
    public class Refuge
    {
        // Primary Key
        public int Id { get; set; }

        [Required, MaxLength(50)] // Specify maximum length of the column in the db
        public string Username { get; set; }

        [Required, MaxLength(50)] 
        public string FirstName { get; set; }

        [Required, MaxLength(50)] 
        public string LastName { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        [MaxLength(50)] 
        public string City { get; set; }

        [MaxLength(100)] 
        public string Email { get; set; }

        [MaxLength(25)]
        public string Phone { get; set; }

        public ICollection<Animal> Animals { get; set; }
    }
}

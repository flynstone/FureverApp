﻿using System.Collections.Generic;

namespace Furever.Entities.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Favorite> Favorites { get; set; }
    }
}

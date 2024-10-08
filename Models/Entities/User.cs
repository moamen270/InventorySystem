﻿using Microsoft.AspNetCore.Identity;

namespace Models.Entities
{
    public class User :IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegisteredDate { get; set; }
        public string City { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }

    }
}

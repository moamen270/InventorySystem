using Microsoft.AspNetCore.Identity;

namespace Models.Entities
{
    public class Role : IdentityRole<int>
    {
        public ICollection<UserRole> UsersRole { get; set; }
    }
}

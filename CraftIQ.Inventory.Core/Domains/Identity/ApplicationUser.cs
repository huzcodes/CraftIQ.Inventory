using Microsoft.AspNetCore.Identity;

namespace CraftIQ.Inventory.Core.Domains.Identity;

    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }


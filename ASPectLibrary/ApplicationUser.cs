using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ASPectLibrary {
    public class ApplicationUser : IdentityUser {
        public ApplicationUser() : base() { }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IList<Membership> Memberships { get; set; }
        
    }
}


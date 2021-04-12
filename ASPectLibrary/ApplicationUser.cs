using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ASPectLibrary {
    public class ApplicationUser : IdentityUser {
        public ApplicationUser() : base() { 
            Enrollments = new List<Enrollment>(); 
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
        public IList<Membership> Memberships { get; set; }
        public IList<Offering> Offerings { get; set; }
    }
}
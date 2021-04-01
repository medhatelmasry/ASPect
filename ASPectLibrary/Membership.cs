using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ASPectLibrary
{
    public class Membership
    {
        public string Id { get; set; }

        [ForeignKey("Id")]
        public ApplicationUser Student { get; set; }

        public int ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
    }
    
}
using System.ComponentModel.DataAnnotations;

namespace ASPectLibrary
{
    public class ProjectRole
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string RoleName { get; set; }
    }
}
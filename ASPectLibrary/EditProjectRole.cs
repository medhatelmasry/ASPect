using System.ComponentModel.DataAnnotations;

namespace ASPectLibrary
{
    public class EditProjectRole
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string RoleName { get; set; }
    }
}
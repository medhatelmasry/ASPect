using System.ComponentModel.DataAnnotations;

namespace ASPetcLibrary
{
    public class EditProjectRole
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string RoleName { get; set; }
    }
}
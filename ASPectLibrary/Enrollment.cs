using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPectLibrary
{
    //An enrollment in an offering, a student ENROLLS to an OFFERING of a course
    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; } 
        public int OfferingId { get; set; }
        [ForeignKey("OfferingId")]
        public Offering Offering { get; set; }
        /// <summary>
        /// Id of the STUDENT (ApplicationUser).
        /// </summary>
        public string Id { get; set; }
        [ForeignKey("Id")]
        public ApplicationUser Student { get; set; }
    }
}
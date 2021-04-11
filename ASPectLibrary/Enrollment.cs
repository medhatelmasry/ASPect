using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPectLibrary
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }

        /// <summary>
        /// Id of the ApplicationUser.
        /// </summary>
        public string Id { get; set; }

        [ForeignKey("Id")]
        public ApplicationUser User { get; set; }

        public int CourseID { get; set; }

        [ForeignKey("CourseID")]
        public Course Course { get; set; }

        public string Semester { get; set; }

        public int Year { get; set; }
    }
}
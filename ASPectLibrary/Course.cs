using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ASPectLibrary {
    public class Course
    {
        public Course()
        {
            Enrollments = new List<Enrollment>();
        }
        
        public IList<Membership> Memberships { get; set; }

        [Key]
        public int CourseID{get; set;}

        public string CourseTitle{get; set;}

        public string Term{get; set;}

        public string ProjectOutline{get; set;}

        public string InstructorID {get;set;}

        [ForeignKey("Id")]
        public ApplicationUser User { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPectLibrary
{
    /// Represents a course offering ie -> Fall 2020, Winter 2021
    public class Offering
    {
        [Key]
        public int OfferingId { get; set; }
        public string Semester { get; set; }
        public DateTime Year { get; set; }

        /// Student Id
        public string StudentId { get; set; }

        [ForeignKey("StudentId")]
        public ApplicationUser User { get; set; }
        public int CourseID { get; set; }
        [ForeignKey("CourseID")]
        public Course Course { get; set; }

    }
}


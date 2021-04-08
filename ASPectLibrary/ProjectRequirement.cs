
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPectLibrary { 
    /// A class that is created and edited by an Instructor. References a project name and assignment.
    /// A Requirement belongs to an assigment, and an assigment belongs to a course.
    public class ProjectRequirement {
        /// The Project Requirement ID
        [Key]
        public int Id { get; set; }

        /// The date of creation of the requirement
        public DateTime DateCreated { get; set; }
        /// The expected due date of the requirement
        public DateTime DueDate { get; set; }
        /// A brief description of the requirement
        public string Requirement { get; set; }
        /// The id of the assignment that is being referenced
        public int AssignmentId  { get; set; }

        [ForeignKey("AssignmentId")]
        public Assignment Assignment { get; set; }
        
    }
}

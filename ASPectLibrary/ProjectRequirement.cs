
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPectLibrary { 
    /// A class that is created and edited by an Instructor. References a project name and course.
    /// It's through this name that a Course could possibly have multiple projects.
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
        /// The name of the project that is being referenced
        public string ProjectName { get; set; }
        
        /// The Id of the Course associated with the project 
        public int CourseId { get; set; }

        /// The Course that the project requirement is for
        [ForeignKey("CourseId")]
        public Course Course { get; set; }
    }
}

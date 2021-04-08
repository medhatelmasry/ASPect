
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPectLibrary { 
    /// A class that is created and edited by an Instructor. References a Course.
    /// A COURSE can have multiple ASSIGNMENTS, and an ASSIGNMENT can have multiple REQUIREMENTS.
    public class Assignment {
        /// The Assignment ID
        [Key]
        public int AssignmentId { get; set; }

        /// The date of creation of the assignment
        public DateTime DateCreated { get; set; }

        /// The expected due date of the assignment
        public DateTime DueDate { get; set; }

        /// A brief description of the assignment
        public string description { get; set; }

        /// The Id of the Course associated with the Assignment 
        public int courseId { get; set; }

        /// The Course that has the Assignment
        [ForeignKey("courseId")]
        public Course Course { get; set; }

        public List<Assignment> Assignments { get; set; }
    }
}

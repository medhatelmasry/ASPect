using System.ComponentModel.DataAnnotations;

namespace Models{
    public class Course
    {
        [Key]
        public int courseID{get; set;}
        public string courseTitle{get; set;}
        public string term{get; set;}
        public string projectOutline{get; set;}
        public AspNetUsers instructorID{get;set;}
        /**
            unsure of what course is for, but medhat seems to
            think its important so here it is.
        */
        public Course course{get; set;}
    }

}
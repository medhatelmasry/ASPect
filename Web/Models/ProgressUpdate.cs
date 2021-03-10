
using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models {
    public class ProgressUpdate {
        [Key]
        public int Id { get; set; }
        public Project Project { get; set; }
        public DateTime Date { get; set; }
        public string LastWeekActivity { get; set; }
        public string NextWeekActivity { get; set; }
        public string Issues { get; set; }
    }
}
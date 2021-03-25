using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string  TeamName { get; set; }
        public ProjectCategory ProjectCategory{ get; set; }
        public string AppName { get; set; }
        public string Description { get; set; }
        public AspNetUsers Instructor { get; set; }
        public Course Course{ get; set; }
    }
}

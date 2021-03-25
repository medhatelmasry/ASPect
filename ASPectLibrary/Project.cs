using System;
using System.ComponentModel.DataAnnotations;

namespace ASPectLibrary
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string  TeamName { get; set; }
        public ProjectCategory ProjectCategory{ get; set; }
        public string AppName { get; set; }
        public string Description { get; set; }
        public Guid AspNetUserId { get; set; }
        public Course Course{ get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class ProjectCategory
    {
        [Key]
        public int ProjectCategoryId {get; set;}
        public string ProjectCategoryName {get; set;}
    }
}

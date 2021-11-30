using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prello.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the project name")]
        [Display(Name = "Project Name")]
        public string Name { get; set; }

        [Display(Name = "Project Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please specify the project status")]
        [Display(Name = "Project Status")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Please enter the project due date")]
        [Display(Name = "Project Due Date")]
        public DateTime DueDate { get; set; }
    }
}

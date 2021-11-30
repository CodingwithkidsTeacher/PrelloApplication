using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prello.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter the client's fullname.")]
        [Display(Name = "Client Fullname")]
        public string Name { get; set; }

        [Display(Name = "Client Email")]
        public string Email { get; set; }
    }
}

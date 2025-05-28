using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prac_14.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Name is Required")]
        [StringLength(50,ErrorMessage ="Name should not exceed 50 characters.")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Dept is Required")]
        public String Department { get; set; }
    }
}
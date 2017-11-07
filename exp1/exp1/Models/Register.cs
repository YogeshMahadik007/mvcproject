using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace exp1.Models
{
    public class Register
    {

        public int id{get;set;}
        public String fname { get; set; }
        public String mname { get; set; }
        public String lname { get; set; }

        [Required]
        [Display(Name = "Email")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$|^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}", ErrorMessage = "Please enter a valid email address")]      
        public String email_id { get; set; }

        [Compare("email_id")]
        public String cemail { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(15, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string pwd { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(15, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("pwd")]
        public string cpwd { get; set; }

        public string urole { get; set; }

    }
}
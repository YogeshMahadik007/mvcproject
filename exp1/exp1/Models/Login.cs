using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace exp1.Models
{
    public class Login
    {
        public int id {get;set;}

        [Required(ErrorMessage = "Kindly Enter Correct Email ID")]
        public String email_id { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Kindly Enter Correct Password")]
        public String password { get; set; }

        public string urole { get; set; }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace exp1.Models
{
    public class Orderr
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string pname { get; set; }
        [Required]
        public int price { get; set; }
        [Required]
        public string status { get; set; }
    }
}
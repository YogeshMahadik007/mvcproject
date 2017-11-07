using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace exp1.Models
{
    public class Cart
    {
        [Required]
        public int id { get; set; }
        [Required]
        public String email_id { get; set; }
        [Required]
        public int price { get; set; }
        [Required]
        public String product_name { get; set; }
        [Required]
        public String img { get; set; }
    }
}
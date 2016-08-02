using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Cargo4You.Models
{
    public class Parcel
    {
        public int Id { get; set; }

        [Required]
        public double Dinensions { get; set; }

        [Required]
        public double Weight { get; set; }
                
        public double Price { get; set; }
    }
}
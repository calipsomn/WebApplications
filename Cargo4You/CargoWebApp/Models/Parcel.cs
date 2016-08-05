using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CargoWebApp.Models
{
    public class Parcel
    {
        [Index(IsUnique = true)]
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public double Width { get; set; }

        [Required]
        public double Height { get; set; }

        [Required]
        public double Depth { get; set; }

        public double Price { get; set; }

        public bool Fragile { get; set; }

        public bool Hazardous { get; set; }

        public bool Perishable { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
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

        [Required]
        [Range(0.01, 200)]
        public double Weight { get; set; }

        [Required]
        [Range(0.01, 500)]
        public double Width { get; set; }

        [Required]
        [Range(0.01, 500)]
        public double Height { get; set; }

        [Required]
        [Range(0.01, 500)]
        public double Depth { get; set; }

        public double Price { get; set; }

        public bool Fragile { get; set; }

        public bool Hazardous { get; set; }

        public bool Perishable { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
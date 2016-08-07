using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CargoWebApp.Models
{
    public class Cart
    {
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [StringLength(255)]
        public string UserName { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CargoWebApp.ViewModels
{
    public class CartItemViewModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "cartId")]
        public int CartId { get; set; }

        [JsonProperty(PropertyName = "paecelId")]
        public int ParcelId { get; set; }

        [JsonProperty(PropertyName = "quantity")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public int Quantity { get; set; }

        [JsonProperty(PropertyName = "parcel")]
        public ParcelViewModel Parcel { get; set; }
    }
}
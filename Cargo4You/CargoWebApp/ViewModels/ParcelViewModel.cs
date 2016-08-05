using CargoWebApp.StaticHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoWebApp.ViewModels
{
    public class ParcelViewModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "weight")]
        public double Weight { get; set; }

        [JsonProperty(PropertyName = "width")]
        public double Width { get; set; }

        [JsonProperty(PropertyName = "height")]
        public double Height { get; set; }

        [JsonProperty(PropertyName = "depth")]
        public double Depth { get; set; }

        [JsonProperty(PropertyName = "price")]
        public double Price
        {
            get
            {
                return ParcelHelpers.CalculatePrice(Weight, Width, Depth, Height);
            }
        }

        [JsonProperty(PropertyName = "fragile")]
        public bool Fragile { get; set; }

        [JsonProperty(PropertyName = "hazardous")]
        public bool Hazardous { get; set; }

        [JsonProperty(PropertyName = "perishable")]
        public bool Perishable { get; set; }
    }
}
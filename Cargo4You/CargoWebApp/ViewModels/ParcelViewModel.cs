using CargoWebApp.StaticHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CargoWebApp.ViewModels
{
    public class ParcelViewModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [DisplayName("Weight (gm)")]
        [Range(0.01, 200, ErrorMessage ="The weight of the parcel must be at least 10 grams and no more tham 200 kilograms!")]
        [JsonProperty(PropertyName = "weight")]
        public double Weight { get; set; }

        [DisplayName("Width (cm)")]
        [JsonProperty(PropertyName = "width")]
        [Range(0.01, 500, ErrorMessage = "The width of the parcel must be at least 10 millimeters and no more tham 5 meters!")]
        public double Width { get; set; }

        [DisplayName("Height (cm)")]
        [JsonProperty(PropertyName = "height")]
        [Range(0.01, 500, ErrorMessage = "The height of the parcel must be at least 10 millimeters and no more tham 5 meters!")]
        public double Height { get; set; }

        [DisplayName("Depth (cm)")]
        [JsonProperty(PropertyName = "depth")]
        [Range(0.01, 500, ErrorMessage = "The depth of the parcel must be at least 10 millimeters and no more tham 5 meters!")]
        public double Depth { get; set; }

        [DisplayName("Price (€)")]
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
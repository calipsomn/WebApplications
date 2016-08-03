using Cargo4You.DTO;
using Cargo4You.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cargo4You.Conversions
{
    internal static class DtoToDalConversion
    {
        public static Parcel GetParcelFromDTO(ParcelDTO parcelDto)
        {
            return new Parcel
            {
                Id = parcelDto.Id,
                Fragile = parcelDto.Fragile,
                Price = parcelDto.Price,
                Depth = parcelDto.Depth,
                Hazardous = parcelDto.Hazardous,
                Height = parcelDto.Height,
                Perishable = parcelDto.Perishable,
                Width = parcelDto.Width,
                Weight = parcelDto.Weight
            };
        }
    }
}
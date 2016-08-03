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
                Dinensions = parcelDto.Dinensions,
                Fragile = parcelDto.Fragile,
                Price = parcelDto.Price
            };
        }
    }
}
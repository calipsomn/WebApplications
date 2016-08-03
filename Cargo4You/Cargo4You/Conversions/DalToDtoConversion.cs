using Cargo4You.DTO;
using Cargo4You.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cargo4You.Conversions
{
    public class DalToDtoConversion
    {
        public static ParcelDTO GetParcelDTOFromDAL(Parcel parcel)
        {
            return new ParcelDTO
            {
                Id = parcel.Id,
                Dinensions = parcel.Dinensions,
                Fragile = parcel.Fragile,
                Price = parcel.Price
            };
        }
    }
}
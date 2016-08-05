using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Constants;

namespace WebApp.StaticHelpers
{
    public static class ParcelHelpers
    {
        public static double CalculatePrice(double weight, double width, double depth, double height)
        {
            var parcelVolume = CalculateDimensions(width, depth, height);
            var priceByVolume = 0.0;
            if (parcelVolume <= ParcelConstants.MaxSmallDimensions)
            {
                priceByVolume = ParcelConstants.SmallDimensionsPrice;
            }
            else
            {
                if (parcelVolume <= ParcelConstants.MaxMediumDimensions)
                {
                    priceByVolume = ParcelConstants.MediumDimensionsPrice;
                }
                else
                {
                    if (parcelVolume <= ParcelConstants.MaxLargeDimensions)
                    {
                        priceByVolume = ParcelConstants.LargeDimensionsPrice;
                    }
                    else
                    {
                        priceByVolume = ParcelConstants.ExtraDimensionsPrice;
                    }
                }
            }
            var priceByWeight = 0.0;
            if (weight <= ParcelConstants.MaxSmallWeight)
            {
                priceByWeight = ParcelConstants.SmallWeightPrice;
            }
            else
            {
                if (weight <= ParcelConstants.MaxMediumWeight)
                {
                    priceByWeight = ParcelConstants.MediumWeightPrice;
                }
                else
                {
                    if (weight <= ParcelConstants.MaxLargeWeight)
                    {
                        priceByWeight = ParcelConstants.LargeWeightPrice;
                    }
                    else
                    {
                        priceByWeight = ParcelConstants.ExtraLargeWeightPrice + 
                            (weight - ParcelConstants.MaxLargeWeight) * ParcelConstants.ExtraWeightPrice / ParcelConstants.extraUnitMeasurement;
                    }
                }
            }
            return priceByVolume > priceByWeight ? priceByVolume : priceByWeight;
        }

        public static double CalculateDimensions(double width, double depth, double height)
        {
            return width * depth * height;
        }
    }
}
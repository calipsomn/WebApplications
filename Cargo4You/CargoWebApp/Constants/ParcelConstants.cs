using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoWebApp.Constants
{
    public static class ParcelConstants
    {
        public static double MaxSmallDimensions = 1000.0;
        public static double MaxMediumDimensions = 2000.0;
        public static double MaxLargeDimensions = 5000.0;

        public static double SmallDimensionsPrice = 10.0;
        public static double MediumDimensionsPrice = 20.0;
        public static double LargeDimensionsPrice = 50.0;
        public static double ExtraDimensionsPrice = 150.0;

        public static double MaxSmallWeight = 2.0;
        public static double MaxMediumWeight = 15.0;
        public static double MaxLargeWeight = 25.0;

        public static double SmallWeightPrice = 15.0;
        public static double MediumWeightPrice = 18.0;
        public static double LargeWeightPrice = 35.0;
        public static double ExtraLargeWeightPrice = 45.0;
        public static double ExtraWeightPrice = 0.537;

        public static double extraUnitMeasurement = 1.0;
    }
}
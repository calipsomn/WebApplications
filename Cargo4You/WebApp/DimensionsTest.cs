using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CargoWebApp.StaticHelpers;
using CargoWebApp.Constants;

namespace WebApp
{
    [TestClass]
    public class DimensionsTest
    {
        [TestMethod]
        public void TestCalculatePrice()
        {
            var price = ParcelHelpers.CalculatePrice(1, 1, 1, 1);
            Assert.AreEqual(price, ParcelConstants.SmallWeightPrice > ParcelConstants.SmallDimensionsPrice 
                ? ParcelConstants.SmallWeightPrice : ParcelConstants.SmallDimensionsPrice);
        }
    }
}

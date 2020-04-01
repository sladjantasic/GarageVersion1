using Microsoft.VisualStudio.TestTools.UnitTesting;
using GarageVersion1;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GarageVersion1.Tests
{
    [TestClass()]
    public class GarageHandlerTests
    {
        [TestMethod()]
        public void CreateGarageTest()
        {
            var handler = new GarageHandler();
            var garage = handler.CreateGarage(5);
            var expected = 5;

            var result = garage.vehicles.Length;
          
            Assert.AreEqual(expected, result);

        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GarageVersion1;
using System;
using System.Collections.Generic;
using System.Text;
using GarageVersion1.VehicleTypes;

namespace GarageVersion1.Tests
{
    [TestClass()]
    public class GarageTests
    {

        [TestMethod()]
        public void AddVehicleTest()
        {
            var handler = new GarageHandler();
            var garage = handler.CreateGarage(3);
            var aCar = new Car("skj303", "blue", 5, 4, "BMW", "Petrol");
            var bCar = new Car("skj303", "yellow", 5, 4, "BMW", "Diesel");
            var aBus = new Bus("skd493", "white", 60, 6, "Scania", "City bus");
            var aTruck = new Truck("aak594", "green", 3, 16, "Volvo", 2500);
            var aMotorcycle = new Motorcycle("kjj434", "black", 2, 2, "Suzuki", "Sportsbike");

            var success = "Added";
            var garageFull = "The garage is full";
            var notUnique = "The vehicle registration number is already in use";

            var result1 = garage.AddVehicle(aCar);
            var result2 = garage.AddVehicle(bCar);
            var result3 = garage.AddVehicle(aTruck);
            garage.AddVehicle(aBus);
            var result4 = garage.AddVehicle(aMotorcycle);

            Assert.AreEqual(garage.vehicles[0].RegistrationID, aCar.RegistrationID);
            Assert.AreEqual(success, result1);
            Assert.AreEqual(notUnique, result2);
            Assert.AreEqual(success, result3);
            Assert.AreEqual(garageFull, result4);
        }

        [TestMethod()]
        public void RemoveVehicleTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DisplayAllVehiclesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CountVehiclesByTypeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void FindVehicleByRegistrationIDTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void FindVehicleByPropertiesTest()
        {
            Assert.Fail();
        }
    }
}
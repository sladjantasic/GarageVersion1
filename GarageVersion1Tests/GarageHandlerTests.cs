using Microsoft.VisualStudio.TestTools.UnitTesting;
using GarageVersion1;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using GarageVersion1.VehicleTypes;

namespace GarageVersion1.Tests
{
    [TestClass()]
    public class GarageHandlerTests
    {
        [TestMethod()]
        public void AddVehicleTest()
        {
            var garage = new GarageHandler(3);
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
            garage.AddVehicle(aTruck);
            garage.AddVehicle(aBus);
            var result4 = garage.AddVehicle(aMotorcycle);

            Assert.AreEqual(success, result1);
            Assert.AreEqual(notUnique, result2);
            Assert.AreEqual(garageFull, result4);
        }

        [TestMethod()]
        public void RemoveVehicleTest()
        {
            var garage = new GarageHandler(3);
            var aCar = new Car("skj303", "blue", 5, 4, "BMW", "Petrol");
            var aBus = new Bus("skd493", "white", 60, 6, "Scania", "City bus");
            var aTruck = new Truck("aak594", "green", 3, 16, "Volvo", 2500);
            var success = "Removed";
            var empty = "The garage is empty";
            var missing = "That vehicle is not in the garage";

            var result1 = garage.RemoveVehicle(aCar);
            garage.AddVehicle(aCar);
            garage.AddVehicle(aBus);
            garage.AddVehicle(aTruck);
            var result2 = garage.RemoveVehicle(aBus);
            var result3 = garage.RemoveVehicle(aBus);

            Assert.AreEqual(empty, result1);
            Assert.AreEqual(success, result2);
            Assert.AreEqual(missing, result3);
        }

        [TestMethod()]
        public void CountVehiclesByTypeTest()
        {
            var garage = new GarageHandler(10);
            var aCar = new Car("skj303", "blue", 5, 4, "BMW", "Petrol");
            var bCar = new Car("skj304", "red", 4, 4, "Lambo", "Petrol");
            var cCar = new Car("skj305", "green", 5, 4, "Seat", "Diesel");
            var aBus = new Bus("skd493", "white", 60, 6, "Scania", "City bus");
            var bBus = new Bus("skd494", "blue", 20, 4, "Mercedes", "Minibus");
            var aTruck = new Truck("aak594", "green", 3, 16, "Volvo", 2500);
            var bTruck = new Truck("aak595", "grey", 5, 18, "Mack", 3000);
            var cTruck = new Truck("aak596", "black", 5, 14, "Scania", 2200);
            var dTruck = new Truck("aak597", "orange", 3, 16, "Renault", 2500);
            var empty = "The garage is empty";
            var done = "Bus: 2\nCar: 3\nTruck: 4\n";

            var result1 = garage.CountVehiclesByType();
            garage.AddVehicle(aCar);
            garage.AddVehicle(aBus);
            garage.AddVehicle(bCar);
            garage.AddVehicle(aTruck);
            garage.AddVehicle(bTruck);
            garage.AddVehicle(cCar);
            garage.AddVehicle(cTruck);
            garage.AddVehicle(bBus);
            garage.AddVehicle(dTruck);
            var result2 = garage.CountVehiclesByType();

            Assert.AreEqual(empty, result1);
            Assert.AreEqual(done, result2);
        }

        [TestMethod()]
        public void FindVehicleByRegistrationIDTest()
        {
            var garage = new GarageHandler(4);
            var aCar = new Car("SKJ303", "blue", 5, 4, "BMW", "Petrol");
            var aBus = new Bus("skd493", "white", 60, 6, "Scania", "City bus");
            var aTruck = new Truck("aak594", "green", 3, 16, "Volvo", 2500);
            var failure = "The garage is empty";
            var success = $"Car - Registration number: SKJ303 , Manufactured by: BMW , Color: blue , " +
                $"Number of seats: 5 , Number of wheels: 4 , Type of fuel: Petrol";
            var missing = "That vehicle is not in the garage";

            var result1 = garage.FindVehicleByRegistrationID("skj303");
            garage.AddVehicle(aCar);
            garage.AddVehicle(aBus);
            garage.AddVehicle(aTruck);
            var result2 = garage.FindVehicleByRegistrationID("SkJ303");
            var result3 = garage.FindVehicleByRegistrationID("abs323");

            Assert.AreEqual(failure, result1);
            Assert.AreEqual(success, result2);
            Assert.AreEqual(missing, result3);
        }

        [TestMethod()]
        public void DisplayAllvehiclesTest()
        {
        }



        [TestMethod()]
        public void FindVehicleByPropertiesTest()
        {
        }

    }
}
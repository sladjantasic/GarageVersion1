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
            var notUnique = "The vehicle registration number is already in use";

            var result1 = garage.AddVehicle(aCar);
            var result2 = garage.AddVehicle(bCar);
            garage.AddVehicle(aTruck);
            garage.AddVehicle(aBus);
            var result4 = garage.AddVehicle(aMotorcycle);

            Assert.AreEqual(success, result1);
            Assert.AreEqual(notUnique, result2);
            Assert.AreEqual(GarageHandler.garageFull, result4);
        }

        [TestMethod()]
        public void RemoveVehicleTest()
        {
            var garage = new GarageHandler(3);
            var aCar = new Car("skj303", "blue", 5, 4, "BMW", "Petrol");
            var aBus = new Bus("skd493", "white", 60, 6, "Scania", "City bus");
            var aTruck = new Truck("aak594", "green", 3, 16, "Volvo", 2500);
            var success = "Removed";

            var result1 = garage.RemoveVehicle(aCar);
            garage.AddVehicle(aCar);
            garage.AddVehicle(aBus);
            garage.AddVehicle(aTruck);
            var result2 = garage.RemoveVehicle(aBus);
            var result3 = garage.RemoveVehicle(aBus);
            var result4 = garage.RemoveVehicle(aTruck);

            Assert.AreEqual(GarageHandler.garageEmpty, result1);
            Assert.AreEqual(success, result2);
            Assert.AreEqual(GarageHandler.missingVehicle, result3);
            Assert.AreEqual(success, result4);
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

            Assert.AreEqual(GarageHandler.garageEmpty, result1);
            Assert.AreEqual(done, result2);
        }

        [TestMethod()]
        public void FindVehicleByRegistrationIDTest()
        {
            var garage = new GarageHandler(4);
            var aCar = new Car("SKJ303", "blue", 5, 4, "BMW", "Petrol");
            var aBus = new Bus("skd493", "white", 60, 6, "Scania", "City bus");
            var aTruck = new Truck("aak594", "green", 3, 16, "Volvo", 2500);

            var result1 = garage.FindVehicleByRegistrationID("skj303");
            garage.AddVehicle(aCar);
            garage.AddVehicle(aBus);
            garage.AddVehicle(aTruck);
            var result2 = garage.FindVehicleByRegistrationID("SkJ303");

            Assert.AreEqual(null, result1);
            Assert.AreEqual(aCar, result2);
        }

        [TestMethod()]
        public void DisplayAllvehiclesTest()
        {
            var garage = new GarageHandler(4);
            var aCar = new Car("SKJ303", "blue", 5, 4, "BMW", "Petrol");
            var aBus = new Bus("skd493", "white", 60, 6, "Scania", "City bus");
            var aTruck = new Truck("aak594", "green", 3, 16, "Volvo", 2500);
            var success = $"{aBus.DisplayVehicleInformation()}\n{aCar.DisplayVehicleInformation()}\n{aTruck.DisplayVehicleInformation()}\n";

            var result1 = garage.DisplayAllvehicles();
            garage.AddVehicle(aCar);
            garage.AddVehicle(aBus);
            garage.AddVehicle(aTruck);
            var result2 = garage.DisplayAllvehicles();

            Assert.AreEqual(GarageHandler.garageEmpty, result1);
            Assert.AreEqual(success, result2);
        }



        [TestMethod()]
        public void FindVehicleByPropertiesTest()
        {
            var garage = new GarageHandler(10);
            var aCar = new Car("skj303", "blue", 5, 4, "BMW", "Petrol");
            var bCar = new Car("skj304", "red", 4, 4, "Volvo", "Petrol");
            var cCar = new Car("skj305", "green", 5, 4, "Seat", "Diesel");
            var aBus = new Bus("skd493", "white", 60, 6, "Scania", "City bus");
            var bBus = new Bus("skd494", "blue", 20, 4, "Mercedes", "Minibus");
            var aTruck = new Truck("aak594", "green", 4, 16, "Volvo", 2500);
            var bTruck = new Truck("aak595", "grey", 5, 18, "Mack", 3000);
            var cTruck = new Truck("aak596", "black", 4, 14, "Scania", 2200);
            var dTruck = new Truck("aak597", "blue", 3, 16, "Volvo", 2500);
            var expected3 = $"{bBus.DisplayVehicleInformation()}\n{aCar.DisplayVehicleInformation()}\n{dTruck.DisplayVehicleInformation()}\n";
            var expected4 = $"{bCar.DisplayVehicleInformation()}\n{aTruck.DisplayVehicleInformation()}\n";

            var result1 = garage.FindVehicleByProperties(color: "blue");
            var result2 = garage.FindVehicleByProperties(numberOfSeats: 5);
            garage.AddVehicle(aCar);
            garage.AddVehicle(aBus);
            garage.AddVehicle(bCar);
            garage.AddVehicle(aTruck);
            garage.AddVehicle(bTruck);
            garage.AddVehicle(cCar);
            garage.AddVehicle(cTruck);
            garage.AddVehicle(bBus);
            garage.AddVehicle(dTruck);
            var result3 = garage.FindVehicleByProperties(color: "blue");
            var result4 = garage.FindVehicleByProperties(numberOfSeats: 4, manufacturer: "Volvo");
            var result5 = garage.FindVehicleByProperties(color: "orange");
            var result6 = garage.FindVehicleByProperties(color: "blue", manufacturer: "Ferrari");

            Assert.AreEqual(GarageHandler.garageEmpty, result1);
            Assert.AreEqual(GarageHandler.garageEmpty, result2);
            Assert.AreEqual(expected3, result3);
            Assert.AreEqual(expected4, result4);
            Assert.AreEqual(GarageHandler.missingVehicle, result5);
            Assert.AreEqual(GarageHandler.missingVehicle, result6);

        }

    }
}
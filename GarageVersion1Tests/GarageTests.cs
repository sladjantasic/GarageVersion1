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
        public void AddTest()
        {
            var garage = new Garage<Vehicle>(3);
            var aCar = new Car("skj303", "blue", 5, 4, "BMW", "Petrol");
            var bCar = new Car("skj303", "yellow", 5, 4, "BMW", "Diesel");
            var aBus = new Bus("skd493", "white", 60, 6, "Scania", "City bus");
            var aTruck = new Truck("aak594", "green", 3, 16, "Volvo", 2500);
            var aMotorcycle = new Motorcycle("kjj434", "black", 2, 2, "Suzuki", "Sportsbike");
            var success = "Added";
            var notUnique = "The vehicle registration number is already in use";

            var result1 = garage.Add(aCar);
            var result2 = garage.Add(bCar);
            garage.Add(aTruck);
            garage.Add(aBus);
            var result4 = garage.Add(aMotorcycle);

            Assert.AreEqual(success, result1);
            Assert.AreEqual(notUnique, result2);
            Assert.AreEqual(Garage<Vehicle>.garageFull, result4);
        }

        [TestMethod()]
        public void RemoveTest()
        {
            var garage = new Garage<Vehicle>(3);
            var aCar = new Car("skj303", "blue", 5, 4, "BMW", "Petrol");
            var aBus = new Bus("skd493", "white", 60, 6, "Scania", "City bus");
            var aTruck = new Truck("aak594", "green", 3, 16, "Volvo", 2500);
            var success = "Removed";

            var result1 = garage.Remove(aCar);
            garage.Add(aCar);
            garage.Add(aBus);
            garage.Add(aTruck);
            var result2 = garage.Remove(aBus);
            var result3 = garage.Remove(aBus);
            var result4 = garage.Remove(aTruck);

            Assert.AreEqual(Garage<Vehicle>.garageEmpty, result1);
            Assert.AreEqual(success, result2);
            Assert.AreEqual(Garage<Vehicle>.missingVehicle, result3);
            Assert.AreEqual(success, result4);
        }

        [TestMethod()]
        public void CountByTypeTest()
        {
            var garage = new Garage<Vehicle>(10);
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

            var result1 = garage.CountByType();
            garage.Add(aCar);
            garage.Add(aBus);
            garage.Add(bCar);
            garage.Add(aTruck);
            garage.Add(bTruck);
            garage.Add(cCar);
            garage.Add(cTruck);
            garage.Add(bBus);
            garage.Add(dTruck);
            var result2 = garage.CountByType();

            Assert.AreEqual(Garage<Vehicle>.garageEmpty, result1);
            Assert.AreEqual(done, result2);
        }

        [TestMethod()]
        public void FindByRegistrationIDTest()
        {
            var garage = new Garage<Vehicle>(4);
            var aCar = new Car("SKJ303", "blue", 5, 4, "BMW", "Petrol");
            var aBus = new Bus("skd493", "white", 60, 6, "Scania", "City bus");
            var aTruck = new Truck("aak594", "green", 3, 16, "Volvo", 2500);

            var result1 = garage.FindByRegistrationID("skj303");
            garage.Add(aCar);
            garage.Add(aBus);
            garage.Add(aTruck);
            var result2 = garage.FindByRegistrationID("SkJ303");

            Assert.AreEqual(null, result1);
            Assert.AreEqual(aCar, result2);
        }

        [TestMethod()]
        public void DisplayAllTest()
        {
            var garage = new Garage<Vehicle>(4);
            var aCar = new Car("SKJ303", "blue", 5, 4, "BMW", "Petrol");
            var aBus = new Bus("skd493", "white", 60, 6, "Scania", "City bus");
            var aTruck = new Truck("aak594", "green", 3, 16, "Volvo", 2500);
            var success = $"{aBus.DisplayVehicleInformation()}\n{aCar.DisplayVehicleInformation()}\n{aTruck.DisplayVehicleInformation()}\n";

            var result1 = garage.DisplayAll();
            garage.Add(aCar);
            garage.Add(aBus);
            garage.Add(aTruck);
            var result2 = garage.DisplayAll();

            Assert.AreEqual(Garage<Vehicle>.garageEmpty, result1);
            Assert.AreEqual(success, result2);
        }



        [TestMethod()]
        public void FindByPropertiesTest()
        {
            var garage = new Garage<Vehicle>(10);
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

            var result1 = garage.FindByProperties("blue", 0, 0, "");
            garage.Add(aCar);
            garage.Add(aBus);
            garage.Add(bCar);
            garage.Add(aTruck);
            garage.Add(bTruck);
            garage.Add(cCar);
            garage.Add(cTruck);
            garage.Add(bBus);
            garage.Add(dTruck);
            var result3 = garage.FindByProperties("blue", 0, 0, "");
            var result4 = garage.FindByProperties("", 4, 0, "Volvo");
            var result5 = garage.FindByProperties("orange", 0, 0, "");
            var result6 = garage.FindByProperties("blue", 0, 0, "Ferrari");

            Assert.AreEqual(Garage<Vehicle>.garageEmpty, result1);
            Assert.AreEqual(expected3, result3);
            Assert.AreEqual(expected4, result4);
            Assert.AreEqual(Garage<Vehicle>.missingVehicle, result5);
            Assert.AreEqual(Garage<Vehicle>.missingVehicle, result6);

        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GarageVersion1
{
    public class GarageHandler
    {
        private Garage<Vehicle> garage;

        public const string garageFull = "The garage is full";
        public const string garageEmpty = "The garage is empty";
        public const string missingVehicle = "There is no such vehicle";

        public GarageHandler(int n)
        {
            garage = new Garage<Vehicle>(n);

        }

        public string AddVehicle(Vehicle vehicle)
        {
            var success = "Added";
            var notUnique = "The vehicle registration number is already in use";

            var vehicles = garage.GetVehicles();

            if (vehicles.Any(e => e?.RegistrationID == vehicle.RegistrationID))
            {
                return notUnique;
            }
            else if (vehicles.Any(e => e == null))
            {
                var availableIndex = Array.IndexOf(vehicles, null);
                vehicles[availableIndex] = vehicle;
                garage.SetVehicles(vehicles);
                return success;
            }
            else
            {
                return garageFull;
            }
        }

        public string RemoveVehicle(Vehicle vehicle)
        {
            var success = "Removed";

            if (garage.IsEmpty) return garageEmpty;

            var vehicles = garage.GetVehicles();

            if (vehicles.Any(e => e == vehicle))
            {
                var indexOfVehicle = Array.IndexOf(vehicles, vehicle);
                vehicles[indexOfVehicle] = null;
                garage.SetVehicles(vehicles);
                return success;
            }
            else
            {
                return missingVehicle;
            }
        }

        public string CountVehiclesByType()
        {
            var result = "";

            if (garage.IsEmpty) return garageEmpty;

            var vehicles = garage.GetVehicles();

            var sortedVehicles = vehicles.Where(e => e != null).OrderBy(e => e.GetType().Name).ToArray();
            var typeTable = new Dictionary<string, int>();
            foreach (var item in sortedVehicles)
            {
                if (typeTable.ContainsKey(item.GetType().Name))
                {
                    typeTable[item.GetType().Name] += 1;
                }
                else
                {
                    typeTable.Add(item.GetType().Name, 1);
                }
            }

            foreach (var item in typeTable)
            {
                result += $"{item.Key}: {item.Value}\n";
            }
            return result;
        }

        public Vehicle FindVehicleByRegistrationID(string regID)
        {
            if (garage.IsEmpty) 
            {
                Console.WriteLine(garageEmpty);
                return null;
            }

            var vehicles = garage.GetVehicles();

            var fixedInput = regID.ToUpper();
            var searchedVehicle = vehicles.Where(e => e?.RegistrationID == fixedInput).ToArray();
            if (searchedVehicle.Any())
            {
                return searchedVehicle[0];
            }
            else
            {
                Console.WriteLine(missingVehicle);
                return null;
            }
        }

        public string DisplayAllvehicles()
        {
            var result = "";

            if (garage.IsEmpty) return garageEmpty;

            var vehicles = garage.GetVehicles();

            var sortedVehicles = vehicles.Where(e => e != null).OrderBy(e => e.GetType().Name).ToArray();
            foreach (var item in sortedVehicles)
            {
                result += $"{item.DisplayVehicleInformation()}\n";
            }
            return result;
        }

        public string FindVehicleByProperties(string color = null, int numberOfSeats = 0, int numberOfWheels = 0, string manufacturer = null)
        {
            var result = "";

            if (garage.IsEmpty) return garageEmpty;

            var vehicles = garage.GetVehicles();

            var filteredVehicles = vehicles.Where(e => (e?.Color == (color ?? e?.Color))
                                            && (e?.NumberOfSeats == (numberOfSeats == 0 ? e?.NumberOfSeats : numberOfSeats))
                                            && (e?.NumberOfWheels == (numberOfWheels == 0 ? e?.NumberOfWheels : numberOfWheels))
                                            && (e?.Manufacturer == (manufacturer ?? e?.Manufacturer)))
                                            .OrderBy(e => e.GetType().Name).ToArray();
            if (filteredVehicles.Any())
            {
                foreach (var item in filteredVehicles)
                {
                    result += $"{item.DisplayVehicleInformation()}\n";
                }
                return result;
            }
            else
            {
                return missingVehicle;
            }
        }
    }
}

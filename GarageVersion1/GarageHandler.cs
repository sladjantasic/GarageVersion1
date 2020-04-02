using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GarageVersion1
{
    public class GarageHandler
    {
        private Garage<Vehicle> garage;

        public GarageHandler(int n)
        {
            garage = new Garage<Vehicle>(n);

        }

        public string AddVehicle(Vehicle vehicle)
        {
            var vehicles = garage.GetVehicles();
            var success = "Added";
            var garageFull = "The garage is full";
            var notUnique = "The vehicle registration number is already in use";
            var sortedvehicles = vehicles.Where(e => e != null).OrderBy(e => e.GetType().Name).ToArray();
            if (sortedvehicles.Any(e => e.RegistrationID == vehicle.RegistrationID))
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
            var vehicles = garage.GetVehicles();
            var success = "Removed";
            var empty = "The garage is empty";
            var missing = "That vehicle is not in the garage";
            if (vehicles.All(e => e == null))
            {
                return empty;
            }
            else if (vehicles.Any(e => e == vehicle))
            {
                var indexOfVehicle = Array.IndexOf(vehicles, vehicle);
                vehicles[indexOfVehicle] = null;
                garage.SetVehicles(vehicles);
                return success;
            }
            else
            {
                return missing;
            }
        }

        public string CountVehiclesByType()
        {
            var vehicles = garage.GetVehicles();
            var empty = "The garage is empty";
            if (vehicles.All(e => e == null))
            {
                return empty;
            }
            var sortedvehicles = vehicles.Where(e => e != null).OrderBy(e => e.GetType().Name).ToArray();
            var typeTable = new Dictionary<string, int>();
            foreach (var item in sortedvehicles)
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
            string result = "";
            foreach (var item in typeTable)
            {
                result += $"{item.Key}: {item.Value}\n";
            }
            return result;
        }

        public string FindVehicleByRegistrationID(string regID)
        {
            var vehicles = garage.GetVehicles();
            var empty = "The garage is empty";
            var missing = "That vehicle is not in the garage";
            if (vehicles.All(e => e == null))
            {
                return empty;
            }
            var sortedvehicles = vehicles.Where(e => e != null).OrderBy(e => e.GetType().Name).ToArray();
            var fixedInput = regID.ToUpper();
            var searchedVehicle = sortedvehicles.Where(e => fixedInput == e.RegistrationID).ToArray();
            if (searchedVehicle.Any())
                return searchedVehicle[0].DisplayVehicleInformation();
            else
                return missing;
        }

        public void FindVehicleByProperties(string color = null, int numberOfSeats = 0, int numberOfWheels = 0, string manufacturer = null)
        {
            var vehicles = garage.GetVehicles();
            if (vehicles.All(e => e == null))
            {
                Console.WriteLine("The garage is empty");
                return;
            }
            var sortedvehicles = vehicles.Where(e => e != null).OrderBy(e => e.GetType().Name).ToArray();
            var filteredvehicles = sortedvehicles.Where(e => (e.Color == (color ?? e.Color))
                                            && (e.NumberOfSeats == (numberOfSeats == 0 ? e.NumberOfSeats : numberOfSeats))
                                            && (e.NumberOfWheels == (numberOfWheels == 0 ? e.NumberOfWheels : numberOfWheels))
                                            && (e.Manufacturer == (manufacturer ?? e.Manufacturer))).ToArray();

            Array.ForEach(filteredvehicles, e => Console.WriteLine(e.DisplayVehicleInformation()));
        }
        public void DisplayAllvehicles()
        {
            var vehicles = garage.GetVehicles();
            if (vehicles.All(e => e == null))
            {
                Console.WriteLine("The garage is empty");
            }
            else
            {
                var sortedvehicles = vehicles.Where(e => e != null).OrderBy(e => e.GetType().Name).ToArray();
                Array.ForEach(sortedvehicles, e => Console.WriteLine(e.DisplayVehicleInformation()));
            }
        }
    }
}

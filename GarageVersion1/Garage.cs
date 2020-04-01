using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using GarageVersion1.VehicleTypes;

namespace GarageVersion1
{
    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        public T[] vehicles;

        public Garage(int garageSize)
        {
            vehicles = new T[garageSize];
        }


        public void DisplayAllVehicles()
        {
            if (vehicles.All(e => e == null))
            {
                Console.WriteLine("The garage is empty");
            }
            else
            {
                var sortedVehicles = vehicles.Where(e => e != null).OrderBy(e => e.GetType().Name).ToArray();
                Array.ForEach(sortedVehicles, e => Console.WriteLine(e.DisplayVehicleInformation()));
            }
        }


        public string AddVehicle(T aVehicle)
        {
            var success = "Added";
            var garageFull = "The garage is full";
            var notUnique = "The vehicle registration number is already in use";
            var sortedVehicles = vehicles.Where(e => e != null).OrderBy(e => e.GetType().Name).ToArray();
            if (sortedVehicles.Any(e => e.RegistrationID == aVehicle.RegistrationID))
            {
                return notUnique;
            }
            else if (vehicles.Any(e => e == null))
            {
                var availableIndex = Array.IndexOf(vehicles, null);
                vehicles[availableIndex] = aVehicle;
                return success;
            }
            else
            {
                return garageFull;
            }
        }

        public string RemoveVehicle(T aVehicle)
        {
            var success = "Removed";
            var failure = "The garage is empty";
            if (vehicles.All(e => e == null))
            {
                return failure;
            }
            var indexOfVehicle = Array.IndexOf(vehicles, aVehicle);
            vehicles[indexOfVehicle] = null;
            return success;
        }

        public void CountVehiclesByType()
        {
            if (vehicles.All(e => e == null))
            {
                Console.WriteLine("The garage is empty");
                return;
            }

            var typeTable = new Dictionary<string, int>();

            foreach (var item in vehicles)
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
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }

        public string FindVehicleByRegistrationID(string regID)
        {
            var failure = "The garage is empty";
            if (vehicles.All(e => e == null))
            {
                return failure;
            }
            var searchedVehicle = vehicles.Where(e => string.Equals(regID, e.RegistrationID, StringComparison.OrdinalIgnoreCase)).ToArray();
            return searchedVehicle[0].DisplayVehicleInformation();
        }

        public void FindVehicleByProperties(string color = null, int numberOfSeats = 0, int numberOfWheels = 0, string manufacturer = null)
        {
            if (vehicles.All(e => e == null))
            {
                Console.WriteLine("The garage is empty");
                return;
            }
            var sortedVehicles = vehicles.Where(e => e != null).OrderBy(e => e.GetType().Name).ToArray();
            var filteredVehicles = sortedVehicles.Where(e => (e.Color == (color ?? e.Color))
                                            && (e.NumberOfSeats == (numberOfSeats == 0 ? e.NumberOfSeats : numberOfSeats))
                                            && (e.NumberOfWheels == (numberOfWheels == 0 ? e.NumberOfWheels : numberOfWheels))
                                            && (e.Manufacturer == (manufacturer ?? e.Manufacturer))).ToArray();

            Array.ForEach(filteredVehicles, e => Console.WriteLine(e.DisplayVehicleInformation()));
        }


        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in vehicles)
            {
                yield return item;
            }

        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

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
        public const string garageFull = "The garage is full";
        public const string garageEmpty = "The garage is empty";
        public static string missingVehicle = $"There is no such {typeof(T).Name.ToLower()}.";
        
        private T[] vehicles;
        public bool IsEmpty => vehicles.All(e => e == null);
        public bool IsFull => vehicles.All(e => e != null);

        public Garage(int garageSize)
        {
            vehicles = new T[garageSize];

        }

        public string Add(T vehicle)
        {
            var success = "Added";
            var notUnique = $"The {typeof(T).Name.ToLower()} registration number is already in use";

            if (vehicles.Any(e => e?.RegistrationID == vehicle.RegistrationID))
            {
                return notUnique;
            }
            else if (IsFull)
            {
                return garageFull;
            }
            else
            {
                var availableIndex = Array.IndexOf(vehicles, null);
                vehicles[availableIndex] = vehicle;
                return success;
            }
        }

        public string Remove(T vehicle)
        {
            var success = "Removed";

            if (IsEmpty) return garageEmpty;

            if (vehicles.Any(e => e == vehicle))
            {
                var indexOfVehicle = Array.IndexOf(vehicles, vehicle);
                vehicles[indexOfVehicle] = null;
                return success;
            }
            else
            {
                return missingVehicle;
            }
        }

        public string CountByType()
        {
            var result = "";

            if (IsEmpty) return garageEmpty;

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

        public T FindByRegistrationID(string regID)
        {
            if (IsEmpty)
            {
                Console.WriteLine(garageEmpty);
                return null;
            }

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

        public string DisplayAll()
        {
            var result = "";

            if (IsEmpty) return garageEmpty;

            var sortedVehicles = vehicles.Where(e => e != null).OrderBy(e => e.GetType().Name).ToArray();
            foreach (var item in sortedVehicles)
            {
                result += $"{item.DisplayVehicleInformation()}\n";
            }
            return result;
        }

        //TODO
        public string FindByProperties(string color, int numberOfSeats, int numberOfWheels, string manufacturer)
        {
            var result = "";

            if (IsEmpty) return garageEmpty;

            var filteredVehicles = vehicles.Where(e => (e?.Color == (color == "" ? e?.Color : color))
                                            && (e?.NumberOfSeats == (numberOfSeats == 0 ? e?.NumberOfSeats : numberOfSeats))
                                            && (e?.NumberOfWheels == (numberOfWheels == 0 ? e?.NumberOfWheels : numberOfWheels))
                                            && (e?.Manufacturer == (manufacturer == "" ? e?.Manufacturer : manufacturer)))
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

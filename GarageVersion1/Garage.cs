using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using GarageVersion1.VehicleTypes;

[assembly: InternalsVisibleTo("GarageVersion1Tests")]
namespace GarageVersion1
{
    internal class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        public const string garageFull = "The garage is full";
        public const string garageEmpty = "The garage is empty";
        public static string missingVehicle = $"There is no such {typeof(T).Name.ToLower()}.";
        
        private T[] vehicles;
        internal bool IsEmpty => vehicles.All(e => e == null);
        internal bool IsFull => vehicles.All(e => e != null);

        internal Garage(int garageSize)
        {
            vehicles = new T[garageSize];

        }

        /// <summary>
        /// Adds an object to the class' array and displays the resulting message
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        internal string Add(T vehicle)
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

        /// <summary>
        /// Removes an object from the class' array and displays the resulting message
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        internal string Remove(T vehicle)
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

        /// <summary>
        /// Displays all the types stored in the class' array and how many of them there are
        /// </summary>
        /// <returns></returns>
        internal string CountByType()
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

        /// <summary>
        /// Returns an object in the class' array that contains the input Registration number parameter and displays a resulting message
        /// </summary>
        /// <param name="regID"></param>
        /// <returns></returns>
        internal T FindByRegistrationID(string regID)
        {
            if (IsEmpty)
            {
                Console.WriteLine(garageEmpty);
                return null;
            }

            var searchedVehicle = vehicles.Where(e => e?.RegistrationID == regID).ToArray();
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

        /// <summary>
        /// Displays all objects in the class' array
        /// </summary>
        /// <returns></returns>
        internal string DisplayAll()
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

        /// <summary>
        /// Displays all objects in the class' array which satisfy the chosen criteria
        /// </summary>
        /// <param name="color"></param>
        /// <param name="numberOfSeats"></param>
        /// <param name="numberOfWheels"></param>
        /// <param name="manufacturer"></param>
        /// <returns></returns>
        internal string FindByProperties(string color, int numberOfSeats, int numberOfWheels, string manufacturer)
        {
            var result = "";

            if (IsEmpty) return garageEmpty;

            var filteredVehicles = vehicles.Where(e => (e?.Color == (color == "" ? e?.Color : color))
                                            && (e?.NumberOfSeats == (numberOfSeats == 999 ? e?.NumberOfSeats : numberOfSeats))
                                            && (e?.NumberOfWheels == (numberOfWheels == 999 ? e?.NumberOfWheels : numberOfWheels))
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

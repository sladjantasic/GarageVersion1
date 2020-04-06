using GarageVersion1.VehicleTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageVersion1
{
    public static class UI
    {
        /// <summary>
        /// Initializes the program by asking the user for the size of the garage
        /// </summary>
        /// <returns></returns>
        public static int InitializeGarage()
        {
            Console.Write("Welcome! Enter the size of the garage: ");
            var size = UserInput.GetInteger();
            return size;
        }

        /// <summary>
        /// Handles the main menu options and returns the user's choice
        /// </summary>
        /// <returns></returns>
        public static int SelectMainMenuOption()
        {
            Console.Write("Available actions:"
                    + "\n1) Add a vehicle to the garage"
                    + "\n2) Remove a vehicle from the garage"
                    + "\n3) Find a vehicle by its registration number"
                    + "\n4) Display a list of vehicles that satisfy given criteria"
                    + "\n5) Display how many vehicles of each type are in the garage"
                    + "\n6) Display all vehicles"
                    + "\n0) Exit the program" 
                    + "\nEnter the number in front of your choice: ");
            do
            {
                int userChoice = UserInput.GetInteger();
                if (userChoice >= 0 && userChoice < 7) return userChoice;
                Console.WriteLine("Pick one of the available actions");
            } while (true);
        }

        /// <summary>
        /// Returns the vehicle type the user wants to add to the garage
        /// </summary>
        /// <returns></returns>
        public static int GetVehicleType()
        {
            Console.Write("What type of vehicle would you like to add to the garage?"
                    + "\n1) Airplane"
                    + "\n2) Boat"
                    + "\n3) Bus"
                    + "\n4) Car"
                    + "\n5) Motorcycle"
                    + "\n6) Truck"
                    + "\n7) A different kind of vehicle"
                    + "\nEnter the number in front of your choice: ");
            do
            {
                int userChoice = UserInput.GetInteger();
                if (userChoice > 0 && userChoice <= 7) return userChoice;
                Console.WriteLine("Pick one of the available options");
            } while (true);
        }

        /// <summary>
        /// Gets the vehicle properties that the user wants assigned to the new vehicle
        /// </summary>
        /// <param name="vehicleType"></param>
        /// <param name="registrationID"></param>
        /// <param name="color"></param>
        /// <param name="numberOfSeats"></param>
        /// <param name="numberOfWheels"></param>
        /// <param name="manufacturer"></param>
        /// <param name="numberOfEngines"></param>
        /// <param name="length"></param>
        /// <param name="transitType"></param>
        /// <param name="fuelType"></param>
        /// <param name="bikeType"></param>
        /// <param name="cargoCapacity"></param>
        public static void GetVehicleProperties(int vehicleType, out string registrationID, out string color,
            out int numberOfSeats, out int numberOfWheels, out string manufacturer, out int numberOfEngines, 
            out int length, out string transitType, out string fuelType, out string bikeType, out int cargoCapacity)
        {
            Console.Write("Enter the vehicle's registration number: ");
            registrationID = UserInput.GetString().ToUpper();

            Console.Write("Enter the vehicle's manufacturer: ");
            manufacturer = UserInput.GetString().ToUpper();

            Console.Write("Enter the vehicle's color: ");
            color = UserInput.GetString().ToUpper();

            Console.Write("Enter the number of wheels the vehicle has: ");
            numberOfWheels = UserInput.GetInteger();

            Console.Write("Enter the number of seats the vehicle has: ");
            numberOfSeats = UserInput.GetInteger();

            numberOfEngines = 0;
            cargoCapacity = 0;
            length = 0;
            transitType = null;
            fuelType = null;
            bikeType = null;

            switch (vehicleType)
            {
                case 1:
                    Console.Write("Enter the number of engines the airplane has: ");
                    numberOfEngines = UserInput.GetInteger();
                    break;
                case 2:
                    Console.Write("Enter the boat's length (in meters): ");
                    length = UserInput.GetInteger();
                    break;
                case 3:
                    Console.Write("Enter what type of bus it is (coach, city, minibus etc.): ");
                    transitType = UserInput.GetString().ToUpper();
                    break;
                case 4:
                    Console.Write("Enter what type of fuel the car consumes (petrol, diesel, electric etc.): ");
                    fuelType = UserInput.GetString().ToUpper();
                    break;
                case 5:
                    Console.Write("Enter what type of motorcycle it is (chopper, sportsbike, moped etc.): ");
                    bikeType = UserInput.GetString().ToUpper();
                    break;
                case 6:
                    Console.Write("Enter the truck's cargo capacity (in kilograms): ");
                    cargoCapacity = UserInput.GetInteger();
                    break;
            }
        }
        
        /// <summary>
        /// Gets the properties by which the user wants to filter the search results for the vehicles in the garage
        /// </summary>
        /// <param name="color"></param>
        /// <param name="numberOfSeats"></param>
        /// <param name="numberOfWheels"></param>
        /// <param name="manufacturer"></param>
        public static void GetFilterProperties(out string color, out int numberOfSeats, out int numberOfWheels, out string manufacturer)
        {
            Console.WriteLine("Here you can filter through the vehicles in the garage by one or more of their properties." +
                "\nThe available properties are: manufacturer, color, number of seats, number of wheels.");

            Console.Write("Enter the manufacturer you want to filter by (or enter 999 to skip this property): ");
            manufacturer = UserInput.GetString();
            manufacturer = manufacturer == "999" ? "" : manufacturer.ToUpper();

            Console.Write("Enter the color you want to filter by (or enter 999 to skip this property): ");
            color = UserInput.GetString();
            color = color == "999" ? "" : color.ToUpper();

            Console.Write("Enter the number of seats you want to filter by (or enter 999 to skip this property): ");
            numberOfSeats = UserInput.GetInteger();
            numberOfSeats = numberOfSeats == 999 ? 999 : numberOfSeats;

            Console.Write("Enter the number of wheels you want to filter by (or enter 999 to skip this property): ");
            numberOfWheels = UserInput.GetInteger();
            numberOfWheels = numberOfWheels == 999 ? 999 : numberOfWheels;
        }
    }
}

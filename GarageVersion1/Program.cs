using System;

namespace GarageVersion1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var garage = new GarageHandler(UI.InitializeGarage());

            while (true)
            {
                switch (UI.SelectMainMenuOption())
                {
                    case 1:
                        Console.WriteLine(garage.AddVehicle(UI.GetVehicle()));
                        break;
                    case 2:
                        Console.WriteLine(garage.RemoveVehicle(garage.FindVehicleByRegistrationID(UserInput.GetString()))); 
                        break;
                    case 3:
                        Console.WriteLine(garage.FindVehicleByRegistrationID(UserInput.GetString()).DisplayVehicleInformation());
                        break;
                    case 4:
                        string color, manufacturer;
                        int numberOfSeats, numberOfWheels;
                        UI.GetProperties(out color, out numberOfSeats, out numberOfWheels, out manufacturer);
                        Console.WriteLine(garage.FindVehicleByProperties(color, numberOfSeats, numberOfWheels, manufacturer));
                        break;
                    case 5:
                        Console.WriteLine(garage.CountVehiclesByType());
                        break;
                    case 6:
                        Console.WriteLine(garage.DisplayAllVehicles());
                        break;
                    case 0:
                        Console.WriteLine("Goodbye");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter a valid choice");
                        break;
                }
            }
        }
    }
}

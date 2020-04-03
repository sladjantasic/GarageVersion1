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
                        var vehicleCreator = new VehicleCreator();
                        Console.WriteLine(garage.AddVehicle(vehicleCreator.CreateVehicle()));
                        break;
                    case 2:
                        Console.Write("Enter the registration number of the vehicle: ");
                        Console.WriteLine(garage.RemoveVehicle(garage.FindVehicleByRegistrationID(UserInput.GetString().ToUpper()))); //Play around with more
                        break;
                    case 3:
                        Console.WriteLine(garage.FindVehicleByRegistrationID(UserInput.GetString().ToUpper()).DisplayVehicleInformation());
                        break;
                    case 4:
                        UI.GetFilterProperties(out string color, out int numberOfSeats, out int numberOfWheels, out string manufacturer);
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
                }
            }
        }
    }
}

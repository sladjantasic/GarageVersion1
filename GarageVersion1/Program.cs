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
                        var inventoryCheck = garage.FindVehicleByRegistrationID(UserInput.GetString().ToUpper());
                        if (inventoryCheck == null) break;
                        Console.WriteLine(garage.RemoveVehicle(inventoryCheck));
                        break;
                    case 3:
                        Console.Write("Enter the registration number of the vehicle: ");
                        var registrationCheck = garage.FindVehicleByRegistrationID(UserInput.GetString().ToUpper());
                        if (registrationCheck == null) break;
                        Console.WriteLine(registrationCheck.DisplayVehicleInformation());
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

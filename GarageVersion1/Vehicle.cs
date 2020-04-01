using System;
using GarageVersion1.VehicleTypes;

namespace GarageVersion1
{
    public class Vehicle
    {
        public string Manufacturer { get; set; }
        public string RegistrationID { get; set; }
        public string Color { get; set; }
        public int NumberOfWheels { get; set; }
        public int NumberOfSeats { get; set;  }

        public Vehicle(string registrationID, string color, int numberOfSeats, int numberOfWheels, string manufacturer)
        {
            RegistrationID = registrationID;
            Color = color;
            NumberOfSeats = numberOfSeats;
            NumberOfWheels = numberOfWheels;
            Manufacturer = manufacturer;
        }

        internal virtual string DisplayVehicleInformation()
        {
            return $"{GetType().Name} - Registration number: {RegistrationID} , Manufactured by: {Manufacturer} ," +
                $" Color: {Color} , Number of seats: {NumberOfSeats} , Number of wheels: {NumberOfWheels}";
        }
    }
}
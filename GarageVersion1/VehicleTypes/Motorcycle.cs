using System;
using System.Collections.Generic;
using System.Text;

namespace GarageVersion1.VehicleTypes
{
    public class Motorcycle : Vehicle
    {
        public string BikeType { get; set; }

        public Motorcycle(string registrationID, string color, int numberOfSeats, int numberOfWheels, string manufacturer, string bikeType) 
            : base(registrationID, color, numberOfSeats, numberOfWheels, manufacturer)
        {
            BikeType = bikeType;
        }

        public override string DisplayVehicleInformation()
        {
            return $"{base.DisplayVehicleInformation()} , Type of motorcycle: {BikeType}";
        }
    }
}

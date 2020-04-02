using System;
using System.Collections.Generic;
using System.Text;

namespace GarageVersion1.VehicleTypes
{
    public class Car : Vehicle
    {
        public string FuelType { get; set; }

        public Car(string registrationID, string color, int numberOfSeats, int numberOfWheels, string manufacturer, string fuelType) 
            : base(registrationID, color, numberOfSeats, numberOfWheels, manufacturer)
        {
            FuelType = fuelType;
        }

        public override string DisplayVehicleInformation()
        {
            return $"{base.DisplayVehicleInformation()} , Type of fuel: {FuelType}";
        }
    }
}

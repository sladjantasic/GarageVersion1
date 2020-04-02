using System;
using System.Collections.Generic;
using System.Text;

namespace GarageVersion1.VehicleTypes
{
    class Boat : Vehicle
    {
        public double Length { get; set; }

        public Boat(string registrationID, string color, int numberOfSeats, int numberOfWheels, string manufacturer, int length) 
            : base(registrationID, color, numberOfSeats, numberOfWheels, manufacturer)
        {
            Length = length;
        }

        public override string DisplayVehicleInformation()
        {
            return $"{base.DisplayVehicleInformation()} , Length: {Length}m";
        }
    }
}

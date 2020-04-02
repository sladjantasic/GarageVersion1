using System;
using System.Collections.Generic;
using System.Text;

namespace GarageVersion1.VehicleTypes
{
    public class Bus : Vehicle
    {
        public string TransitType { get; set; }

        public Bus(string registrationID, string color, int numberOfSeats, int numberOfWheels, string manufacturer, string transitType) 
            : base(registrationID, color, numberOfSeats, numberOfWheels, manufacturer)
        {
            TransitType = transitType;
        }

        public override string DisplayVehicleInformation()
        {
            return $"{base.DisplayVehicleInformation()} , Type of bus: {TransitType}";
        }
    }
}

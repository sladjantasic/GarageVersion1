using System;
using System.Collections.Generic;
using System.Text;

namespace GarageVersion1.VehicleTypes
{
    class Airplane : Vehicle
    {
        public int NumberOfEngines { get; set; }

        public Airplane(string registrationID, string color, int numberOfSeats, int numberOfWheels, string manufacturer, int numberOfEngines) 
            : base(registrationID, color, numberOfSeats, numberOfWheels, manufacturer)
        {
            NumberOfEngines = numberOfEngines;
        }

        public override string DisplayVehicleInformation()
        {
            return $"{base.DisplayVehicleInformation()} , Number of engines: {NumberOfEngines}";
        }
    }
}

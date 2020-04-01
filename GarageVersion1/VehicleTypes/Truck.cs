using System;
using System.Collections.Generic;
using System.Text;

namespace GarageVersion1.VehicleTypes
{
    public class Truck : Vehicle
    {
        public int CargoCapacity { get; set; }

        public Truck(string registrationID, string color, int numberOfSeats, int numberOfWheels, string manufacturer, int cargoCapacity) 
            : base(registrationID, color, numberOfSeats, numberOfWheels, manufacturer)
        {
            CargoCapacity = cargoCapacity;
        }

        internal override string DisplayVehicleInformation()
        {
            return $"{base.DisplayVehicleInformation()} , Cargo capacity: {CargoCapacity}kg";
        }
    }
}

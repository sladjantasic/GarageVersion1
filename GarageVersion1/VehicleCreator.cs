using GarageVersion1.VehicleTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageVersion1
{
    public class VehicleCreator
    {
        /// <summary>
        /// Creates a new vehicle to be placed in the garage
        /// </summary>
        /// <returns></returns>
        public Vehicle CreateVehicle()
        {
            int vehicleType = UI.GetVehicleType();

            switch (vehicleType)
            {
                case 1:
                    UI.GetVehicleProperties(vehicleType, out string registrationID, out string color,
                        out int numberOfSeats, out int numberOfWheels, out string manufacturer, out int numberOfEngines,
                        out int length, out string transitType, out string fuelType, out string bikeType, out int cargoCapacity);
                    return new Airplane(registrationID, color, numberOfSeats, numberOfWheels, manufacturer, numberOfEngines);
                case 2:
                    UI.GetVehicleProperties(vehicleType, out registrationID, out color,
                        out numberOfSeats, out numberOfWheels, out manufacturer, out numberOfEngines,
                        out length, out transitType, out fuelType, out bikeType, out cargoCapacity);
                    return new Boat(registrationID, color, numberOfSeats, numberOfWheels, manufacturer, length);
                case 3:
                    UI.GetVehicleProperties(vehicleType, out registrationID, out color,
                        out numberOfSeats, out numberOfWheels, out manufacturer, out numberOfEngines,
                        out length, out transitType, out fuelType, out bikeType, out cargoCapacity);
                    return new Bus(registrationID, color, numberOfSeats, numberOfWheels, manufacturer, transitType);
                case 4:
                    UI.GetVehicleProperties(vehicleType, out registrationID, out color,
                        out numberOfSeats, out numberOfWheels, out manufacturer, out numberOfEngines,
                        out length, out transitType, out fuelType, out bikeType, out cargoCapacity);
                    return new Car(registrationID, color, numberOfSeats, numberOfWheels, manufacturer, fuelType);
                case 5:
                    UI.GetVehicleProperties(vehicleType, out registrationID, out color,
                        out numberOfSeats, out numberOfWheels, out manufacturer, out numberOfEngines,
                        out length, out transitType, out fuelType, out bikeType, out cargoCapacity);
                    return new Motorcycle(registrationID, color, numberOfSeats, numberOfWheels, manufacturer, bikeType);
                case 6:
                    UI.GetVehicleProperties(vehicleType, out registrationID, out color,
                        out numberOfSeats, out numberOfWheels, out manufacturer, out numberOfEngines,
                        out length, out transitType, out fuelType, out bikeType, out cargoCapacity);
                    return new Truck(registrationID, color, numberOfSeats, numberOfWheels, manufacturer,cargoCapacity);
                case 7:
                    UI.GetVehicleProperties(vehicleType, out registrationID, out color,
                        out numberOfSeats, out numberOfWheels, out manufacturer, out numberOfEngines,
                        out length, out transitType, out fuelType, out bikeType, out cargoCapacity);
                    return new Vehicle(registrationID, color, numberOfSeats, numberOfWheels, manufacturer);
                default:
                    return null;
            }
        }
    }
}

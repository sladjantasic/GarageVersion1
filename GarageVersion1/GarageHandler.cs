using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GarageVersion1
{
    public class GarageHandler
    {
        private Garage<Vehicle> garage;


        public GarageHandler(int n)
        {
            garage = new Garage<Vehicle>(n);

        }

        public string AddVehicle(Vehicle vehicle) => garage.Add(vehicle);

        public string RemoveVehicle(Vehicle vehicle) => garage.Remove(vehicle);

        public string CountVehiclesByType() => garage.CountByType();

        public Vehicle FindVehicleByRegistrationID(string regID) => garage.FindByRegistrationID(regID);

        public string DisplayAllVehicles() => garage.DisplayAll();

        public string FindVehicleByProperties(string color, int numberOfSeats, int numberOfWheels, string manufacturer) 
            => garage.FindByProperties(color, numberOfSeats, numberOfWheels, manufacturer);


    }
}

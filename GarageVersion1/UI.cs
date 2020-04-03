using GarageVersion1.VehicleTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageVersion1
{
    public static class UI
    {
        public static int InitializeGarage()
        {
            Console.Write("Welcome! Enter the size of the garage: ");
            var size = UserInput.GetInteger();
            return size;
        }

        //TODO
        public static int SelectMainMenuOption()
        {
            throw new NotImplementedException();
        }

        //TODO
        public static Vehicle GetVehicle()
        {
            throw new NotImplementedException();
        }

        //TODO
        public static void GetProperties(out string color, out int numberOfSeats, out int numberOfWheels, out string manufacturer)
        {
            throw new NotImplementedException();
        }
    }
}

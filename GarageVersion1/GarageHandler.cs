using System;
using System.Collections.Generic;
using System.Text;

namespace GarageVersion1
{
    public class GarageHandler
    {
        //private Garage<Vehicle> garage;

        //public GarageHandler(int n)
        //{
        //    garage = new Garage<Vehicle>(n);

        //}

        public Garage<Vehicle> CreateGarage(int n)
        {
            var garage = new Garage<Vehicle>(n);
            return garage;
        }

        //TODO method to add to the array

        //TODO method to remove from the array
    }
}

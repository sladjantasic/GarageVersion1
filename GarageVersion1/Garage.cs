using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using GarageVersion1.VehicleTypes;

namespace GarageVersion1
{
    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private T[] vehicles;


        public Garage(int garageSize)
        {
            vehicles = new T[garageSize];
            
        }
        
        public T[] GetVehicles()
        {
            return vehicles.ToArray();
        }

        public void SetVehicles(T[] array)
        {
            vehicles = array;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in vehicles)
            {
                yield return item;
            }

        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

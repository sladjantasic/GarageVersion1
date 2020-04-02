using System;
using System.Collections.Generic;
using System.Text;

namespace GarageVersion1
{

    public static class UserInput
    {
        public static int GetInteger()
        {
            int value;
            do
            {
                var result = int.TryParse(GetString(), out value);
                if (result) break;
                Console.Write("Try again: ");
            } while (true);
            return value;
        }
        public static string GetString()
        {
            string value;
            do
            {
                value = Console.ReadLine();
                if (!string.IsNullOrEmpty(value)) break;
                Console.Write("Try again: ");
            } while (true);
            return value;
        }
    }

}

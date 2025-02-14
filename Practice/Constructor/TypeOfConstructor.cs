using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Constructor
{
    class Car
    {
        public string Brand;
        public static string LogLevel;

        // Parameterized Constructor
        public Car(string brand)
        {
            Brand = brand;
        }

        // Copy Constructor
        //Takes an object of the same class as a parameter.
        //Copies the values from the existing object.
        // Useful in cloning objects.
        public Car(Car existingCar)
        {
            Brand = existingCar.Brand;
        }

        // Static Constructor
        //No access modifier (always private).
        //  No parameters.
        // Executes only once when the class is first loaded.
        
        static Car()
        {
            LogLevel = "INFO";
            Console.WriteLine("Static Constructor Called!");
        }
    }

}

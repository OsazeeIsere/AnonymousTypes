using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fun with Anonymous types");

            BuildAnonType("Camry","Blue",100);

            //make 2 anonymous classes with identical name/value pairs.
            var firstCar = new { Make = "Bus", Color = "Hash", Speed = 80 };
            var secondCar = new { Make = "Bus", Color = "Hash", Speed = 80 };

            //are they considered equals using Equal() ?
            if(firstCar.Equals(secondCar))
            {
                Console.WriteLine("Same anonymous object!");

            }
            else
            {
                Console.WriteLine("Not Same anonymous object!");
            }
            //are they considered equals using == ?
            if (firstCar == secondCar)
            {
                Console.WriteLine("Same anonymous object!");

            }
            else
            {
                Console.WriteLine("Not Same anonymous object!");
            }
            //are they tyhe same underlying type ?
            if (firstCar.GetType().Name==secondCar.GetType().Name)
            {
                Console.WriteLine("Same anonymous type!");

            }
            else
            {
                Console.WriteLine("Not Same anonymous type!");
            }
            // show all the details
            Console.WriteLine();
            ReflectOverAnonymousType(firstCar);
            ReflectOverAnonymousType(secondCar);

            //mamke anonymous type that is composed of another
            var purchaseItem = new
            {
               TimeBought = DateTime.Now,
               ItemBought = new { Make = "Lorry", Color = "Black", Speed = 70 },
               Price=35.000
           };

            ReflectOverAnonymousType(purchaseItem);
            Console.ReadLine();

        }

        static void BuildAnonType(string make,string color,int currSp)
        {
            //build anon type using incoming args
            var car = new { Make = make, Color = color, Speed = currSp };

            //note you can now use this type to get the property data
            Console.WriteLine("You have a {0} {1} going {2} MPH", car.Color, car.Make, car.Speed);
            //Anon Types have custom implementation of each virtual
            //method of system.object. for example:
            Console.WriteLine("ToString() == {0}", car.ToString());
            //reflect over what the compiler generated
            ReflectOverAnonymousType(car);

        }
        static void ReflectOverAnonymousType(object obj)
        {
            Console.WriteLine("obj is an instance of {0}", obj.GetType().Name);
            Console.WriteLine("Base class of {0} is {1}", obj.GetType().Name, obj.GetType().BaseType);
            Console.WriteLine("obj.ToString == {0}", obj.ToString());
            Console.WriteLine("obj.GetHashCode  is {0}", obj.GetHashCode());
            Console.WriteLine();

        }
    }
}

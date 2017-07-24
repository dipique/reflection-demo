using System;
using System.Reflection;  //Remember to add me!

namespace Reflection_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create an example of the class with random values
            var instance = new SampleClass() {
                PropertyOne = "Some Value",
                PropertyTwo = 5,
                PropertyThree = 4.2m
            };

            //Print out the values using reflection
            PrintOutPropertyValues(instance);
            Console.ReadKey(); //pause so you can see the results

            //It's worth noting that a lot of the power of reflection comes from the fact that you
            //don't necessarily need to know what class you're dealing with. C# has a feature called
            //"generics" that allows you to create methods that don't have a specific parameter type,
            //or that return different types. It works like this:
            PrintOutPropertyValues_Generic(instance); //this looks the same, but check out the method
            Console.ReadKey(); //pause so you can see the results
        }

        static void PrintOutPropertyValues(SampleClass instance)
        {
            //Get a list of all the properties. Note that these are not coming from the class instance,
            //but from the type itself. That means you don't need an instance to get these properties.
            PropertyInfo[] properties = typeof(SampleClass).GetProperties();

            //Loop through them and print out the value of each. The value that comes back from
            //PropertyInfo.GetValue is always an object; that doesn't matter for printing them
            //out, but in most other situations you need to end up doing some kind of conversion.
            Console.WriteLine("Properties:");
            foreach (var p in properties)
                Console.WriteLine(p.GetValue(instance));
        }

        static void PrintOutPropertyValues_Generic<T>(T instance)
        {
            //The method signature, rather than requiring a certain type, insteads allows
            //you to use any type. The fully qualified way to call this method would be
            //PrintOutPropertyValues_Generic<SampleClass>(instance); however, because instance
            //is of type SampleClass, C# is able to infer the method parameter type. I can now do
            //all the same things I did before, but this method works with any class.
            PropertyInfo[] properties = typeof(T).GetProperties();

            //Loop through them and print out the value of each. The value that comes back from
            //PropertyInfo.GetValue is always an object; that doesn't matter for printing them
            //out, but in most other situations you need to end up doing some kind of conversion.
            Console.WriteLine("\nProperties (Generic Method):");
            foreach (var p in properties)
                Console.WriteLine(p.GetValue(instance));
        }
    }

    class SampleClass
    { 
        public string PropertyOne { get; set; }
        public int PropertyTwo { get; set; }
        public decimal PropertyThree { get; set; }
    }
}

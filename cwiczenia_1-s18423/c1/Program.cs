//import
using System;
using System.Collections.Generic;

namespace c1
{
    class Program
    {
        static void Main(string[] args)
        {
            //addStudent() - camelCase
            //AddStudent - PascalCase

            //Write smth in console
            Console.WriteLine("Some text");

            //Ctrl + Space - list props of the class
            Student student1 = new Student { 
            FirstName = "Vladyslav",
            Surname = "Ostapchuk",
            SNumber = 18423
            };

            //String interpolation
            Console.WriteLine($"Student name: {student1.FirstName}\nStudent surname: {student1.Surname}");

            //
            var tmp = 3 + 3;
            Console.WriteLine(tmp);

            var list = new List<string> {"ala","ma","kota"};
            
            foreach (var wrt in list) {
                Console.WriteLine(wrt);
            }
        }
    }
}

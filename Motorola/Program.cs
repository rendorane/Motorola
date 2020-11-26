using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace Motorola
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            List<string> countriesAndCapitals = File.ReadLines(@"C:\\Users\\Marian\\source\repos\\Motorola\\Motorola\\countries_and_capitals.txt").ToList();
            List<string> countries = new List<string>();
            List<string> capitals = new List<string>();

            Console.WriteLine(countriesAndCapitals[rnd.Next(0, countriesAndCapitals.Count)]);

            Console.ReadLine();

            
    }
    }
}

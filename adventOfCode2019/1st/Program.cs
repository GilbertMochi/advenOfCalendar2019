using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1st
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\Users\janessa.aulen\Documents\aoc2019\modules.txt";
            string[] modules = File.ReadAllLines(path, Encoding.UTF8);

            double neededFuel = 0;
            double totalNeededFuel = 0;

            foreach (string line in modules)
            {
                bool parseSuccess;
                int moduleFuel;
                parseSuccess = int.TryParse(line, out moduleFuel);

                Console.WriteLine(line);

                if (parseSuccess)
                {
                    neededFuel += CalculateNeededFuelForModule(moduleFuel);
                    totalNeededFuel += calculateTotalFuel(moduleFuel);
                }
            }

            Console.WriteLine($"Needed fuel: {neededFuel}");
            Console.WriteLine($"Total fuel: {totalNeededFuel}");
        }

        static double CalculateNeededFuelForModule(double mass)
        {
            return (Math.Floor(mass / 3)) - 2;
        }

        static double calculateTotalFuel(double mass)
        {
            double neededFuel = CalculateNeededFuelForModule(mass);
            double totalFuel = 0;
            while (neededFuel > 0)
            {
                totalFuel += neededFuel;
                neededFuel = CalculateNeededFuelForModule(neededFuel);
            }

            return totalFuel;
        }
    }
}

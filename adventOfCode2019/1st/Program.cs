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
            double f = 0;

            foreach (string line in modules)
            {
                bool parseSuccess;
                int moduleFuel;
                parseSuccess = int.TryParse(line, out moduleFuel);

                Console.WriteLine(line);

                if (parseSuccess)
                {
                    neededFuel += CalculateNeededFuelForModule(moduleFuel);
                }
                f += calculateTotalFuel(neededFuel);

            }

            Console.WriteLine($"Needed fuel: {neededFuel}");
            Console.WriteLine($"Total fuel: {f}");
        }

        static double CalculateNeededFuelForModule(double m)
        {
            return (Math.Floor(m / 3)) - 2;
        }

        static double calculateTotalFuel(double fuel)
        {
            double totalFuel = fuel;
            while (fuel > 0)
            {
                fuel = CalculateNeededFuelForModule(fuel);

                if (fuel < 0)
                {
                    fuel = 0;
                }

                totalFuel += fuel;
            }

            return totalFuel;
        }
    }
}

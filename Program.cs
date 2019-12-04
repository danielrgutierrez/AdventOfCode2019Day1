using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2019Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var fuelUsages = new List<int>();
                var totalFuelUsagePart1 = 0;
                using (StreamReader sr = new StreamReader("input.txt"))
                {
                    string strMass;
                    while ((strMass = sr.ReadLine()) != null)
                    {
                        if (Int32.TryParse(strMass, out int mass))
                        {
                            totalFuelUsagePart1 += CalculateFuelUsage(mass);
                            fuelUsages.Add(CalculateTotalFuelUsage(mass));
                        }
                    }
                }
                var totalFuelUsagePart2 = 0;
                foreach (var fuelUsage in fuelUsages)
                {
                    totalFuelUsagePart2 += fuelUsage;
                }
                Console.WriteLine($"Part 1: The total fuel usage is {totalFuelUsagePart1}.");
                Console.WriteLine($"Part 2: The total fuel usage is {totalFuelUsagePart2}.");
            }
            catch (IOException e)
            {
                Console.Write($"Error reading the file: {e.Message}");
            }
        }

        static int CalculateFuelUsage(int mass) => (mass / 3) - 2;

        static int CalculateTotalFuelUsage(int initialMass)
        {
            var totalFuelUsage = CalculateFuelUsage(initialMass);
            var possibleAdditionalFuel = CalculateFuelUsage(totalFuelUsage);
            while (possibleAdditionalFuel > 0)
            {
                totalFuelUsage += possibleAdditionalFuel;
                possibleAdditionalFuel = CalculateFuelUsage(possibleAdditionalFuel);
            }
            return totalFuelUsage;
        }
    }
}

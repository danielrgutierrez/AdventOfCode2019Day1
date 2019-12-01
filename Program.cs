using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2019Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            var totalFuelUsage = 0;
            try
            {
                using (StreamReader sr = new StreamReader("input.txt"))
                {
                    string strMass;
                    while ((strMass = sr.ReadLine()) != null)
                    {
                        if (Int32.TryParse(strMass, out int mass))
                        {
                            totalFuelUsage += CalculateFuelUsage(mass);
                        }
                    }
                }
                Console.WriteLine($"The total fuel usage is {totalFuelUsage}.");
            }
            catch (IOException e)
            {
                Console.Write($"Error reading the file: {e.Message}");
            }
        }

        static int CalculateFuelUsage(int mass) => (mass / 3) - 2;
    }
}

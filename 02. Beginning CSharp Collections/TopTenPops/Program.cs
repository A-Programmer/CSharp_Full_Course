using System;
using System.Collections.Generic;

namespace TopTenPops
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"Populations.csv";

            CsvReader reader = new CsvReader(filePath);

            List<Country> countries = reader.ReadAllCountries();

            var myCountry = new Country("My Country", "MYC", 100_000_000);

            int index = countries.FindIndex(x => x.Population > 80_000_000);
            countries.Insert(index, myCountry);
            countries.RemoveAt(index);

            foreach (Country country in countries)
            {
                Console.WriteLine(
                        $"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}"
                    );
            }

            Console.WriteLine($"{countries.Count} Countries.");
        }
    }
}

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
            reader.RemoveCommaCountries(countries);

            Console.WriteLine("Enter no. of countries to display> ");
            bool userInputIsInt = int.TryParse(Console.ReadLine(), out int nCountries);
            if(!userInputIsInt || nCountries <= 0)
            {
                Console.WriteLine("You must enter a +ve integer. Exiting.");
                return;
            }

            int maxCountries = nCountries;
            for (int i = 0; i < countries.Count; i++)
            // for (int i = countries.Count - 1; i >= 0; i--)
            {
                // var displayOrder = countries.Count - 1 - i;
                if(i > 0 && (i % maxCountries == 0))
                {
                    Console.WriteLine("Hit enter to continue, anything else to quit");
                    if(Console.ReadLine() != "")
                        break;
                }
                Country country = countries[i];
                Console.WriteLine(
                        $"{i + 1}: {PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}"
                    );
            }

            Console.WriteLine($"{countries.Count} Countries.");

            // Using Dictionary
            // Dictionary<string, Country> countries = reader.ReadAllCountries();
            // Console.WriteLine($"Which country code do you want to look up? ");
            // var userInput = Console.ReadLine();

            // bool countryExists = countries.TryGetValue(userInput, out Country country);
            // if(!countryExists)
            //     Console.WriteLine($"Sorry, there is no country with the code {userInput}");
            // else
            //     Console.WriteLine($"{country.Name} has population {PopulationFormatter.FormatPopulation(country.Population)}");

            // var myCountry = new Country("My Country", "MYC", 100_000_000);
        }
    }
}

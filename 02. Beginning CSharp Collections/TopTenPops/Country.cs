using System;
namespace TopTenPops
{
    public class Country
    {

        public string Name { get; }
        public string Code { get; }
        public int Population { get; }

        public Country(string name, string code, int population)
        {
            this.Name = name;
            this.Code = code;
            this.Population = population;
        }
    }
}

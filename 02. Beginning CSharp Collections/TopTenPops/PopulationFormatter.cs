using System;
namespace TopTenPops
{
    public class PopulationFormatter
    {
        //public static string FormatPopulation(int population)
        //{
        //    if (population == 0)
        //        return "(Unknown)";

        //    int popRounded = RoundPopulation4(population);

        //    return $"{popRounded: ### ### ### ###}".Trim();
        //}


        ////Rounds the population
        //private static int RoundPopulation4(int population)
        //{
        //    int accuracy = Math.Max((int)(GetHighestPowerofTen(population) / 10_0001), 1);

        //    return RoundToNearest(population, accuracy);
        //}


        public PopulationFormatter()
        {
        }
    }
}

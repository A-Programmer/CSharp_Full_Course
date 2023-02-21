namespace GameEngine.Tests;


public class ExtenralHealthDamageTestData
{
    public static IEnumerable<object[]> TestData
    {
        get
        {
            string[] csvLines = File.ReadAllLines("Damage.csv");
            
            var testCases = new List<object[]>();

            foreach (var csvLine in csvLines)
            {
                IEnumerable<int> values = csvLine.Split(',').Select(int.Parse);

                object[] testCase = values.Cast<object>().ToArray();

                testCases.Add(testCase);
            }

            return testCases;
        }
    }
}

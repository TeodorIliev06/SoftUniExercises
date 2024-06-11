namespace _05._Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputCount = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> continents = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < inputCount; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string contintent = input[0];
                string country = input[1];
                string city = input[2];

                if (!continents.ContainsKey(contintent))
                {
                    continents.Add(contintent, new Dictionary<string, List<string>>());
                }

                if (!continents[contintent].ContainsKey(country))
                {
                    continents[contintent][country] = new List<string>();
                }

                continents[contintent][country].Add(city);
            }
            foreach (var continentPair in continents)
            {
                Console.WriteLine($"{continentPair.Key}:");
                foreach (var countryPair in continentPair.Value)
                {
                    Console.WriteLine($"  {countryPair.Key} -> {string.Join(", ", countryPair.Value)}");
                }
            }
        }
    }
}

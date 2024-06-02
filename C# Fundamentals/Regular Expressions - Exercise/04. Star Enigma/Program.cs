using System.Text;
using System.Text.RegularExpressions;

internal class Program
{
    static void Main()
    {
        List<Planet> planets = new List<Planet>();

        int mesCount = int.Parse(Console.ReadLine());

        string starPattern = @"[SsTtAaRr]";
        string mesPattern = @"\@(?<planet>[A-Za-z]+)[^\@\-\!\:\>]*\:(?<population>\d+)[^\@\-\!\:\>]*\!(?<type>A|D)\![^\@\-\!\:\>]*\-\>[^\@\-\!\:\>]*?(?<soldiers>\d+)[^\@\-\!\:\>]*";

        for (int i = 0; i < mesCount; i++)
        {
            string encryptedMes = Console.ReadLine();

            int decryptionKey = Regex.Matches(encryptedMes, starPattern).Count;

            StringBuilder decryptedMesBuilder = new StringBuilder();
            for (int j = 0; j < encryptedMes.Length; j++)
            {
                decryptedMesBuilder.Append((char)(encryptedMes[j] - decryptionKey));
            }

            string decryptedMes = decryptedMesBuilder.ToString();

            var match = Regex.Match(decryptedMes, mesPattern);
            if (!Regex.IsMatch(decryptedMes, mesPattern))
            {
                continue;
            }

            string planetName = match.Groups["planet"].Value;
            uint population = uint.Parse(match.Groups["population"].Value);
            string attackType = match.Groups["type"].Value;
            uint soldierCount = uint.Parse(match.Groups["soldiers"].Value);

            planets.Add(new Planet(planetName, population, attackType, soldierCount));
        }

        List<Planet> attackedPlanets = planets.Where(m => m.AttackType == "A")
            .OrderBy(m => m.PlanetName)
            .ToList();

        Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
        attackedPlanets.ForEach(m => Console.WriteLine($"-> {m.PlanetName}"));

        List<Planet> destroyedPlanets = planets.Where(m => m.AttackType == "D")
            .OrderBy(m => m.PlanetName)
            .ToList();

        Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
        destroyedPlanets.ForEach(m => Console.WriteLine($"-> {m.PlanetName}"));
    }
    class Planet
    {
        public Planet()
        {
        }

        public Planet(string planetName, uint population, string attackType, uint soldierCount)
        {
            PlanetName = planetName;
            Population = population;
            AttackType = attackType;
            SoldierCount = soldierCount;
        }

        public string PlanetName { get; set; }

        public uint Population { get; set; }

        public string AttackType { get; set; }

        public uint SoldierCount { get; set; }
    }
}
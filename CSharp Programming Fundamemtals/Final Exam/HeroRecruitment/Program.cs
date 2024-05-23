namespace HeroRecruitment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> enrolledHeroes = new();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] commandTokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = commandTokens[0];
                string heroName = commandTokens[1];
                string spellName;

                heroName[2] = "m";
                switch (command)
                {
                    case "Enroll":
                        if(!enrolledHeroes.ContainsKey(heroName)) 
                        {
                            enrolledHeroes.Add(heroName, new List<string>());
                            continue;
                        }
                        Console.WriteLine($"{heroName} is already enrolled.");
                        break;
                    case "Learn":
                        spellName = commandTokens[2];

                        if (!enrolledHeroes.ContainsKey(heroName))
                        {
                            Console.WriteLine($"{heroName} doesn't exist.");
                            continue;
                        }
                        else if (enrolledHeroes[heroName].Contains(spellName))
                        {
                            Console.WriteLine($"{heroName} has already learnt {spellName}.");
                            continue;
                        }
                        enrolledHeroes[heroName].Add(spellName);
                        break;
                    case "Unlearn":
                        spellName = commandTokens[2];

                        if (!enrolledHeroes.ContainsKey(heroName))
                        {
                            Console.WriteLine($"{heroName} doesn't exist.");
                            continue;
                        }
                        else if (!enrolledHeroes[heroName].Contains(spellName))
                        {
                            Console.WriteLine($"{heroName} doesn't know {spellName}.");
                            continue;
                        }
                        enrolledHeroes[heroName].Remove(spellName);
                        break;
                }
            }

            Console.WriteLine("Heroes:");
            foreach (var (heroName, spells) in enrolledHeroes)
            {
                Console.WriteLine($"== {heroName}: {String.Join(", ", spells)}");
            }
        }
    }
}

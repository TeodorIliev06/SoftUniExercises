﻿namespace Raiding;

public class StartUp
{
    static void Main(string[] args)
    {
        List<BaseHero> list = new();
        int heroCount = int.Parse(Console.ReadLine());
        while (list.Count < heroCount)
        {
            string heroName = Console.ReadLine();
            string heroType = Console.ReadLine();
            switch (heroType)
            {
                case "Druid":
                    list.Add(new Druid(heroName));
                    break;
                case "Paladin":
                    list.Add(new Paladin(heroName));
                    break;
                case "Rogue":
                    list.Add(new Rogue(heroName));
                    break;
                case "Warrior":
                    list.Add(new Warrior(heroName));
                    break;
                default:
                    Console.WriteLine("Invalid hero!");
                    break;
            }
        }

        list.ForEach(h => Console.WriteLine(h.CastAbility()));

        int result = list.Sum(h => h.Power);
        int bossPower = int.Parse(Console.ReadLine());
        Console.WriteLine(result >= bossPower ? "Victory!" : "Defeat...");
    }
}

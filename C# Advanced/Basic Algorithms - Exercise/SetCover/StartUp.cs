namespace SetCover;

using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main(string[] args)
    {
        int[] universe = ReadIntArr();
        int setsCount = int.Parse(Console.ReadLine());

        int[][] sets = new int[setsCount][];
        for (int row = 0; row < setsCount; row++)
        {
            sets[row] = ReadIntArr();
        }

        List<int[]> selectedSets = ChooseSets(sets.ToList(), universe.ToList());
        Console.WriteLine($"Sets to take ({selectedSets.Count}):");

        foreach (var set in selectedSets)
        {
            Console.WriteLine($"{{ {string.Join(", ", set)} }}");
        }
    }

    public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
    {
        List<int[]> selectedSets = new();

        while (universe.Any())
        {
            int[] longestSet = sets
                .OrderByDescending(s => s.Count(e => universe.Contains(e)))
                .FirstOrDefault();

            selectedSets.Add(longestSet);
            sets.Remove(longestSet);

            foreach (var element in longestSet)
            {
                universe.Remove(element);
            }
        }

        return selectedSets;
    }
    private static int[] ReadIntArr()
    {
        return Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
    }
}
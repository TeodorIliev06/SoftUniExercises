namespace SumOfCoins;

using System.Collections.Generic;

public class StartUp
{
    public static void Main(string[] args)
    {
        int[] coinValues = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .OrderByDescending(x => x)
            .ToArray();

        int targetSum = int.Parse(Console.ReadLine());

        try
        {
            Dictionary<int, int> chosenCoins = ChooseCoins(coinValues, targetSum);

            Console.WriteLine($"Number of coins to take: {chosenCoins.Values.Sum()}");
            foreach (var coin in chosenCoins)
            {
                Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
            }
        }
        catch (InvalidOperationException IOE)
        {
            Console.WriteLine("Error");
        }
    }

    public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
    {
        Dictionary<int, int> usedCoins = new Dictionary<int, int>();

        foreach (var coin in coins)
        {
            //How many coins can be used to reach the target
            int coinsToTake = targetSum / coin;
            if (coinsToTake > 0)
            {
                //Add the coin value as well as the count
                usedCoins.Add(coin, coinsToTake);
                targetSum -= coinsToTake * coin;
            }
        }

        if (targetSum != 0)
        {
            throw new InvalidOperationException("Error");
        }

        return usedCoins;
    }
}
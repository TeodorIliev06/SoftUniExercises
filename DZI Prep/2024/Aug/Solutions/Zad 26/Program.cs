namespace Zad_26
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int months = int.Parse(Console.ReadLine());
            int[] winnings = new int[months];

            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < winnings.Length; i++)
            {
                winnings[i] = input[i];
            }

            var longestStreak = 1;
            var currentStreak = 1;
            var smallestWinningsIndex = 0;
            for (int i = 1; i < winnings.Length; i++)
            {
                var currentMonthWinnings = input[i];
                var lastMonthWinnings = input[i - 1];
                if (currentMonthWinnings >= lastMonthWinnings)
                {
                    currentStreak++;
                    if (currentStreak > longestStreak)
                    {
                        longestStreak = currentStreak;
                    }

                    continue;
                }

                smallestWinningsIndex = i;
                currentStreak = 1;
            }

            int closestProfit;
            int smallestProfit = winnings[smallestWinningsIndex];

            if (smallestWinningsIndex == winnings.Length - 1)
            {
                closestProfit = winnings[smallestWinningsIndex - 1];
            }
            else
            {
                closestProfit = winnings[smallestWinningsIndex + 1];
            }

            var percentage = (closestProfit - smallestProfit) / (double)closestProfit * 100;

            Console.WriteLine($"The longest period with bigger profit is {longestStreak} months");
            Console.WriteLine($"Smaller with {percentage:f2}%");
            //10
            //5 3 4 6 7 1 2 3 4 5
        }
    }
}

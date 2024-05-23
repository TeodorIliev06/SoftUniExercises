namespace _03._The_Angry_Cat;

internal class Program
{
    static void Main(string[] args)
    {
        int[] priceRatings = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        int entryPoint = int.Parse(Console.ReadLine());
        string itemsType = Console.ReadLine();

        int leftSum = 0, rightSum = 0;
        for (int i = entryPoint - 1; i >= 0; i--)
        {
            switch (itemsType)
            {
                case "cheap":
                    leftSum += priceRatings[i] < priceRatings[entryPoint] ? priceRatings[i] : 0;
                    break;
                case "expensive":
                    leftSum += priceRatings[i] >= priceRatings[entryPoint] ? priceRatings[i] : 0;
                    break;
            }
        }

        for (int i = entryPoint + 1; i < priceRatings.Length; i++)
        {
            switch (itemsType)
            {
                case "cheap":
                    rightSum += priceRatings[i] < priceRatings[entryPoint] ? priceRatings[i] : 0;
                    break;
                case "expensive":
                    rightSum += priceRatings[i] >= priceRatings[entryPoint] ? priceRatings[i] : 0;
                    break;
            }
        }

        if (leftSum >= rightSum)
        {
            Console.WriteLine($"Left - {leftSum}");
        }
        else
        {
            Console.WriteLine($"Right - {rightSum}");
        }
    }
}

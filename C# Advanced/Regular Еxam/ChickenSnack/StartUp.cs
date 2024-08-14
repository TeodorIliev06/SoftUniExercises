namespace ChickenSnack;

public class StartUp
{
    static void Main(string[] args)
    {
        int[] fisrtSeq = ReadIntArray();
        Stack<int> amount = new(fisrtSeq);

        int[] secondSeq = ReadIntArray();
        Queue<int> prices = new(secondSeq);

        int currentChange = 0;
        int eatenFoods = 0;

        while (amount.Any() && prices.Any())
        {
            int currAmount = amount.Peek();
            int currPrice = prices.Peek();

            if (currAmount == currPrice)
            {
                amount.Pop();
                prices.Dequeue(); 
                eatenFoods++;
            }
            else if (currAmount < currPrice)
            {
                amount.Pop();
                prices.Dequeue();
            }
            else
            {
                currentChange += amount.Pop() - prices.Dequeue(); 
                eatenFoods++;
                if (amount.Any())
                {
                    int nextElement = amount.Pop();
                    amount.Push(nextElement + currentChange);
                }
            }
        }
        if (eatenFoods >= 4)
        {
            Console.WriteLine($"Gluttony of the day! Henry ate {eatenFoods} foods.");
        }
        else if (eatenFoods == 1)
        {
            Console.WriteLine($"Henry ate: {eatenFoods} food.");
        }
        else if (eatenFoods > 0)
        {
            Console.WriteLine($"Henry ate: {eatenFoods} foods.");
        }
        else
        {
            Console.WriteLine("Henry remained hungry. He will try next weekend again.");
        }
    }

    private static int[] ReadIntArray()
    {
        return Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
    }
}

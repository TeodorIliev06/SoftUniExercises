namespace _12._Cups_and_Bottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cups = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            var bottles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            int excessWater = 0;
            int value = 0;

            while (cups.Count != 0 && bottles.Count != 0)
            {
                if (bottles.Peek() > cups.Peek())
                {
                    excessWater += bottles.Pop() - cups.Dequeue();
                }
                else if (bottles.Peek() == cups.Peek())
                {
                    bottles.Pop();
                    cups.Dequeue();
                }
                else if (bottles.Peek() < cups.Peek())
                {
                    while (cups.Peek() > value)
                    {
                        value += bottles.Pop();
                    }
                    excessWater += value - cups.Dequeue();
                    value = 0;
                }
            }
            if (cups.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
                Console.WriteLine($"Wasted litters of water: {excessWater}");
            }
            else if (bottles.Count == 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
                Console.WriteLine($"Wasted litters of water: {excessWater}");
            }
        }
    }
}

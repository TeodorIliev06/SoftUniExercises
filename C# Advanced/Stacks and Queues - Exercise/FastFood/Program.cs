namespace _04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int orders = int.Parse(Console.ReadLine());
            Queue<int> ordersQueue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            Console.WriteLine(ordersQueue.Max());

            while (true)
            {
                if (ordersQueue.Count == 0)
                {
                    Console.WriteLine("Orders complete");
                    break;
                }

                if (orders >= ordersQueue.Peek())
                {
                    orders -= ordersQueue.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(" ", ordersQueue)}");
                    break;
                }

            }
        }
    }
}

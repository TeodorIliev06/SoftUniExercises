namespace _07._Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            var pumpsQueue = new Queue<int[]>();

            for (int i = 0; i < lines; i++)
            {
                var pumpInfo = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                pumpsQueue.Enqueue(pumpInfo);
            }

            int currPosition = 0;
            while (true)
            {
                int currFuel = 0;
                foreach (var pump in pumpsQueue)
                {
                    int fuel = pump[0];
                    int distance = pump[1];
                    currFuel += fuel - distance;

                    if (currFuel >= 0)
                    {
                        continue;
                    }

                    currPosition++;
                    pumpsQueue.Enqueue(pumpsQueue.Dequeue());
                    break;
                }
                if (currFuel >= 0)
                {
                    Console.WriteLine(currPosition);
                    return;
                }
            }
        }
    }
}

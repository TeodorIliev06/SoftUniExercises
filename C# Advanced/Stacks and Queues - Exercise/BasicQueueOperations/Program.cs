namespace _02._Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputInfo = Console.ReadLine()
                .Split().
                Select(int.Parse).
                ToArray();

            int[] seq = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int elementsToEnqueue = inputInfo[0];
            int elementsToDequeue = inputInfo[1];
            int searchedElement = inputInfo[2];

            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < elementsToEnqueue; i++)
            {
                queue.Enqueue(seq[i]);
            }

            for (int i = 0; i < elementsToDequeue; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(searchedElement))
            {
                Console.WriteLine("true");
            }
            else if (queue.Any())
            {
                Console.WriteLine(queue.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}

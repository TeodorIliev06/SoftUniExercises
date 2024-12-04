namespace _06.CalculateSequenceQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Queue<int> numbers = new Queue<int>();

            numbers.Enqueue(num);
            Console.Write(numbers.Peek() + ", ");

            for (int i = 0; i < 50; i += 3)
            {
                int current = numbers.Dequeue();

                int next1 = current + 1;
                EnqueueAndPrint(numbers, next1);

                int next2 = 2 * current + 1;
                EnqueueAndPrint(numbers, next2);

                int next3 = current + 2;
                EnqueueAndPrint(numbers, next3);
            }
        }

        private static void EnqueueAndPrint(Queue<int> numbers, int next1)
        {
            numbers.Enqueue(next1);
            Console.Write(next1 + ", ");
        }
    }
}

namespace _01._Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputInfo = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] seq = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int elementsToPush = inputInfo[0];
            int elementsToPop = inputInfo[1];
            int searchedElement = inputInfo[2];

            Stack<int> stack = new Stack<int>();
            for(int i = 0; i < elementsToPush; i++)
            {
                stack.Push(seq[i]);
            }

            for(int i = 0;i < elementsToPop; i++)
            {
                stack.Pop();
            }

            if(stack.Contains(searchedElement))
            {
                Console.WriteLine("true");
            }
            else if (stack.Any())
            {
                Console.WriteLine(stack.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}

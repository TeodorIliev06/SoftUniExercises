namespace _03._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numbers = new Stack<int>();
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                int[] commandInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();

                int command = commandInfo[0];
                switch (command)
                {
                    case 1:
                        int numToPush = commandInfo[1];
                        numbers.Push(numToPush);
                        break;

                    case 2:
                        numbers.Pop();
                        break;

                    case 3:
                        if (numbers.Count != 0)
                        {
                            Console.WriteLine(numbers.Max());
                        }
                        break;

                    case 4:
                        if (numbers.Count != 0)
                        {
                            Console.WriteLine(numbers.Min());
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}

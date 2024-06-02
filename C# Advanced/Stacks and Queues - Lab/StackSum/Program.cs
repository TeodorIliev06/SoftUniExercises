namespace _02._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numbers = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            string command;
            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                string[] arguments = command.Split();
                string operation = arguments[0];
                int num1 = int.Parse(arguments[1]);

                switch (operation)
                {
                    case "add":
                        int num2 = int.Parse(arguments[2]);
                        numbers.Push(num1);
                        numbers.Push(num2);
                        break;

                    case "remove":
                        if (numbers.Count > num1)
                        {
                            for (int i = 0; i < num1; i++)
                            {
                                numbers.Pop();
                            }
                        }
                        else 
                        {
                            continue; 
                        }

                        break;
                }
            }
            Console.WriteLine($"Sum: {numbers.Sum()}");
        }
    }
}

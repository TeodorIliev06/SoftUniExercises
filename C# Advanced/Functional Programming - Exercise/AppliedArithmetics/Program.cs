namespace _05._Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            Func<string, List<int>, List<int>> calculations = (activity, numbersList) =>
            {
                List<int> resultList = new List<int>();
                foreach (var item in numbersList)
                {
                    switch (activity)
                    {
                        case "add":
                            resultList.Add(item + 1);
                            break;
                        case "multiply":
                            resultList.Add(item * 2);
                            break;
                        case "subtract":
                            resultList.Add(item - 1);
                            break;
                    }
                }

                return resultList;
            };

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "print")
                {
                    Console.WriteLine(string.Join(" ", numbers));
                }
                else
                {
                    numbers = calculations(command, numbers);
                }
            }
        }
    }
}

namespace _06._Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> customers = new Queue<string>(Console.ReadLine().Split());

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                if (command == "Paid")
                {
                    while (customers.Count != 0)
                    {
                        Console.WriteLine(customers.Dequeue());
                    }
                }
                else
                {
                    customers.Enqueue(command);
                }
            }

            Console.WriteLine($"{customers.Count} people remaining.");
        }
    }
}

namespace _07._Moving
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int V = a * b * c;
            string command;

            while ((command = Console.ReadLine()) != "Done")
            {                             
                int boxesCount = int.Parse(command);
                if (boxesCount > V)
                {
                    Console.WriteLine($"No more free space! You need {boxesCount - V} Cubic meters more.");
                    break;
                }
                V -= boxesCount;
            }
            if (command == "Done")
            {
                Console.WriteLine($"{V} Cubic meters left.");
            }
        }
    }
}
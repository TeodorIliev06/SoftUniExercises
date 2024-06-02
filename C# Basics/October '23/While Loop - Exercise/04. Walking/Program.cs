namespace _04._Walking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int steps = 0;

            while (steps < 10_000)
            {
                string command = Console.ReadLine();
                if (command == "Going home")
                {
                    int finalsteps = int.Parse(Console.ReadLine());
                    steps += finalsteps;
                    break;
                }
                else
                {
                    steps += int.Parse(command);
                }
            }
            if (steps < 10_000)
            {
                Console.WriteLine($"{10000 - steps} more steps to reach goal.");
            }
            if (steps >= 10_000)
            {
                Console.WriteLine($"Goal reached! Good job!");
                Console.WriteLine($"{steps - 10_000} steps over the goal!");
            }
        }
    }
}
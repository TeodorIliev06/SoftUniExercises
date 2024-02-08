namespace _05._Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string pass = string.Empty;
            int attemptsCounter = 0;

            for (int i = name.Length - 1; i >= 0; i--)
            {
                pass += name[i];
            }

            while (true)
            {
                string guess = Console.ReadLine();
                if (guess == pass)
                {
                    Console.WriteLine($"User {name} logged in.");
                    return;
                }
                else
                {
                    attemptsCounter++;
                    if (attemptsCounter >= 4)
                    {
                        Console.WriteLine($"User {name} blocked!");
                        break;
                    }
                    Console.WriteLine("Incorrect password. Try again.");
                }
            }
        }
    }
}
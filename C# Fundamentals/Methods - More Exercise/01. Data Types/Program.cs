namespace _01._Data_Types
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string command = Console.ReadLine();
            Convert(type, command);
        }

        private static void Convert(string type, string command)
        {
            if (type == "int")
            {
                int num = int.Parse(command) * 2;
                Console.WriteLine(num);
            }
            if (type == "real")
            {
                double num = double.Parse(command) * 1.5;
                Console.WriteLine($"{num:f2}");
            }
            if (type == "string")
            {
                Console.WriteLine($"${command}$");
            }
        }
    }
}
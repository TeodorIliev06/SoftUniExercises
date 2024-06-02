namespace _06._Cake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int piecesCount = width * lenght;
            string command;

            while ((command = Console.ReadLine()) != "STOP")
            {                 
                
                int piecesToTake = int.Parse(command);
                if (piecesToTake > piecesCount)
                {
                    Console.WriteLine($"No more cake left! You need {piecesToTake - piecesCount} pieces more.");
                    break;
                }
                piecesCount -= piecesToTake;
            }
            if (command == "STOP")
            {
                Console.WriteLine($"{piecesCount} pieces are left.");
            }
        }
    }
}
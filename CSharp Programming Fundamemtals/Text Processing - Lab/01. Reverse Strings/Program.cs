using System.Linq;
namespace _01._Reverse_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command;
            string reversed;

            while ((command = Console.ReadLine()) != "end")
            {
                reversed = string.Join("", command.Reverse());
                Console.WriteLine($"{command} = {reversed}");
            }
        }
    }
}
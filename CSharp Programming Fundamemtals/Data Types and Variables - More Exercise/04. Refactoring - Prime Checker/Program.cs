using System;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace _04._Refactoring___Prime_Checker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            for (int i = 2; i <= num; i++)
            {
                string isPrime = "true";
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = "false";
                        break;
                    }
                }
                Console.WriteLine("{0} -> {1}", i, isPrime);
            }
        }
    }
}
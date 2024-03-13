using System.Text.RegularExpressions;

namespace _11._Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string input = string.Empty;
            string[] command;

            while (true)
            {

                input = Console.ReadLine();

                if (input == "end")
                {
                    Console.Write($"[{string.Join(", ", numbers)}]");
                    break;
                }

                command = input.Split().ToArray();

                if (command[0] == "exchange")
                {

                    int n = int.Parse(command[1]);

                    if (n >= 0 && n < numbers.Length)
                    {
                        numbers = RotateArray(numbers, n);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if (command[0] == "max")
                {
                    GetMaxOddOrMaxEven(numbers, command[1]);
                }
                else if (command[0] == "min")
                {
                    GetMinOddOrMinEven(numbers, command[1]);
                }
                else if (command[0] == "first")
                {
                    GetFirstOddOrFirstEven(numbers, int.Parse(command[1]), command[2]);
                }
                else if (command[0] == "last")
                {
                    GetLastOddOrLastEven(numbers, int.Parse(command[1]), command[2]);
                }
            }
        }
        static int[] RotateArray(int[] numbers, int num)
        {
            int numLen = numbers.Length;
            int[] rotatedArr = new int[numLen];            
            int n = num + 1;

            for (int i = 0; i < numLen; i++)
            {
                if (n >= numLen)
                {
                    n = 0;
                }
                rotatedArr[i] = numbers[n];
                n++;
            }
            return rotatedArr;
        }
        static void GetMaxOddOrMaxEven(int[] numbers, string str)
        {
            if (str == "odd")
            {
                if (numbers.Any(x => x % 2 == 1))
                {
                    int maxOdd = numbers.Where(x => x % 2 == 1).Max();

                    int positionMaxOdd = numbers.ToList().LastIndexOf(maxOdd);

                    Console.WriteLine(positionMaxOdd);
                }
                else
                {
                    Console.WriteLine("No matches");
                }
            }
            if (str == "even")
            {
                if (numbers.Any(x => x % 2 == 0))
                {
                    int maxEven = numbers.Where(x => x % 2 == 0).Max();

                    int positionMaxEven = numbers.ToList().LastIndexOf(maxEven);

                    Console.WriteLine(positionMaxEven);
                }
                else
                {
                    Console.WriteLine("No matches");
                }
            }
        }
        static void GetMinOddOrMinEven(int[] numbers, string n)
        {
            if (n == "odd")
            {
                if (numbers.Any(x => x % 2 == 1))
                {
                    int minOdd = numbers.Where(x => x % 2 == 1).Min();

                    int positionMinOdd = numbers.ToList().LastIndexOf(minOdd);

                    Console.WriteLine(positionMinOdd);
                }
                else
                {
                    Console.WriteLine("No matches");
                }
            }
            if (n == "even")
            {
                if (numbers.Any(x => x % 2 == 0))
                {
                    int minEven = numbers.Where(x => x % 2 == 0).Min();

                    int positionMinEven = numbers.ToList().LastIndexOf(minEven);

                    Console.WriteLine(positionMinEven);
                }
                else
                {
                    Console.WriteLine("No matches");
                }
            }
        }
        static void GetFirstOddOrFirstEven(int[] numbers, int n, string oddEven)
        {
            int numLen = numbers.Length;
            if (n > numLen)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            List<int> sequence = new List<int>();

            if (oddEven == "odd")
            {
                if (numbers.Any(x => x % 2 == 1))
                {
                    sequence = numbers.Where(x => x % 2 == 1).ToList();
                }
            }
            else if (oddEven == "even")
            {
                if (numbers.Any(x => x % 2 == 0))
                {
                    sequence = numbers.Where(x => x % 2 == 0).ToList();
                }
            }

            Console.WriteLine($"[{string.Join(", ", sequence.Take(Math.Min(n, sequence.Count)).ToList())}]");
        }
        static void GetLastOddOrLastEven(int[] numbers, int n, string oddEven)
        {
            int numLen = numbers.Length;
            if (n > numLen)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            List<int> sequence = new List<int>();

            if (oddEven == "odd")
            {
                if (numbers.Any(x => x % 2 == 1))
                {
                    sequence = numbers.Where(x => x % 2 == 1).ToList();
                }
            }
            else if (oddEven == "even")
            {
                if (numbers.Any(x => x % 2 == 0))
                {
                    sequence = numbers.Where(x => x % 2 == 0).ToList();
                }
            }
            Console.WriteLine($"[{string.Join(", ", sequence.TakeLast(Math.Min(n, sequence.Count)).ToList())}]");
        }
    }
}
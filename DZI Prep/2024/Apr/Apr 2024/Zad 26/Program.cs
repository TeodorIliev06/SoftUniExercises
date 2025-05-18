namespace Zad_26
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
72 67 128 1 79
144 121
86 13 256
16 85 9 83
169
END
EvenOddSort 
EvenSymmetry 
Conversion 
Unique 
SortByDigitSum 
Conversion 
Unique 
STOP 
             */
            var numbers = new List<int>();

            string line;
            while ((line = Console.ReadLine()) != "END")
            {
                var input = line.Split().Select(int.Parse).ToArray();
                numbers.AddRange(input);
            }

            while ((line = Console.ReadLine()) != "STOP")
            {
                switch (line)
                {
                    case "Conversion":
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            int currentSum = GetSumOfDigits(numbers[i]);

                            numbers[i] = currentSum;
                        }

                        break;
                    case "Unique":
                        numbers = numbers
                            .Distinct()
                            .OrderBy(x => x)
                            .ToList();

                        break;
                    case "EvenOddSort":
                        //Functional approach
                        //numbers = numbers
                        //    .Where(x => x % 2 == 0).OrderBy(x => x)
                        //    .Concat(numbers
                        //        .Where(x => x % 2 != 0)
                        //        .OrderByDescending(x => x))
                        //    .ToList();

                        //Imperative approach
                        var evens = new List<int>();
                        var odds = new List<int>();

                        foreach (int num in numbers)
                        {
                            if (num % 2 == 0) evens.Add(num);
                            else odds.Add(num);
                        }

                        evens.Sort();
                        odds.Sort((a, b) => b.CompareTo(a));

                        numbers.Clear();
                        numbers.AddRange(evens);
                        numbers.AddRange(odds);

                        break;
                    case "EvenSymmetry":
                        for (int i = 0; i < numbers.Count / 2; i++)
                        {
                            if (i % 2 == 0)
                            {
                                (numbers[i], numbers[numbers.Count - i - 1]) =
                                    (numbers[numbers.Count - i - 1], numbers[i]);
                            }
                        }

                        break;
                    case "SortByDigitSum":
                        numbers.Sort((a, b) =>
                            GetSumOfDigits(a).CompareTo(GetSumOfDigits(b)));
                        break;
                }

                Console.WriteLine(string.Join(' ', numbers));
            }
        }

        private static int GetSumOfDigits(int number)
        {
            int sum = 0;
            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }

            return sum;
        }
    }
}

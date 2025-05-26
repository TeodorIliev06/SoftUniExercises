namespace Zad_25
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numberOccurrences = new Dictionary<uint, uint>();
            try
            {
                bool isInputCorrect = false;
                uint lines = 0;

                while (!isInputCorrect)
                {
                    lines = uint.Parse(Console.ReadLine());
                    isInputCorrect = IsPositive(lines);

                    if (!isInputCorrect)
                    {
                        Console.WriteLine("Please enter a positive number!");
                    }
                }

                var elements = new uint[lines];
                for (uint i = 0; i < lines; i++)
                {
                    isInputCorrect = false;
                    while (!isInputCorrect)
                    {
                        elements[i] = uint.Parse(Console.ReadLine());
                        isInputCorrect = IsPositive(elements[i]);

                        if (!isInputCorrect)
                        {
                            Console.WriteLine("Please enter a positive number!");
                        }
                    }

                    if (!numberOccurrences.ContainsKey(elements[i]))
                    {
                        numberOccurrences.Add(elements[i], 1);
                        continue;
                    }

                    numberOccurrences[elements[i]]++;
                }

                foreach (var (number, occurrences) in numberOccurrences
                             .OrderByDescending(kvp => kvp.Value))
                {
                    Console.WriteLine($"Number: {number}, count: {occurrences}");
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine("Incorrect input! Expected input type: uint");
                throw;
            }
        }

        static bool IsPositive(uint num)
        {
            if (num < 1)
            {
                return false;
            }

            return true;
        }
    }
}

namespace Zad_26
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var digitsCount = new Dictionary<int, int>();

            //int a = int.Parse(Console.ReadLine());
            //int b = int.Parse(Console.ReadLine());

            //for (int i = a; i <= b; i++) 
            //{
            //    var currentNumber = i;

            //    while (currentNumber > 0) 
            //    {
            //        var digit = currentNumber % 10;
            //        currentNumber /= 10;

            //        if (!digitsCount.ContainsKey(digit))
            //        {
            //            digitsCount.Add(digit, 1);
            //            continue;
            //        }

            //        digitsCount[digit]++;
            //    }
            //}

            //var output = digitsCount
            //    .OrderByDescending(kvp => kvp.Value)
            //    .ThenBy(kvp => kvp.Key)
            //    .First();

            //Console.WriteLine($"Digit {output.Key} - {output.Value} times");

            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            var digitsCount = new Dictionary<int, int>();

            for (int i = a; i <= b; i++)
            {
                var currentNumber = i;
                while (currentNumber > 0)
                {
                    var currentDigit = currentNumber % 10;
                    currentNumber /= 10;

                    if (!digitsCount.ContainsKey(currentDigit))
                    {
                        digitsCount.Add(currentDigit, 1);
                        continue;
                    }

                    digitsCount[currentDigit]++;
                }
            }

            var mostCommonPair = digitsCount
                .OrderByDescending(p => p.Value)
                .ThenBy(p => p.Key)
                .First();
            Console.WriteLine($"Digit {mostCommonPair.Key} - {mostCommonPair.Value} times");
        }
    }
}

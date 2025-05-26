namespace Zad_26
{
    internal class Program
    {
        /*
           15
           75.125
           86.257
           85.235
           99.9
           -5
           0
           94.235
           -2
           90.135
           81.145
           0
           86.257
           97.145
           86.257
           97.145
         */
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            var validWorks = ReadPoints(lines);
            
            validWorks.Sort((a, b) => b.CompareTo(a));

            Console.WriteLine($"valid works - {validWorks.Count}");
            Console.WriteLine($"minimal difference - {MinDpoints(validWorks):F3} p.");
            Console.WriteLine($"laureates - {Laureates(validWorks)}");
        }

        private static List<double> ReadPoints(int lines) 
        {
            var validWorks = new List<double>();

            for (int i = 0; i < lines; i++)
            {
                double currentPoints = double.Parse(Console.ReadLine());
                if (currentPoints > 0)
                {
                    validWorks.Add(currentPoints);
                }
            }

            return validWorks;
        }

        private static double MinDpoints(List<double> validWorks)
        {
            double minDifference = 101;
            for (int i = 1; i < validWorks.Count; i++)
            {
                var currentDifference = validWorks[i-1] - validWorks[i];

                if (currentDifference == 0)
                {
                    continue;
                }

                if (currentDifference < minDifference)
                {
                    minDifference = currentDifference;
                }
            }

            return minDifference;
        }

        private static int Laureates(List<double> validWorks)
        {
            var orderedWorks = validWorks
                .OrderByDescending(x => x)
                .Take(3)
                .ToArray();
            var laureatesCount = validWorks.Count(w => w >= orderedWorks.Last());

            return laureatesCount;
        }
    }
}

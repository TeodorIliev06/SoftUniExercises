namespace _01._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToList();
            Dictionary<double, int> numbersOccurences = new Dictionary<double, int>();

            foreach (var number in numbers)
            {
                if (!numbersOccurences.ContainsKey(number))
                {
                    numbersOccurences[number] = 0;
                }
                numbersOccurences[number]++;
            }

            foreach (var kvp in numbersOccurences)
            {
                Console.WriteLine($"{string.Join(", ", kvp.Key)} - {kvp.Value} times");
            }
        }
    }
}

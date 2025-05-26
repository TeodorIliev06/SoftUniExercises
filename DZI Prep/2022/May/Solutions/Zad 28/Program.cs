namespace Zad_28
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = GetListFromFile(@"..\..\..\input.txt");
            RemoveNumbers(numbers, 4);
            OrderBySum(numbers);

            Console.WriteLine(string.Join(' ', numbers));
        }

        public static int SumOfDigits(int number)
        {
            int sum = 0;
            while (number != 0)
            {
                sum += number % 10;
                number /= 10;
            }
            return sum;
        }

        public static void RemoveNumbers(List<int> numbers, int k)
        {
            int sum;
            for (int i = 0; i < numbers.Count; i++)
            {
                sum = SumOfDigits(numbers[i]);

                if (sum % k == 0)
                {
                    numbers.Remove(numbers[i]);
                }
            }
        }

        public static void OrderBySum(List<int> numbers)
        {
            numbers.Sort((x, y) => SumOfDigits(x).CompareTo(SumOfDigits(y)));
        }

        public static List<int> GetListFromFile(string path)
        {
            var list = new List<int>();

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        try
                        {
                            int num = int.Parse(line);
                            list.Add(num);
                        }
                        catch (FormatException ex)
                        {
                            throw new FormatException(ex.Message);
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException();
            }
            

            return list;
        }
    }
}

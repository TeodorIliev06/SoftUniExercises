namespace _04._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int integersCount = int.Parse(Console.ReadLine());
            var numbers = new Dictionary<int, int>();

            for (int i = 0; i < integersCount; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (!numbers.ContainsKey(num))
                {
                    numbers.Add(num, 0);
                }
                numbers[num]++;
            }

            foreach (var item in numbers.Where(n => n.Value % 2 ==0))
            {
                Console.WriteLine(item.Key);
                return;
            }
        }
    }
}

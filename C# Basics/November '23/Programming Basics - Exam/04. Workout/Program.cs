namespace _04._Workout
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double km = double.Parse(Console.ReadLine());
            double rankm = km;

            for (int i = 1; i <= days; i++)
            {
                int increase = int.Parse(Console.ReadLine());
                km = km * increase / 100 + km;
                rankm += km;
            }
            if (rankm >= 1000)
            {
                Console.WriteLine($"You've done a great job running {Math.Ceiling(rankm - 1000)} more kilometers!");
            }
            else
            {
                Console.WriteLine($"Sorry Mrs. Ivanova, you need to run {Math.Ceiling(1000 - rankm)} more kilometers");
            }
        }
    }
}
namespace _03._Final_Competition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dancers = int.Parse(Console.ReadLine());
            double points = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string place = Console.ReadLine();

            double reward=0;

            switch (place) 
            {
                case "Bulgaria":
                    reward = dancers * points;
                    if (season == "summer")
                    {
                        reward *= 0.95;
                    }
                    else
                    {
                        reward *= 0.92;
                    }
                    break;
                case "Abroad":
                    reward = dancers * points * 1.5;
                    if (season == "summer")
                    {
                        reward *= 0.90;
                    }
                    else
                    {
                        reward *= 0.85;
                    }
                    break;
            }

            Console.WriteLine($"Charity - {(reward*0.75):f2}");

            reward *= 0.25;

            Console.WriteLine($"Money per dancer - {(reward/dancers):f2}");
        }
    }
}
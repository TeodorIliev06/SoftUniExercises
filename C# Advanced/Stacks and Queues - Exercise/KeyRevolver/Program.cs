namespace _11._Key_Revolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int price = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Queue<int> locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            int valueOfIntelligence = int.Parse(Console.ReadLine());
            int bulletsShot = 0;
            int initialBulletsCount = bullets.Count;

            while (bullets.Count != 0 && locks.Count != 0)
            {

                if (bullets.Peek() <= locks.Peek())
                {
                    locks.Dequeue();
                    bullets.Pop();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                    bullets.Pop();
                }

                bulletsShot++;
                if (bullets.Count > 0 && bulletsShot == gunBarrelSize)
                {
                    Console.WriteLine("Reloading!");
                    bulletsShot = 0;
                }
            }

            if (bullets.Count >= 0 && locks.Count == 0)
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${valueOfIntelligence - (initialBulletsCount - bullets.Count) * price}");
            }
            else if (locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}
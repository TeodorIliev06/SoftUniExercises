namespace Beesy
{
    internal class Program
    {
        private static int requiredNectar = 30;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] field = new char[n, n];

            int beeRow = 0, beeCol = 0,
                energy = 15, nectar = 0;

            bool restored = false;
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    field[i, j] = line[j];
                    if (line[j] == 'B')
                    {
                        beeRow = i;
                        beeCol = j;
                        field[i, j] = '-';
                    }
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                energy--;

                switch (command)
                {
                    case "up":
                        beeRow = beeRow - 1 >= 0 ? beeRow - 1 : n - 1;
                        break;
                    case "down":
                        beeRow = beeRow + 1 < n ? beeRow + 1 : 0;
                        break;
                    case "left":
                        beeCol = beeCol - 1 >= 0 ? beeCol - 1 : n - 1;
                        break;
                    case "right":
                        beeCol = beeCol + 1 < n ? beeCol + 1 : 0;
                        break;
                }

                if (Char.IsDigit(field[beeRow, beeCol]))
                {
                    nectar += int.Parse(field[beeRow, beeCol].ToString());
                    field[beeRow, beeCol] = '-';
                }

                if (field[beeRow, beeCol] == 'H')
                {
                    if (nectar >= requiredNectar)
                    {
                        Console.WriteLine($"Great job, Beesy! The hive is full. Energy left: {energy}");
                    }
                    else
                    {
                        Console.WriteLine("Beesy did not manage to collect enough nectar.");
                    }
                    field[beeRow, beeCol] = '-';
                    break;
                }

                if (energy <= 0)
                {
                    if (restored || nectar < requiredNectar)
                    {
                        Console.WriteLine("This is the end! Beesy ran out of energy.");
                        break;
                    }

                    restored = true;
                    energy += nectar - requiredNectar;
                    nectar = requiredNectar;

                    if (energy <= 0)
                    {
                        Console.WriteLine("This is the end! Beesy ran out of energy.");
                        break;
                    }
                }
            }

            field[beeRow, beeCol] = 'B';

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(field[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
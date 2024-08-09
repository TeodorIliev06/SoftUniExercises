namespace EscapeTheMaze
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] maze = new char[n, n];

            int travellerRow = 0, travellerCol = 0, health = 100;
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    maze[i, j] = line[j];
                    if (line[j] == 'P')
                    {
                        travellerRow = i;
                        travellerCol = j;
                        maze[i, j] = '-';
                    }
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                switch (command)
                {
                    case "up":
                        if (travellerRow - 1 >= 0)
                        {
                            travellerRow--;
                        }
                        break;
                    case "down":
                        if (travellerRow + 1 < n)
                        {
                            travellerRow++;
                        }
                        break;
                    case "left":
                        if (travellerCol - 1 >= 0)
                        {
                            travellerCol--;
                        }
                        break;
                    case "right":
                        if (travellerCol + 1 < n)
                        {
                            travellerCol++;
                        }
                        break;
                }

                if (maze[travellerRow, travellerCol] == 'M')
                {
                    if (health <= 40)
                    {
                        Console.WriteLine("Player is dead. Maze over!");
                        Console.WriteLine("Player's health: 0 units");
                        break;
                    }
                    else
                    {
                        maze[travellerRow, travellerCol] = '-';
                        health -= 40;
                    }
                }

                if (maze[travellerRow, travellerCol] == 'H')
                {
                    health += 15;
                    if (health > 100)
                    {
                        health = 100;
                    }
                    maze[travellerRow, travellerCol] = '-';
                }

                if (maze[travellerRow, travellerCol] == 'X')
                {
                    Console.WriteLine("Player escaped the maze. Danger passed!");
                    Console.WriteLine($"Player's health: {health} units");
                    break;
                }
            }

            maze[travellerRow, travellerCol] = 'P';

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(maze[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
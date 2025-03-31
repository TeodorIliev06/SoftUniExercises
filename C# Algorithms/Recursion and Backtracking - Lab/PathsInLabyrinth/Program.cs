using System;

namespace PathsInLabyrinth
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var labyrinth = new char[rows][];
            for (int row = 0; row < rows; row++)
            {
                labyrinth[row] = Console.ReadLine().ToCharArray();
            }

            FindPaths(labyrinth, 0, 0, new bool[rows, cols], "");
        }

        private static void FindPaths(char[][] labyrinth, int row, int col, bool[,] visited, string path)
        {
            if (labyrinth[row][col] == 'e')
            {
                Console.WriteLine(path);
                return;
            }

            visited[row, col] = true;

            if (IsSafe(labyrinth, row + 1, col, visited))
            {
                FindPaths(labyrinth, row + 1, col, visited, $"{path}D");
            }
            if (IsSafe(labyrinth, row - 1, col, visited))
            {
                FindPaths(labyrinth, row - 1, col, visited, $"{path}U");
            }
            if (IsSafe(labyrinth, row, col + 1, visited))
            {
                FindPaths(labyrinth, row, col + 1, visited, $"{path}R");
            }
            if (IsSafe(labyrinth, row, col - 1, visited))
            {
                FindPaths(labyrinth, row, col - 1, visited, $"{path}L");
            }

            visited[row, col] = false;
        }

        private static bool IsSafe(char[][] labyrinth, int row, int col, bool[,] visited)
        {
            if (row < 0 || col < 0 ||
                row >= labyrinth.Length || col >= labyrinth[0].Length)
            {
                return false;
            }

            if (labyrinth[row][col] == '*' || visited[row, col])
            {
                return false;
            }

            return true;
        }
    }
}

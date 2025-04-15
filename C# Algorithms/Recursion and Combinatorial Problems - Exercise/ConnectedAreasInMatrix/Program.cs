using System;
using System.Collections.Generic;
using System.Linq;

namespace ConnectedAreasInMatrix
{
    public class Program
    {
        private class Area
        {
            public Area(int row, int col, int size)
            {
                Row = row;
                Col = col;
                Size = size;
            }

            public int Row { get; set; }
            public int Col { get; set; }
            public int Size { get; set; }
        }

        private static char[,] matrix;
        private static char wallCharacter = '*';
        private static char visitedCharacter = 'v';
        private static int size;
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var rowArray = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowArray[col];
                }
            }

            var areas = new List<Area>();
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    size = 0;
                    ExploreArea(row, col);

                    if (size > 0)
                    {
                        areas.Add(new Area(row, col, size));
                    }
                }
            }

            var sortedAreas = areas
                .OrderByDescending(s => s.Size)
                .ThenBy(s => s.Row)
                .ThenBy(s => s.Col)
                .ToList();

            Console.WriteLine($"Total areas found: {sortedAreas.Count}");

            int number = 1;
            foreach (var area in sortedAreas)
            {
                Console.WriteLine($"Area #{number++} at ({area.Row}, {area.Col}), size: {area.Size}");
            }
        }

        private static void ExploreArea(int row, int col)
        {
            if (IsOutside(row, col) || IsWall(row, col) || IsVisited(row, col))
            {
                return;
            }

            size++;
            matrix[row, col] = visitedCharacter;

            ExploreArea(row - 1, col);
            ExploreArea(row + 1, col);
            ExploreArea(row, col - 1);
            ExploreArea(row, col + 1);
        }

        private static bool IsVisited(int row, int col)
        {
            return matrix[row, col] == visitedCharacter;
        }

        private static bool IsWall(int row, int col)
        {
            return matrix[row, col] == wallCharacter;
        }

        private static bool IsOutside(int row, int col)
        {
            return row < 0 || col < 0 ||
                   row >= matrix.GetLength(0) ||
                   col >= matrix.GetLength(1);
        }
    }
}

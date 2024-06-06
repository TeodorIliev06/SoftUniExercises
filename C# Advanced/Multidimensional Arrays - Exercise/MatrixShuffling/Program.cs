namespace _04._Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var matrixSize = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];

            string[,] matrix = new string[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                var rowArr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowArr[col];
                }
            }

            string tempCoordinates;
            string command;
            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                string[] commandInfo = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string keyword = commandInfo[0];

                if (keyword == "swap" && commandInfo.Length == 5)
                {
                    int row1 = int.Parse(commandInfo[1]);
                    int col1 = int.Parse(commandInfo[2]);
                    int row2 = int.Parse(commandInfo[3]);
                    int col2 = int.Parse(commandInfo[4]);

                    if (AreValidCoordinates(matrix, row1, col1, row2, col2))
                    {
                        tempCoordinates = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = tempCoordinates;

                        for (int row = 0; row < rows; row++)
                        {
                            for (int col = 0; col < cols; col++)
                            {
                                Console.Write($"{matrix[row, col]} ");
                            }
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        private static bool AreValidCoordinates(string[,] matrix, int row1, int col1, int row2, int col2)
        {
            return (row1 >= 0 && row1 < matrix.GetLength(0)
                    && col1 >= 0 && col1 < matrix.GetLength(1)
                    && row2 >= 0 && row2 < matrix.GetLength(0)
                    && col2 >= 0 && col2 < matrix.GetLength(1));
        }
    }
}

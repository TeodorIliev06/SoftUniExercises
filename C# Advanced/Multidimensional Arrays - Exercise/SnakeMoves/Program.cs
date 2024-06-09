namespace _05._Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var matrixSize = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];

            string word = Console.ReadLine();
            bool even = true;

            var chars = new Queue<char>();
            while (chars.Count < rows * cols)
            {
                foreach (char letter in word)
                {
                    chars.Enqueue(letter);
                }
            }

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                if (even is true)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        matrix[row, col] = chars.Dequeue();
                    }
                    PrintMatrix(cols, matrix, row);
                }
                else
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        matrix[row, col] = chars.Dequeue();
                    }
                    PrintMatrix(cols, matrix, row);
                }
                even = !even;
            }
        }

        private static void PrintMatrix(int cols, char[,] matrix, int row)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.Write(matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}

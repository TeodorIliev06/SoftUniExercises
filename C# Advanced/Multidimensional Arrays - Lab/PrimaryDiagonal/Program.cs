namespace _03._Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int diagonalSum = 0;

            int[,] matrix = new int[matrixSize, matrixSize];

            for (int row = 0; row < matrixSize; row++)
            {
                int[] rowArr = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = rowArr[col];
                }
            }

            for (int cell = 0; cell < matrixSize; cell++)
            {
                diagonalSum += matrix[cell, cell];
            }
            Console.WriteLine(diagonalSum);
        }
    }
}

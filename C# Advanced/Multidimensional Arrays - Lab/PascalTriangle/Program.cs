namespace _07._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            long[][] pascalArr = new long[rows][];

            for (int row = 0; row < rows; row++)
            {
                pascalArr[row] = new long[row + 1];

                for (int col = 0; col < row + 1; col++)
                {
                    long sum = 0;
                    if (row - 1 >= 0 && col < pascalArr[row - 1].Length)
                    {
                        sum += pascalArr[row - 1][col];
                    }
                    if (row - 1 >= 0 && col - 1 >= 0)
                    {
                        sum += pascalArr[row - 1][col - 1];
                    }

                    if (sum == 0)
                    {
                        sum = 1;
                    }

                    pascalArr[row][col] = sum;
                }
            }

            for (int row = 0; row < pascalArr.Length; row++)
            {
                for (int col = 0; col < pascalArr[row].Length; col++)
                {
                    Console.Write(pascalArr[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

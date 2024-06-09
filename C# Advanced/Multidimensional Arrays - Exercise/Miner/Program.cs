namespace _09._Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int minerRow = 0;
            int minerCol = 0;
            char[,] matrix = new char[matrixSize, matrixSize];

            string[] commands = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int row = 0; row < matrixSize; row++)
            {
                var rowArr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();
                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = rowArr[col];
                    if (matrix[row, col] == 's')
                    {
                        minerRow = row;
                        minerCol = col;
                    }
                }
            }

            var coalIndexes = new Queue<int[]>();
            FindCoals(matrixSize, matrix, coalIndexes);
            int coalsLeft = coalIndexes.Count;
            for (int c = 0; c < commands.Length; c++)
            {
                string currCommand = commands[c];

                if (coalsLeft == 0)
                {
                    Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                    return;
                }

                if (currCommand == "up")
                {
                    if (minerRow - 1 >= 0)
                    {
                        if (matrix[minerRow - 1, minerCol] == '*')
                        {
                            matrix[minerRow, minerCol] = '*';
                            matrix[minerRow - 1, minerCol] = 's';
                            minerRow--;
                        }

                        else if (matrix[minerRow - 1, minerCol] == 'c')
                        {
                            coalsLeft--;
                            matrix[minerRow, minerCol] = '*';
                            matrix[minerRow - 1, minerCol] = 's';
                            minerRow--;
                        }

                        else
                        {
                            minerRow--;
                            Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                            return;
                        }
                    }
                }

                else if (currCommand == "down")
                {
                    if (minerRow + 1 < matrixSize)
                    {
                        if (matrix[minerRow + 1, minerCol] == '*')
                        {
                            matrix[minerRow, minerCol] = '*';
                            matrix[minerRow + 1, minerCol] = 's';
                            minerRow++;
                        }

                        else if (matrix[minerRow + 1, minerCol] == 'c')
                        {
                            coalsLeft--;
                            matrix[minerRow, minerCol] = '*';
                            matrix[minerRow + 1, minerCol] = 's';
                            minerRow++;
                        }

                        else
                        {
                            minerRow++;
                            Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                            return;
                        }
                    }
                }

                else if (currCommand == "left")
                {
                    if (minerCol - 1 >= 0)
                    {
                        if (matrix[minerRow, minerCol - 1] == '*')
                        {
                            matrix[minerRow, minerCol] = '*';
                            matrix[minerRow, minerCol - 1] = 's';
                            minerCol -= 1;
                        }

                        else if (matrix[minerRow, minerCol - 1] == 'c')
                        {
                            coalsLeft--;
                            matrix[minerRow, minerCol] = '*';
                            matrix[minerRow, minerCol - 1] = 's';
                            minerCol--;
                        }

                        else
                        {
                            minerCol--;
                            Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                            return;
                        }
                    }
                }

                else if (currCommand == "right")
                {
                    if (minerCol + 1 < matrixSize)
                    {
                        if (matrix[minerRow, minerCol + 1] == '*')
                        {
                            matrix[minerRow, minerCol] = '*';
                            matrix[minerRow, minerCol + 1] = 's';
                            minerCol += 1;
                        }

                        else if (matrix[minerRow, minerCol + 1] == 'c')
                        {
                            coalsLeft--;
                            matrix[minerRow, minerCol] = '*';
                            matrix[minerRow, minerCol + 1] = 's';
                            minerCol++;
                        }

                        else
                        {
                            minerCol++;
                            Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                            return;
                        }
                    }
                }
            }

            if (coalsLeft == 0)
            {
                Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
            }
            else
            {
                Console.WriteLine($"{coalsLeft} coals left. ({minerRow}, {minerCol})");
            }
        }
        static void FindCoals(int matrixSize, char[,] matrix, Queue<int[]> coalIndexes)
        {
            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    if (matrix[row, col] == 'c')
                    {
                        coalIndexes.Enqueue(new int[] { row, col });
                    }
                }
            }
        }
    }
}

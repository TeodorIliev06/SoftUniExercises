namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    internal class Program
    {
        static void Main(string[] args)                      //Analyze the code
        {
            int[] matrixSize = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];

            char[,] matrix = new char[rows, cols];
            int playerRow = 0;
            int playerCol = 0;
            for (int row = 0; row < rows; row++)
            {
                char[] rowArr = Console.ReadLine().ToCharArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowArr[col];
                    if (matrix[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            char[] commands = Console.ReadLine().ToCharArray();
            Queue<int[]> bunniesIndexes = new Queue<int[]>();

            for (int c = 0; c < commands.Length; c++)
            {
                BunniesFinder(rows, cols, matrix, bunniesIndexes);
                bool won = false;
                char currCommand = commands[c];

                if (currCommand == 'U')
                {
                    if (playerRow - 1 >= 0)
                    {
                        if (matrix[playerRow - 1, playerCol] == '.')
                        {
                            matrix[playerRow, playerCol] = '.';
                            matrix[playerRow - 1, playerCol] = 'P';
                            playerRow -= 1;
                        }

                        else
                        {
                            if (matrix[playerRow, playerCol] != 'B')
                            {
                                matrix[playerRow, playerCol] = '.';
                            }
                            MultiplyBunny(rows, cols, matrix, bunniesIndexes);
                            PrintMatrix(rows, cols, matrix);
                            Console.WriteLine($"dead: {playerRow - 1} {playerCol}");
                            break;
                        }
                    }

                    else
                    {
                        if (matrix[playerRow, playerCol] != 'B')
                        {
                            matrix[playerRow, playerCol] = '.';
                        }
                        won = true;
                    }
                }

                else if (currCommand == 'D')
                {
                    if (playerRow + 1 < rows)
                    {
                        if (matrix[playerRow + 1, playerCol] == '.')
                        {
                            matrix[playerRow, playerCol] = '.';
                            matrix[playerRow + 1, playerCol] = 'P';
                            playerRow += 1;
                        }

                        else
                        {
                            if (matrix[playerRow, playerCol] != 'B')
                            {
                                matrix[playerRow, playerCol] = '.';
                            }
                            MultiplyBunny(rows, cols, matrix, bunniesIndexes);
                            PrintMatrix(rows, cols, matrix);
                            Console.WriteLine($"dead: {playerRow + 1} {playerCol}");
                            break;
                        }
                    }

                    else
                    {
                        if (matrix[playerRow, playerCol] != 'B')
                        {
                            matrix[playerRow, playerCol] = '.';
                        }
                        won = true;
                    }
                }

                else if (currCommand == 'L')
                {
                    if (playerCol - 1 >= 0)
                    {
                        if (matrix[playerRow, playerCol - 1] == '.')
                        {
                            matrix[playerRow, playerCol] = '.';
                            matrix[playerRow, playerCol - 1] = 'P';
                            playerCol -= 1;
                        }

                        else
                        {
                            if (matrix[playerRow, playerCol] != 'B')
                            {
                                matrix[playerRow, playerCol] = '.';
                            }

                            MultiplyBunny(rows, cols, matrix, bunniesIndexes);
                            PrintMatrix(rows, cols, matrix);
                            Console.WriteLine($"dead: {playerRow} {playerCol - 1}");
                            break;
                        }
                    }

                    else
                    {
                        if (matrix[playerRow, playerCol] != 'B')
                        {
                            matrix[playerRow, playerCol] = '.';
                        }
                        won = true;
                    }
                }

                else if (currCommand == 'R')
                {
                    if (playerCol + 1 < cols)
                    {
                        if (matrix[playerRow, playerCol + 1] == '.')
                        {
                            matrix[playerRow, playerCol] = '.';
                            matrix[playerRow, playerCol + 1] = 'P';
                            playerCol += 1;
                        }

                        else
                        {
                            if (matrix[playerRow, playerCol] != 'B')
                            {
                                matrix[playerRow, playerCol] = '.';
                            }
                            MultiplyBunny(rows, cols, matrix, bunniesIndexes);
                            PrintMatrix(rows, cols, matrix);
                            Console.WriteLine($"dead: {playerRow} {playerCol + 1}");
                            break;
                        }
                    }

                    else
                    {
                        if (matrix[playerRow, playerCol] != 'B')
                        {
                            matrix[playerRow, playerCol] = '.';
                        }
                        won = true;
                    }
                }

                MultiplyBunny(rows, cols, matrix, bunniesIndexes);

                if (won)
                {
                    PrintMatrix(rows, cols, matrix);

                    Console.WriteLine($"won: {playerRow} {playerCol}");
                    break;
                }

                bool alivePlayer = IsAlive(matrix);

                if (alivePlayer == false)
                {
                    PrintMatrix(rows, cols, matrix);
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    break;
                }
            }
        }

        static bool IsAlive(char[,] matrix)
        {
            foreach (char element in matrix)
            {
                if (element == 'P')
                {
                    return true;
                }
            }

            return false;
        }

        static void MultiplyBunny(int rows, int cols, char[,] playGraund, Queue<int[]> bunniesIndexes)
        {
            while (bunniesIndexes.Count != 0)
            {
                int[] currBunny = bunniesIndexes.Dequeue();
                int row = currBunny[0];
                int col = currBunny[1];

                if (row - 1 >= 0)
                {
                    playGraund[row - 1, col] = 'B';
                }

                if (row + 1 < rows)
                {
                    playGraund[row + 1, col] = 'B';
                }

                if (col - 1 >= 0)
                {
                    playGraund[row, col - 1] = 'B';
                }

                if (col + 1 < cols)
                {
                    playGraund[row, col + 1] = 'B';
                }
            }
        }

        static void PrintMatrix(int rows, int cols, char[,] playground)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(playground[row, col]);
                }
                Console.WriteLine();
            }
        }

        static void BunniesFinder(int rows, int cols, char[,] matrix, Queue<int[]> bunniesIndexes)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        bunniesIndexes.Enqueue(new int[] { row, col });
                    }
                }
            }

        }
    }
}

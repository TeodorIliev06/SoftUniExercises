namespace _07._Knight_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            string[,] boardMatrix = new string[matrixSize, matrixSize];

            for (int row = 0; row < matrixSize; row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < matrixSize; col++)
                {
                    boardMatrix[row, col] = currentRow[col].ToString();
                }
            }

            int attackableKnightsCounter = 0;
            int removedKnightsCounter = 0;

            for (int maxAttackPotential = 8; maxAttackPotential > 0; maxAttackPotential--)
            {
                for (int row = 0; row < matrixSize; row++)
                {
                    for (int col = 0; col < matrixSize; col++)
                    {
                        if (boardMatrix[row, col].ToLower() == "k")
                        {
                            if (row - 1 >= 0)
                            {
                                if (col - 2 >= 0)
                                {
                                    if (boardMatrix[row - 1, col - 2].ToLower() == "k")
                                    {
                                        attackableKnightsCounter++;
                                    }
                                }

                                if (col + 2 < matrixSize)
                                {
                                    if (boardMatrix[row - 1, col + 2].ToLower() == "k")
                                    {
                                        attackableKnightsCounter++;
                                    }
                                }
                            }

                            if (row + 1 < matrixSize)
                            {
                                if (col - 2 >= 0)
                                {
                                    if (boardMatrix[row + 1, col - 2].ToLower() == "k")
                                    {
                                        attackableKnightsCounter++;
                                    }
                                }

                                if (col + 2 < matrixSize)
                                {
                                    if (boardMatrix[row + 1, col + 2].ToLower() == "k")
                                    {
                                        attackableKnightsCounter++;
                                    }
                                }
                            }

                            if (row - 2 >= 0)
                            {
                                if (col - 1 >= 0)
                                {
                                    if (boardMatrix[row - 2, col - 1].ToLower() == "k")
                                    {
                                        attackableKnightsCounter++;
                                    }
                                }

                                if (col + 1 < matrixSize)
                                {
                                    if (boardMatrix[row - 2, col + 1].ToLower() == "k")
                                    {
                                        attackableKnightsCounter++;
                                    }
                                }
                            }

                            if (row + 2 < matrixSize)
                            {
                                if (col - 1 >= 0)
                                {
                                    if (boardMatrix[row + 2, col - 1].ToLower() == "k")
                                    {
                                        attackableKnightsCounter++;
                                    }
                                }

                                if (col + 1 < matrixSize)
                                {
                                    if (boardMatrix[row + 2, col + 1].ToLower() == "k")
                                    {
                                        attackableKnightsCounter++;
                                    }
                                }
                            }
                        }

                        if (attackableKnightsCounter == maxAttackPotential)
                        {
                            boardMatrix[row, col] = "0";
                            removedKnightsCounter++;
                        }

                        attackableKnightsCounter = 0;
                    }
                }
            }
            Console.WriteLine(removedKnightsCounter);
        }
    }
}

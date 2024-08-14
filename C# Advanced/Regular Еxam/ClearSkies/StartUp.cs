namespace ClearSkies
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int jetRow = 0, jetCol = 0, enemiesCount = 0;
            int armorValue = 300;

            char[,] matrix = new char[matrixSize, matrixSize];
            for (int row = 0; row < matrixSize; row++)
            {
                char[] inputMatrix = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = inputMatrix[col];
                    if (matrix[row, col] == 'J')
                    {
                        jetRow = row; jetCol = col;
                    }
                    if (matrix[row, col] == 'E')
                    {
                        enemiesCount++;
                    }
                }
            }

            string command;
            while (armorValue > 0 && enemiesCount > 0)
            {
                command = Console.ReadLine();
                int newRow = jetRow, newCol = jetCol;

                switch (command)
                {
                    case "up":
                        newRow--;
                        break;
                    case "down":
                        newRow++;
                        break;
                    case "left":
                        newCol--;
                        break;
                    case "right":
                        newCol++;
                        break;
                }

                if (matrix[newRow, newCol] == 'E')
                {
                    enemiesCount--;
                    if (enemiesCount == 0)
                    {
                        Console.WriteLine($"Mission accomplished, you neutralized the aerial threat!");
                    }
                    else
                    { 
                        armorValue -= 100;
                        if (armorValue <= 0)
                        {
                            Console.WriteLine($"Mission failed, your jetfighter was shot down! Last coordinates [{newRow}, {newCol}]!");
                        }
                    }                   
                }

                else if (matrix[newRow, newCol] == 'R') 
                {
                    armorValue = 300;
                }

                matrix[jetRow, jetCol] = '-';
                matrix[newRow, newCol] = 'J';
                jetRow = newRow;
                jetCol = newCol;
            }

            PrintMatrix(matrixSize, matrix);
        }

        public static void PrintMatrix(int matrixSize, char[,] matrix)
        {
            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++) 
                { 
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
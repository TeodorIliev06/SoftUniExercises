namespace MouseInTheKitchen;

public class StartUp
{
    static void Main(string[] args)
    {
        int[] matrixInput = Console.ReadLine()
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int rows = matrixInput[0];
        int cols = matrixInput[1];

        int mouseRow = -1;
        int mouseCol = -1;
        int cheeseLeft = 0;
        char[,] matrix = new char[rows, cols];

        //Read matrix
        for (int row = 0; row < rows; row++)
        {
            char[] rowArr = Console.ReadLine().ToCharArray();
            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = rowArr[col];
                if (matrix[row, col] == 'M')
                {
                    mouseRow = row;
                    mouseCol = col;
                }

                if (matrix[row, col] == 'C')
                {
                    cheeseLeft++;
                }
            }
        }

        string input;
        while ((input = Console.ReadLine().ToLower()) != "danger")
        {
            if ((input == "left" && mouseCol == 0) ||
                    (input == "right" && mouseCol == cols - 1) ||
                    (input == "up" && mouseRow == 0) ||
                    (input == "down" && mouseRow == rows - 1))
            {
                Console.WriteLine("No more cheese for tonight!");
                PrintMatrix(rows, cols, matrix);
                return;
            }

            if (cheeseLeft == 0)
            {
                Console.WriteLine($"Happy mouse! All the cheese is eaten, good night!");
                PrintMatrix(rows, cols, matrix);
                return;
            }

            if (input == "up")
            {
                if (matrix[mouseRow - 1, mouseCol] == '*')
                {
                    matrix[mouseRow, mouseCol] = '*';
                    matrix[mouseRow - 1, mouseCol] = 'M';
                    mouseRow--;
                }

                else if (matrix[mouseRow - 1, mouseCol] == 'C')
                {
                    cheeseLeft--;
                    matrix[mouseRow, mouseCol] = '*';
                    matrix[mouseRow - 1, mouseCol] = 'M';
                    mouseRow--;
                }

                else if (matrix[mouseRow - 1, mouseCol] == 'T')
                {
                    matrix[mouseRow, mouseCol] = '*';
                    matrix[mouseRow - 1, mouseCol] = 'M';
                    mouseRow--;
                    Console.WriteLine($"Mouse is trapped!");
                    PrintMatrix(rows, cols, matrix);
                    return;
                }

                else if (matrix[mouseRow - 1, mouseCol] == '@')
                {
                    continue;
                }
            }

            if (input == "down")
            {
                if (matrix[mouseRow + 1, mouseCol] == '*')
                {
                    matrix[mouseRow, mouseCol] = '*';
                    matrix[mouseRow + 1, mouseCol] = 'M';
                    mouseRow++;
                }

                else if (matrix[mouseRow + 1, mouseCol] == 'C')
                {
                    cheeseLeft--;
                    matrix[mouseRow, mouseCol] = '*';
                    matrix[mouseRow + 1, mouseCol] = 'M';
                    mouseRow++;
                }

                else if (matrix[mouseRow + 1, mouseCol] == 'T')
                {
                    matrix[mouseRow, mouseCol] = '*';
                    matrix[mouseRow + 1, mouseCol] = 'M';
                    mouseRow++;
                    Console.WriteLine($"Mouse is trapped!");
                    PrintMatrix(rows, cols, matrix);
                    return;
                }

                else if (matrix[mouseRow + 1, mouseCol] == '@')
                {
                    continue;
                }
            }

            if (input == "left")
            {

                if (matrix[mouseRow, mouseCol - 1] == '*')
                {
                    matrix[mouseRow, mouseCol] = '*';
                    matrix[mouseRow, mouseCol - 1] = 'M';
                    mouseCol--;
                }

                else if (matrix[mouseRow, mouseCol - 1] == 'C')
                {
                    cheeseLeft--;
                    matrix[mouseRow, mouseCol] = '*';
                    matrix[mouseRow, mouseCol - 1] = 'M';
                    mouseCol--;
                }

                else if (matrix[mouseRow, mouseCol - 1] == 'T')
                {
                    matrix[mouseRow, mouseCol] = '*';
                    matrix[mouseRow, mouseCol - 1] = 'M';
                    mouseCol--;
                    Console.WriteLine($"Mouse is trapped!");
                    PrintMatrix(rows, cols, matrix);
                    return;
                }

                else if (matrix[mouseRow, mouseCol - 1] == '@')
                {
                    continue;
                }
            }

            if (input == "right")
            {
                if (matrix[mouseRow, mouseCol + 1] == '*')
                {
                    matrix[mouseRow, mouseCol] = '*';
                    matrix[mouseRow, mouseCol + 1] = 'M';
                    mouseCol++;
                }

                else if (matrix[mouseRow, mouseCol + 1] == 'C')
                {
                    cheeseLeft--;
                    matrix[mouseRow, mouseCol] = '*';
                    matrix[mouseRow, mouseCol + 1] = 'M';
                    mouseCol++;
                }

                else if (matrix[mouseRow, mouseCol + 1] == 'T')
                {
                    matrix[mouseRow, mouseCol] = '*';
                    matrix[mouseRow, mouseCol + 1] = 'M';
                    mouseCol++;
                    Console.WriteLine($"Mouse is trapped!");
                    PrintMatrix(rows, cols, matrix);
                    return;
                }

                else if (matrix[mouseRow, mouseCol + 1] == '@')
                {
                    continue;
                }
            }
        }

        if (cheeseLeft > 0)
        {
            Console.WriteLine("Mouse will come back later!");
        }
        PrintMatrix(rows, cols, matrix);
    }

    private static void PrintMatrix(int rows, int cols, char[,] matrix)
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.Write(matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}
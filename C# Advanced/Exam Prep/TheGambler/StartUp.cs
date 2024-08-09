namespace TheGambler;

public class StartUp
{
    static void Main(string[] args)
    {
        int matrixSize = int.Parse(Console.ReadLine());
        int currentProfit = 100;
        bool won = false;


        char[,] matrix = new char[matrixSize, matrixSize];
        int initialRowIndex = 0, initialColIndex = 0;

        //Initialize matrix
        for (int row = 0; row < matrixSize; row++)
        {
            char[] inputMatrix = Console.ReadLine().ToCharArray();
            for (int col = 0; col < matrixSize; col++)
            {
                matrix[row, col] = inputMatrix[col];
                if (matrix[row, col] == 'G')
                {
                    initialRowIndex = row;
                    initialColIndex = col;
                }
            }
        }

        matrix[initialRowIndex, initialColIndex] = '-';
        string command;
        while ((command = Console.ReadLine()) != "end")
        {
            //Out of bountries check
            if (command == "up" && initialRowIndex - 1 < 0
                || command == "down" && initialRowIndex + 1 > matrixSize
                || command == "left" && initialColIndex - 1 < 0
                || command == "right" && initialColIndex + 1 > matrixSize)

            {
                Console.WriteLine("Game over! You lost everything!");
                return;
            }

            if (command == "left") initialColIndex--;
            if (command == "right") initialColIndex++;
            if (command == "up") initialRowIndex--;
            if (command == "down") initialRowIndex++;

            if (matrix[initialRowIndex, initialColIndex] == 'W')
            {
                currentProfit += 100;
            }
            if (matrix[initialRowIndex, initialColIndex] == 'P')
            {
                currentProfit -= 200;
            }
            if (matrix[initialRowIndex, initialColIndex] == 'J')
            {
                currentProfit += 100000;
                Console.WriteLine("You win the Jackpot!");
                break;
            }
            if (currentProfit <= 0)
            {
                Console.WriteLine("Game over! You lost everything!");
                return;
            }
            matrix[initialRowIndex, initialColIndex] = '-';
        }

        matrix[initialRowIndex, initialColIndex] = 'G';      
        Console.WriteLine($"End of the game. Total amount: {currentProfit}$");
        PrintMatrix(matrix, matrixSize);
    }
    static void PrintMatrix(char[,] matrix, int matrixSize)
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
namespace _06._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedArr = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                jaggedArr[row] = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
            }

            string command;
            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                string[] commandInfo = command.Split();
                string operation = commandInfo[0];
                int row = int.Parse(commandInfo[1]);
                int col = int.Parse(commandInfo[2]);
                int value = int.Parse(commandInfo[3]);

                if (row < 0 || row >= jaggedArr.Length
                    || col < 0 || col >= jaggedArr[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                }

                else if (operation == "add")
                {
                    jaggedArr[row][col] += value;
                }
                else
                {
                    jaggedArr[row][col] -= value;
                }
            }

            for (int row = 0; row < jaggedArr.Length; row++)
            {

                for (int col = 0; col < jaggedArr[row].Length; col++)
                {
                    Console.Write($"{jaggedArr[row][col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}

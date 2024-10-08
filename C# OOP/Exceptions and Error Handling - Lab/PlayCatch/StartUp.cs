namespace PlayCatch;

public class StartUp
{
    static void Main(string[] args)
    {
        int[] inputArr = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int exceptionCount = 0;
        string[] commandTokens;
        while (exceptionCount < 3)
        {
            commandTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string command = commandTokens[0];

            try
            {
                switch (command)
                {
                    case "Replace":
                        int replaceIndex, element;
                        if (!int.TryParse(commandTokens[1], out replaceIndex) || !int.TryParse(commandTokens[2], out element))
                        {
                            throw new FormatException("The variable is not in the correct format!");
                        }
                        else if (replaceIndex < 0 || replaceIndex >= inputArr.Length)
                        {
                            throw new ArgumentException("The index does not exist!");
                        }
                        inputArr[replaceIndex] = element;
                        break;

                    case "Print":
                        int startIndex, endIndex;
                        if (!int.TryParse(commandTokens[1], out startIndex) || !int.TryParse(commandTokens[2], out endIndex))
                        {
                            throw new FormatException("The variable is not in the correct format!");
                        }
                        else if (startIndex < 0 || endIndex >= inputArr.Length || startIndex > endIndex)
                        {
                            throw new ArgumentException("The index does not exist!");
                        }
                        Console.WriteLine(String.Join(", ", inputArr[startIndex..(endIndex + 1)]));
                        break;

                    case "Show":
                        int showIndex;
                        if (!int.TryParse(commandTokens[1], out showIndex))
                        {
                            throw new FormatException("The variable is not in the correct format!");
                        }
                        else if (showIndex < 0 || showIndex >= inputArr.Length)
                        {
                            throw new ArgumentException("The index does not exist!");
                        }
                        Console.WriteLine(inputArr[showIndex]);
                        break;
                } 
            }
            catch (FormatException ex) 
            {
                Console.WriteLine(ex.Message);
                exceptionCount++;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                exceptionCount++;
            }
        }

        Console.WriteLine(String.Join(", ", inputArr));
    }
}

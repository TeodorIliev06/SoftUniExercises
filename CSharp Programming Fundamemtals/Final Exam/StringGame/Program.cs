namespace StringGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Done")
            {
                string[] commandTokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string commandName = commandTokens[0];
                string substring;

                switch (commandName)
                {
                    case "Change":
                        char toReplace = char.Parse(commandTokens[1]);
                        char replacement = char.Parse(commandTokens[2]);

                        foreach (var ch in input.Where(ch => ch == toReplace))
                        {
                            input = input.Replace(ch, replacement);
                        }

                        Console.WriteLine(input);
                        break;

                    case "Includes":
                        substring = commandTokens[1];

                        if (input.Contains(substring))
                        {
                            Console.WriteLine("True");
                        }
                        else
                        {
                            Console.WriteLine("False");
                        }
                        break;

                    case "End":
                        substring = commandTokens[1];

                        if(input.EndsWith(substring))
                        {
                            Console.WriteLine("True");
                        }
                        else
                        {
                            Console.WriteLine("False");
                        }
                        break;

                    case "Uppercase":
                        input = input.ToUpper();
                        Console.WriteLine(input);
                        break;

                    case "FindIndex":
                        char toFindIndex = char.Parse(commandTokens[1]);                       
                        Console.WriteLine(input.IndexOf(toFindIndex));
                        break;

                    case "Cut":
                        int startIndex = int.Parse(commandTokens[1]);
                        int count = int.Parse(commandTokens[2]);
                        
                        input = input.Remove(0, startIndex);
                        input = input.Remove(count, input.Length-count);
                        Console.WriteLine(input);
                        break;
                }
            }
        }
    }
}

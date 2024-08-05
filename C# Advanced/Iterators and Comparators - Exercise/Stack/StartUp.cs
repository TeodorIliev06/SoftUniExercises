namespace Stack;

public class StartUp
{
    static void Main(string[] args)
    {
        Stack<int> customStack = new Stack<int>();

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] commandTokens = input.Split(new string[] { ", ", " " }, StringSplitOptions.RemoveEmptyEntries);
            string command = commandTokens[0];

            if (command == "Push")
            {
                for (int i = 1; i < commandTokens.Length; i++)
                {
                    int element = int.Parse(commandTokens[i]);
                    customStack.Push(element);
                }
            }
            else if (command == "Pop")
            {
                try
                {
                    customStack.Pop();
                }
                catch (InvalidOperationException IOE)
                {
                    Console.WriteLine("No elements");
                }
            }
        }

        foreach (int element in customStack)
        {
            Console.WriteLine(element);
        }
        foreach (int element in customStack)
        {
            Console.WriteLine(element);
        }
    }
}
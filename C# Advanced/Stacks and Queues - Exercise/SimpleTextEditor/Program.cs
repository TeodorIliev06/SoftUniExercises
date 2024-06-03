using System.Text;

namespace _09._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var text = new StringBuilder();
            var undoStack = new Stack<string>();

            int operationsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < operationsCount; i++)
            {
                string[] commandInfo = Console.ReadLine().Split();
                int command = int.Parse(commandInfo[0]);

                switch (command)
                {
                    case 1:
                        string textToAppend = commandInfo[1];
                        undoStack.Push(text.ToString());
                        text.Append(textToAppend);
                        break;

                    case 2:
                        int elementsToErase = int.Parse(commandInfo[1]);
                        undoStack.Push(text.ToString());
                        text.Remove(text.Length - elementsToErase, elementsToErase);
                        break;

                    case 3:
                        int index = int.Parse(commandInfo[1]);
                        Console.WriteLine(text[index - 1]);
                        break;

                    case 4:
                        if (undoStack.Count > 0)
                        {
                            text.Clear();
                            text.Append(undoStack.Pop());
                        }
                        break;
                }
            }
        }
    }
}

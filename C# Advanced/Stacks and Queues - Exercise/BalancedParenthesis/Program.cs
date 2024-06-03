namespace _08._Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var parenthesisStack = new Stack<char>();

            foreach (var symbol in input)
            {
                if (parenthesisStack.Any())
                {
                    char check = parenthesisStack.Peek();
                    if ((check == '{' && symbol == '}')
                        || (check == '[' && symbol == ']')
                        || (check == '(' && symbol == ')'))
                    {
                        parenthesisStack.Pop();
                        continue;
                    }
                }
                parenthesisStack.Push(symbol);
            }
            Console.WriteLine(!parenthesisStack.Any() ? "YES" : "NO");
        }
    }
}

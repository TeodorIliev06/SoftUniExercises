namespace _04._Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] expression = Console.ReadLine()
                .ToArray();
            Stack<int> openingBracketsIndexes = new Stack<int>();
            string output = new string(expression); 

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    openingBracketsIndexes.Push(i);
                }
                else if (expression[i] == ')')
                {
                    int start = openingBracketsIndexes.Pop();
                    int end = i;
                    Console.WriteLine(output.Substring(start, end - start + 1));
                }
            }
        }
    }
}

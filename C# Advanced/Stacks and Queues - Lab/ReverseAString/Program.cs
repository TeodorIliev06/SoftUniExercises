namespace _01._Reverse_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<char> inputStack = new Stack<char>(Console.ReadLine().ToCharArray());

            while(inputStack.Count > 0)
            {
                Console.Write(inputStack.Pop());
            }
        }
    }
}

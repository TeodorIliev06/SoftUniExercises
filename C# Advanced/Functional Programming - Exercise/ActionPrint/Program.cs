namespace _01._Action_Print
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine().Split();
            Action<string> newLinePrinter = text => Console.WriteLine(text);

            foreach (var item in text)
            {
                newLinePrinter(item);
            }
        }
    }
}

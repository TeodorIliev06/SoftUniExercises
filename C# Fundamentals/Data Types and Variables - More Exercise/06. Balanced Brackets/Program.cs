namespace _06._Balanced_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int openingBracketsCount = 0, closingBracketsCount = 0;
            for (int i = 1; i <= n; i++)
            {
                string input = Console.ReadLine();
                if (input == "(")
                {
                    openingBracketsCount++;
                }
                else if (input == ")")
                {
                    closingBracketsCount++;
                    if (openingBracketsCount - closingBracketsCount != 0)
                    {
                        Console.WriteLine("UNBALANCED");
                        return;
                    }
                }                
            }
            if (openingBracketsCount == closingBracketsCount)
            {
                Console.WriteLine("BALANCED"); 
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
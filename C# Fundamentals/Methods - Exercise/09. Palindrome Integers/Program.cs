namespace _09._Palindrome_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "END")
            {
                GetPalindrome(int.Parse(input));
                input = Console.ReadLine();
            }
        }
        static void GetPalindrome(int num)
        {
            int digit = 0, reversed = 0;
            int curr = num;
            string isPalindrome = "false";
            while (num > 0)
            {
                digit = num % 10;
                reversed = reversed * 10 + digit;
                num = num / 10;
            }
            if (curr == reversed)
            {
                isPalindrome = "true";
                Console.WriteLine(isPalindrome);
            }
            else
                Console.WriteLine(isPalindrome);
        }
    }
}
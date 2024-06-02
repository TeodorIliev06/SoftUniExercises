using System;

namespace _04._Password_Validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pass = Console.ReadLine();
            PasswordValid(pass);
        }

        static void PasswordValid(string password)
        {
            bool length = false;
            bool lettersDigits = true;
            bool digits2 = false;
            int counterDigits = 0;

            if (password.Length >= 6 && password.Length <= 10)
            {
                length = true;
            }
            else
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            for (int i = 0; i < password.Length; i++)
            {
                char current = password[i];

                if (char.IsDigit(current))
                {
                    counterDigits++;
                }

                if (!char.IsLetterOrDigit(current))
                {
                    lettersDigits = false;
                }
            }

            if (!lettersDigits)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (counterDigits < 2)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
            else if (counterDigits >= 2)
            {
                digits2 = true;
            }

            if (length && lettersDigits && digits2)
            {
                Console.WriteLine("Password is valid");
            }
        }
    }
}

using System;

namespace Extract_Person_Information
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();

                int nameStart = input.IndexOf('@');
                int nameEnd = input.IndexOf('|');

                string name = input.Substring(nameStart + 1, nameEnd - nameStart - 1);

                int ageStart = input.IndexOf('#');
                int ageEnd = input.IndexOf('*');

                string age = input.Substring(ageStart + 1, ageEnd - ageStart - 1);

                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}

using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fruits = { "banana", "apple", "kiwi", "cherry", "lemon", "grapes" };
            string[] vegetables = { "tomato", "cucumber", "pepper", "carrot" };
            string input = Console.ReadLine();
            string category = "unknown";
            foreach (string fruit in fruits)
            {
                if (input == fruit) { category = "fruit"; break; }
            }
            foreach (string vegetable in vegetables)
            {
                if (input == vegetable) { category = "vegetable"; break; }
            }
            Console.WriteLine(category);
        }
    }
}
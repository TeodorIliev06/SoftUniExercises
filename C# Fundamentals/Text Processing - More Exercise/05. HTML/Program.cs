using System;
using System.Linq;
using System.Collections.Generic;

namespace HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            string articleName = Console.ReadLine();
            string articleContent = Console.ReadLine();
            string comment;
            List<string> arguments = new List<string>();

            while ((comment = Console.ReadLine()) != "end of comments")
            {
                arguments.Add(comment);
            }
            Console.WriteLine("<h1>");
            Console.WriteLine("    " + articleName);
            Console.WriteLine("</h1>");

            Console.WriteLine("<article>");
            Console.WriteLine("    " + articleContent);
            Console.WriteLine("</article>");

            foreach (string item in arguments)
            {
                Console.WriteLine("<div>");
                Console.WriteLine("    " + item);
                Console.WriteLine("</div>");
            }
        }
    }
}

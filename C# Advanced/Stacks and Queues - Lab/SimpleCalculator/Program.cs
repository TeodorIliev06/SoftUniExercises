using System.Linq;
using System.Threading.Channels;

namespace _03._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {           
            string[] inputArr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Stack<string> expression = new Stack<string>(inputArr.Reverse());           

            while (expression.Count > 1)
            {
                int leftNumber = int.Parse(expression.Pop());
                char @operator = char.Parse(expression.Pop());
                int rightNumber = int.Parse(expression.Pop());

                switch (@operator)
                {
                    case '+':
                        expression.Push((leftNumber + rightNumber).ToString());
                        break;
                    case '-':
                        expression.Push((leftNumber - rightNumber).ToString());
                        break;
                }
            }

            Console.WriteLine(expression.Peek());
        }
    }
}

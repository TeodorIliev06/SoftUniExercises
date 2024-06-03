namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int rackCapacity = int.Parse(Console.ReadLine());
            int currRackCapacity = rackCapacity;
            int racksCount = 1;

            while (stack.Count > 0)
            {
                if (stack.Peek() <= currRackCapacity)
                {
                    currRackCapacity -= stack.Pop();
                }
                else
                {
                    racksCount++;
                    currRackCapacity = rackCapacity;
                }
            }

            Console.WriteLine(racksCount);
        }
    }
}

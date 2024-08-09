namespace PiePursuit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> contestants = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> pies = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            while (contestants.Count > 0 && pies.Count > 0)
            {
                int currPie = pies.Pop();
                int currContestant = contestants.Dequeue();

                if (currContestant >= currPie)
                {
                    currContestant -= currPie;

                    if(currContestant > 0)
                    {
                        contestants.Enqueue(currContestant);
                    }
                }
                else
                {
                    currPie -= currContestant;
                    if (pies.Count > 1 && currPie == 1)
                    {
                        pies.Push(pies.Pop() + 1);
                    }
                    else
                    {
                        pies.Push(currPie);
                    }
                }
            }

            if (pies.Count > 0)
            {
                Console.WriteLine("Our contestants need to rest!");
                Console.WriteLine($"Pies left: {String.Join(", ", pies)}");
            }
            else if (contestants.Count > 0)
            {
                Console.WriteLine("We will have to wait for more pies to be baked!");
                Console.WriteLine($"Contestants left: {String.Join(", ", contestants)}");
            }
            else
            {
                Console.WriteLine("We have a champion!");
            }
        }
    }
}

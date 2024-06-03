namespace _06._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var songsQueue = new Queue<string>(Console.ReadLine().Split(", ").ToArray());

            while (songsQueue.Count > 0)
            {
                string[] commandInfo = Console.ReadLine().Split().ToArray();
                string command = commandInfo[0];

                if (command == "Play")
                {
                    songsQueue.Dequeue();
                }
                else if (command == "Add")
                {
                    string songName = string.Join(' ', commandInfo.Skip(1));

                    if (songsQueue.Contains(songName))
                    {
                        Console.WriteLine($"{songName} is already contained!");
                    }
                    else
                    {
                        songsQueue.Enqueue(songName);
                    }
                }
                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", songsQueue));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}

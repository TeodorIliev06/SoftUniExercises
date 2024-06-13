using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    public class Vlogger
    {
        public string Name { get; set; }
        public HashSet<string> Followers { get; set; }
        public HashSet<string> Following { get; set; }

        public Vlogger(string name)
        {
            Name = name;
            Followers = new HashSet<string>();
            Following = new HashSet<string>();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var vloggers = new List<Vlogger>();

            string command;
            while ((command = Console.ReadLine()) != "Statistics")
            {
                string[] input = command.Split();
                string vloggerName = input[0];
                string action = input[1];
                string targetVloggerName = input[2];

                if (action == "joined" && vloggers.All(v => v.Name != vloggerName))
                {
                    vloggers.Add(new Vlogger(vloggerName));
                }
                else if (action == "followed")
                {
                    Vlogger follower = vloggers.FirstOrDefault(v => v.Name == vloggerName);
                    Vlogger followed = vloggers.FirstOrDefault(v => v.Name == targetVloggerName);

                    if (follower != null && followed != null && follower != followed)
                    {
                        follower.Following.Add(targetVloggerName);
                        followed.Followers.Add(vloggerName);
                    }
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            var sortedVloggers = vloggers
                .OrderByDescending(v => v.Followers.Count)
                .ThenBy(v => v.Following.Count);

            int number = 0;
            foreach (var vlogger in sortedVloggers)
            {
                Console.WriteLine($"{++number}. {vlogger.Name} : {vlogger.Followers.Count} followers, {vlogger.Following.Count} following");

                if (number == 1)
                {
                    foreach (string follower in vlogger.Followers.OrderBy(f => f))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
            }
        }
    }
}

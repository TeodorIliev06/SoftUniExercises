using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace _02._Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            var contests = new Dictionary<string, Dictionary<string, int>>();
            var individualStatistics = new SortedDictionary<string, Dictionary<string, int>>();

            string input;

            while ((input = Console.ReadLine()) != "no more time")
            {
                string[] inputInfo = input.Split(" -> ");
                string name = inputInfo[0];
                string contest = inputInfo[1];
                int point = int.Parse(inputInfo[2]);

                if (contests.ContainsKey(contest))
                {
                    if (contests[contest].ContainsKey(name))
                    {
                        if (contests[contest][name] < point)
                        {
                            contests[contest][name] = point;
                        }
                    }
                    else
                    {
                        contests[contest].Add(name, point);
                    }
                }
                else
                {
                    contests.Add(contest, new Dictionary<string, int>());
                    contests[contest].Add(name, point);
                }

                if (individualStatistics.ContainsKey(name))
                {
                    if (individualStatistics[name].ContainsKey(contest))
                    {
                        if (individualStatistics[name][contest] < point)
                        {
                            individualStatistics[name][contest] = point;
                        }
                    }
                    else
                    {
                        individualStatistics[name].Add(contest, point);
                    }
                }
                else
                {
                    individualStatistics.Add(name, new Dictionary<string, int>());
                    individualStatistics[name].Add(contest, point);
                }

            }

            int position = 1;
            foreach (var item in contests)
            {
                position = 1;
                Console.WriteLine($"{item.Key}: {item.Value.Count} participants");

                foreach (var items in item.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{position}. {items.Key} <::> {items.Value}");
                    position++;
                }
            }

            var filterIndivDic = new Dictionary<string, int>();
            int sum = 0;
            foreach (var item in individualStatistics)
            {
                foreach (var items in item.Value)
                {
                    sum += items.Value;
                }
                filterIndivDic.Add(item.Key, sum);
                sum = 0;
            }

            filterIndivDic = filterIndivDic.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(a => a.Key, b => b.Value);

            position = 1;
            Console.WriteLine("Individual standings:");
            foreach (var item in filterIndivDic)
            {
                Console.WriteLine($"{position}. {item.Key} -> {item.Value}");
                position++;
            }
        }
    }
}
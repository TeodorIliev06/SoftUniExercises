using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MOBA_Challenger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> players = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Season end")
                {
                    break;
                }
                List<string> SplitedNewPlayers = new List<string>();
                List<string> PlayerVSplayer = new List<string>();
                string player = null;
                string position = null;
                int skill = 0;
                if (input.Contains("->"))
                {
                    SplitedNewPlayers = Regex.Split(input, " -> ").ToList();
                    player = SplitedNewPlayers[0];
                    position = SplitedNewPlayers[1];
                    skill = int.Parse(SplitedNewPlayers[2]);

                    if (!players.ContainsKey(player))
                    {
                        players.Add(player, new Dictionary<string, int>());
                    }
                    if (!players[player].ContainsKey(position))
                    {
                        players[player].Add(position, 0);
                    }
                    if (players[player][position] <= skill)
                    {
                        players[player][position] = skill;

                    }
                }
                else
                {
                    PlayerVSplayer = Regex.Split(input, " vs ").ToList();

                    string player1Key = PlayerVSplayer[0];
                    string player2Key = PlayerVSplayer[1];
                    if (!players.ContainsKey(player1Key) || !players.ContainsKey(player2Key))
                    {
                        continue;
                    }
                    bool commonPosition = false;
                    foreach (var item in players[player1Key])
                    {
                        if (players[player2Key].ContainsKey(item.Key))
                        {
                            commonPosition = true;
                        }
                    }
                    int totalSkills1 = 0;
                    int totalSkills2 = 0;
                    if (commonPosition)
                    {
                        totalSkills1 = players[player1Key].Values.Sum();
                        totalSkills2 = players[player2Key].Values.Sum();
                        if (totalSkills1 > totalSkills2)
                        {
                            players.Remove(player2Key);
                        }
                        else if (totalSkills2 > totalSkills1)
                        {
                            players.Remove(player1Key);
                        }
                    }
                }
            }
            foreach (var item in players.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(c => c.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value.Values.Sum()} skill");

                foreach (var men in item.Value.OrderByDescending(x => x.Value).ThenBy(c => c.Key))
                {
                    Console.WriteLine($"- {men.Key} <::> {men.Value}");
                }
            }
        }
    }
}
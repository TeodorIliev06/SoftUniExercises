using FootballTeamGenerator.Models;

namespace FootballTeamGenerator;

public class StartUp
{
    static void Main(string[] args)
    {
        List<Team> teams = new();

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] tokens = input.Split(";", StringSplitOptions.RemoveEmptyEntries);
            string command = tokens[0];
            string teamName = tokens[1];
            string playerName;
            try
            {
                switch (command)
                {
                    case "Team":
                        AddTeam(teamName, teams);
                        break;
                    case "Add":
                        playerName = tokens[2];
                        int endurance = int.Parse(tokens[3]);
                        int sprint = int.Parse(tokens[4]);
                        int dribble = int.Parse(tokens[5]);
                        int passing = int.Parse(tokens[6]);
                        int shooting = int.Parse(tokens[7]);
                        AddPlayer(teamName,playerName,endurance,sprint,
                            dribble,passing,shooting,teams);
                        break;
                    case "Remove":
                        playerName = tokens[2];
                        RemovePlayer(teamName, playerName, teams);
                        break;
                    case "Rating":
                        PrintRating(teamName, teams);
                        break;
                }

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void AddTeam(string name, List<Team> teams)
        {
            teams.Add(new Team(name));
        }

        static void AddPlayer(
            string teamName,
            string name,
            int endurance,
            int sprint,
            int dribble,
            int passing,
            int shooting,
            List<Team> teams)
        {
            Team team = teams.FirstOrDefault(t => t.Name == teamName);

            if (team is null)
            {
                Console.WriteLine($"Team {teamName} does not exist.");

                return;
            }

            Player player = new(name, endurance, sprint, dribble, passing, shooting);
            team.AddPlayer(player);
        }

        static void RemovePlayer(string teamName, string playerName, List<Team> teams)
        {
            Team team = teams.FirstOrDefault(t => t.Name == teamName);

            if (team is null)
            {
                Console.WriteLine($"Team {teamName} does not exist.");

                return;
            }

            team.RemovePlayer(playerName);
        }

        static void PrintRating(string teamName, List<Team> teams)
        {
            Team team = teams.FirstOrDefault(t => t.Name == teamName);

            if (team is null)
            {
                Console.WriteLine($"Team {teamName} does not exist.");
                return;
            }

            Console.WriteLine($"{teamName} - {(int)team.Rating}");
        }
    }
}
public class Program
{
    public static void Main()
    {
        int teamsCount = int.Parse(Console.ReadLine());
        List<Team> allTeams = new();

        for (int i = 0; i < teamsCount; i++)
        {
            string[] teamTokens = Console.ReadLine()
                .Split('-', StringSplitOptions.RemoveEmptyEntries);
            string currentCreator = teamTokens[0];
            string currentTeamNeme = teamTokens[1];

            bool teamNameExists = allTeams
                .Select(t => t.TeamName).Contains(currentTeamNeme);

            bool creatorExists = allTeams
                .Any(c => c.CreatorName == currentCreator);

            //Create a new team
            if (!teamNameExists && !creatorExists)
            {
                allTeams.Add(new Team(currentTeamNeme, currentCreator));
                Console.WriteLine($"Team {currentTeamNeme} has been created by {currentCreator}!");
            }

            //Check for existing team
            else if (teamNameExists)
            {
                Console.WriteLine($"Team {currentTeamNeme} was already created!");
            }

            //Check for existing creator
            else if (creatorExists)
            {
                Console.WriteLine($"{currentCreator} cannot create another team!");
            }
        }

        string joiningMember;
        while ((joiningMember = Console.ReadLine()) != "end of assignment")
        {
            string[] inputTokens = joiningMember
                .Split("->", StringSplitOptions.RemoveEmptyEntries);

            string member = inputTokens[0];
            string team = inputTokens[1];

            bool teamExists = allTeams.Any(x => x.TeamName == team);
            bool creatorCheating = allTeams.Any(x => x.CreatorName == member);
            bool alreadyJoined = allTeams.Any(x => x.Members.Contains(member));

            if (teamExists && !creatorCheating && !alreadyJoined)
            {
                int teamIndex = allTeams
                    .FindIndex(x => x.TeamName == team);

                allTeams[teamIndex].Members.Add(member);
            }
            else if (!teamExists)
            {
                Console.WriteLine($"Team {team} does not exist!");
            }
            else if (alreadyJoined || creatorCheating)
            {
                Console.WriteLine($"Member {member} cannot join team {team}!");
            }
        }

        List<Team> teamsWithMembers = allTeams
            .Where(x => x.Members.Count > 0)
            .OrderByDescending(x => x.Members.Count)
            .ThenBy(x => x.TeamName)
            .ToList();

        List<Team> invalidTeams = allTeams
            .Where(x => x.Members.Count == 0)
            .OrderBy(x => x.TeamName)
            .ToList();

        foreach (var team in teamsWithMembers)
        {
            Console.WriteLine(team.TeamName);
            Console.WriteLine($"- {team.CreatorName}");
            team.Members.Sort();
            Console.WriteLine(string.Join("\n", team.Members.Select(x => $"-- {x}")));
        }

        Console.WriteLine("Teams to disband:");
        invalidTeams.ForEach(t => Console.WriteLine(t.TeamName));
    }
}
public class Team
{
    public Team(string name, string creatorName)
    {
        TeamName = name;
        CreatorName = creatorName;
        Members = new();
    }

    public string TeamName { get; set; }
    public string CreatorName { get; set; }
    public List<string> Members { get; set; }
}
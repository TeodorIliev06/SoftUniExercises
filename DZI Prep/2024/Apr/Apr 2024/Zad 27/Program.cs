namespace Zad_27
{
    using System.Runtime.CompilerServices;

    internal class Program
    {
        static void Main(string[] args)
        {
            using var reader = new StreamReader("info.txt");

            string line;
            Team team = null!;
            while ((line = reader.ReadLine()) != null)
            {
                var tokens = line.Split();
                var command = tokens[0];

                string playerName;
                switch (command)
                {
                    case "CT":
                        var teamName = tokens[1];
                        var openPositions = int.Parse(tokens[2]);
                        var group = char.Parse(tokens[3]);

                        team = new Team(teamName, openPositions, group);
                        Console.WriteLine($"Created {teamName} successfully.");

                        break;
                    case "CP":
                        Console.WriteLine(team.Count());
                        
                        break;
                    case "AP":
                        playerName = tokens[1];
                        var position = tokens[2];
                        var rating = double.Parse(tokens[3]);
                        var games = int.Parse(tokens[4]);

                        var result = team.AddPlayer(new Player(playerName, position, rating, games));
                        Console.WriteLine(result);

                        break;
                    case "RP":
                        playerName = tokens[1];

                        var playerToRemove = team.Players
                            .FirstOrDefault(p => p.Name == playerName);

                        Console.WriteLine(team.RemovePlayer(playerToRemove));

                        break;
                    case "RT":
                        Console.WriteLine(team.Report());

                        break;
                }
            }
        }
    }
}

namespace _08._Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var contests = new Dictionary<string, string>();

            string command;
            while ((command = Console.ReadLine()) != "end of contests")
            {
                string[] commandInfo = command.Split(":");
                string contest = commandInfo[0];
                string password = commandInfo[1];

                contests.Add(contest, password);
            }

            var users = new SortedDictionary<string, Dictionary<string, int>>();

            while ((command = Console.ReadLine()) != "end of submissions")
            {
                string[] commandInfo = command.Split("=>");
                string contest = commandInfo[0];
                string password = commandInfo[1];
                string username = commandInfo[2];
                int points = int.Parse(commandInfo[3]);

                if (contests.ContainsKey(contest) && contests[contest] == password)
                {
                    if (!users.ContainsKey(username))
                    {
                        users.Add(username, new Dictionary<string, int>());
                    }

                    if (!users[username].ContainsKey(contest))
                    {
                        users[username].Add(contest, points);
                    }
                    else
                    {
                        if (users[username][contest] < points)
                        {
                            users[username][contest] = points;
                        }
                    }
                }
            }

            var totalPoints = new SortedDictionary<int, string>();

            foreach (var user in users)
            {
                int usersTotalPoints = user.Value.Sum(x => x.Value);
                totalPoints.Add(usersTotalPoints, user.Key);
            }

            var bestCandidate = totalPoints.Reverse().First();

            Console.WriteLine($"Best candidate is {bestCandidate.Value} with total {bestCandidate.Key} points.");
            Console.WriteLine($"Ranking:");

            foreach (var (username, personalContests) in users)
            {
                Console.WriteLine(username);

                foreach (var (contestName, points) in personalContests.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contestName} -> {points}");
                }
            }
        }
    }
}

namespace _09._SoftUni_Exam_Results
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var userPoints = new Dictionary<string, int>();
            var submissions = new Dictionary<string, int>();
            var userData = new Dictionary<string, Dictionary<string, double>>();

            string input;
            while ((input = Console.ReadLine()) != "exam finished")
            {
                var inputArgs = input.Split("-");
                string user = inputArgs[0];
                string languageOrBan = inputArgs[1];

                if (languageOrBan == "banned")
                {
                    userPoints.Remove(user);
                }
                else
                {
                    int points;
                    if (int.TryParse(inputArgs[2], out points))
                    {
                        userPoints[user] = Math.Max(userPoints.GetValueOrDefault(user), points);
                        submissions[languageOrBan] = submissions.GetValueOrDefault(languageOrBan) + 1;

                        if (!userData.ContainsKey(user))
                        {
                            userData[user] = new Dictionary<string, double>();
                        }
                        userData[user][languageOrBan] = points;
                    }
                    else
                    {
                        Console.WriteLine($"Invalid points for user {user}. Skipping entry.");
                    }
                }
            }

            Console.WriteLine("Results:");
            foreach (var kvp in userPoints
                         .OrderByDescending(x => x.Value)
                         .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} | {kvp.Value}");
            }

            Console.WriteLine("Submissions:");
            foreach (var kvp in submissions
                         .OrderByDescending(x => x.Value)
                         .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}

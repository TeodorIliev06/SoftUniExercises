namespace CompanyUsers;

internal class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, List<string>> courseAndMembers = new();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] companyTokens = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
            string companyName = companyTokens[0];
            string employeeId = companyTokens[1];

            if (!courseAndMembers.ContainsKey(companyName))
            {
                courseAndMembers.Add(companyName, new List<string>());
            }
            else if (courseAndMembers.ContainsKey(companyName) && courseAndMembers[companyName].Contains(employeeId))
            {
                continue;
            }
            courseAndMembers[companyName].Add(employeeId);
        }

        foreach (var companyPair in courseAndMembers)
        {
            Console.WriteLine($"{companyPair.Key}");
            for (int i = 0; i < companyPair.Value.Count; i++)
            {
                Console.WriteLine($"-- {companyPair.Value[i]}");
            }
        }
    }
}
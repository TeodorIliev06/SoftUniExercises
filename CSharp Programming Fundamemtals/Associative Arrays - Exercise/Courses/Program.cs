namespace Courses;

internal class Program
{
    static void Main(string[] args)
    {

        Dictionary<string, List<string>> courseAndMembers = new();

        string input;
        while ((input = Console.ReadLine()) != "end")
        {
            string[] courseTokens = input.Split(" : ", StringSplitOptions.RemoveEmptyEntries);
            string courseName = courseTokens[0];
            string studentName = courseTokens[1];

            if (!courseAndMembers.ContainsKey(courseName))
            {
                courseAndMembers.Add(courseName, new List<string>());
            }
            courseAndMembers[courseName].Add(studentName);
        }

        foreach (var coursePair in courseAndMembers)
        {
            Console.WriteLine($"{coursePair.Key}: {coursePair.Value.Count}");
            for (int i = 0; i < coursePair.Value.Count; i++)
            {
                Console.WriteLine($"-- {coursePair.Value[i]}");
            }
        }
    }
}
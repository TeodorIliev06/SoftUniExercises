namespace StudentAcademy;

internal class Program
{
    static void Main(string[] args)
    {
        int lines = int.Parse(Console.ReadLine());
        Dictionary<string, List<double>> studentAndGrade = new();

        for (int i = 0; i < lines; i++)
        {
            string student = Console.ReadLine();
            double grade = double.Parse(Console.ReadLine());

            if (!studentAndGrade.ContainsKey(student))
            {
                studentAndGrade.Add(student, new List<double>());
            }
            studentAndGrade[student].Add(grade);
        }

        foreach (var studentPair in studentAndGrade)
        {
            if (studentPair.Value.Average() >= 4.5)
            {
                Console.WriteLine($"{studentPair.Key} -> {studentPair.Value.Average():f2}");
            }
        }
    }
}
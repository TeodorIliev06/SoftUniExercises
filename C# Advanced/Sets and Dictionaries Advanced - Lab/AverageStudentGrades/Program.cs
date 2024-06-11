using System.Diagnostics;

namespace _02._Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> studentsGrades = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < studentsCount; i++)
            {
                string[] studentInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = studentInfo[0];
                decimal grade = decimal.Parse(studentInfo[1]);

                if (!studentsGrades.ContainsKey(name))
                {
                    studentsGrades.Add(name, new List<decimal>());
                }

                studentsGrades[name].Add(grade);
            }

            foreach (var studentPair in studentsGrades)
            {
                Console.Write($"{studentPair.Key} -> ");

                studentPair.Value.ForEach(g => Console.Write($"{g:f2} "));
                
                Console.Write($"(avg: {studentPair.Value.Average():f2})");
                Console.WriteLine();
            }
        }
    }
}

namespace _02._Exam_Preparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int FailedTreshhold = int.Parse(Console.ReadLine());
            int FailedTimes = 0;
            int SolvedProblemsCount = 0;
            double GradeSum = 0;
            string LastProblem = "";
            bool IsFailed = true;

            while (FailedTimes < FailedTreshhold)
            {
                string ProblemName = Console.ReadLine();

                if (ProblemName == "Enough")
                {
                    IsFailed = false;
                    break;
                }

                int grade = int.Parse(Console.ReadLine());

                if (grade <= 4)
                {
                    FailedTimes++;
                }

                if (FailedTimes == FailedTreshhold)
                {
                    IsFailed = true;
                    break;
                }
                GradeSum += grade;
                SolvedProblemsCount++;
                LastProblem = ProblemName;
            }
            if (IsFailed)
            {
                Console.WriteLine($"You need a break, {FailedTreshhold} poor grades.");
            }
            else
            {
                Console.WriteLine($"Average score: {(GradeSum / SolvedProblemsCount):f2}");
                Console.WriteLine($"Number of problems: {SolvedProblemsCount}");
                Console.WriteLine($"Last problem: {LastProblem}");
            }
        }
    }
}
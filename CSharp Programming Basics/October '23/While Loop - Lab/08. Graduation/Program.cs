using System;

namespace ReadText
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int currentClass = 1;
            int excluded = 0;
            double sumGrades = 0;
            bool isExcluded = false;

            while (currentClass <= 12)
            {
                double grade = double.Parse(Console.ReadLine());

                if (grade < 4.00)
                {
                    excluded++;
                }
                else if (grade >= 4.00)
                {
                    currentClass++;
                    sumGrades += grade;
                }
                if (excluded >= 2)
                {
                    isExcluded = true;
                    break;
                }
            }

            double averageGrade = sumGrades / 12;

            if (isExcluded == true)
            {
                Console.WriteLine($"{name} has been excluded at {currentClass} grade");
            }
            else
            {
                Console.WriteLine($"{name} graduated. Average grade: {averageGrade:f2}");
            }
        }
    }
}
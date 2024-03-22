namespace _04.Students;

class Program
{
    static void Main(string[] args)
    {
        int count = int.Parse(Console.ReadLine());
        List<Student> students = new();

        while (count > 0)
        {
            string[] inputToken = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string firstName = inputToken[0];
            string lastName = inputToken[1];
            double grade = double.Parse(inputToken[2]);

            students.Add(new Student(firstName, lastName, grade));
            count--;
        }

        students = students.OrderByDescending(s => s.Grade).ToList();
        students.ForEach(s => Console.WriteLine($"{s.FirstName} {s.LastName}: {s.Grade:f2}"));
    }
}
public class Student
{
    public Student(string firstName, string lastName, double grade)
    {
        FirstName = firstName;
        LastName = lastName;
        Grade = grade;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public double Grade { get; set; }
}

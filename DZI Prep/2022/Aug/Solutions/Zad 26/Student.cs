namespace Zad_26
{
    public class Student : Human
    {
        public Student(string firstName, string lastName, int age, double grade) 
            : base(firstName, lastName, age)
        {
            this.Grade = grade;
        }

        public double Grade { get; init; }

        public override string ToString()
        {
            return string.Format($"{base.ToString()}, grade: {this.Grade:F2}");
        }
    }
}

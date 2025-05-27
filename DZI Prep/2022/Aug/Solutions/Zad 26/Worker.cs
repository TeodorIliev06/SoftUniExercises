namespace Zad_26
{
    public class Worker : Human
    {
        public Worker(string firstName, string lastName, int age, double wage, int workHours)
            : base(firstName, lastName, age)
        {
            this.Wage = wage;
            this.WorkHours = workHours;
        }

        public double Wage { get; init; }
        public int WorkHours { get; init; }

        public override string ToString()
        {
            double salary = this.Wage * this.WorkHours;
            return string.Format($"{base.ToString()}, salary: ${salary:F2}");
        }
    }
}

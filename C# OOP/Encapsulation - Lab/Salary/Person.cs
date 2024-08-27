namespace PersonsInfo;

public class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;

    public Person(string firstName, string lastName, int age, decimal salary)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Salary = salary;
    }

    public string FirstName
    {
        get => firstName;
        private set => firstName = value;
    }
    public string LastName
    {
        get => lastName;
        private set => lastName = value;
    }
    public int Age
    {
        get => age;
        private set => age = value;
    }
    public decimal Salary
    {
        get => salary;
        private set => salary = value;
    }

    public void IncreaseSalary(decimal percentage)
    {
        if (Age < 30)
        {
            Salary += Salary * percentage / 200;
        }

        else
        {
            Salary += Salary * percentage / 100;
        }
    }

    public override string ToString() => $"{FirstName} {LastName} receives {Salary:F2} leva.";
}

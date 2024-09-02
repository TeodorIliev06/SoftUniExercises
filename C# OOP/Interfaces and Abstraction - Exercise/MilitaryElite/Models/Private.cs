using MilitaryElite.Interfaces;
using System.Text;

namespace MilitaryElite.Models;

public class Private : Soldier, IPrivate
{
    public Private(string id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName)
    {
        Salary = salary;
    }

    public decimal Salary { get; private set; }

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:F2}");
        return sb.ToString().TrimEnd();
    }
}

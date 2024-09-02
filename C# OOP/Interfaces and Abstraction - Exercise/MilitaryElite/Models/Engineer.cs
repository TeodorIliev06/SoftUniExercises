using MilitaryElite.Interfaces;
using System.Reflection;
using System.Text;

namespace MilitaryElite.Models;

public class Engineer : SpecialisedSoldier, IEngineer
{
    public Engineer(string id, string firstName, string lastName, decimal salary, string corps) 
        : base(id, firstName, lastName, salary, corps)
    {
        Repairs = new List<IRepair>();
    }

    public ICollection<IRepair> Repairs { get; private set; }

    public void AddRepair(IRepair repair) => Repairs.Add(repair);

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:F2}");
        sb.AppendLine($"Corps: {Corps.ToString()}");
        sb.AppendLine("Repairs:");
        foreach (var repair in Repairs)
        {
            sb.AppendLine(repair.PrintRepair());
        }

        return sb.ToString().TrimEnd();
    }
}

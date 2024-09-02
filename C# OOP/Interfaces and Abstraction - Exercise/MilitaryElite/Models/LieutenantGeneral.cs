using MilitaryElite.Interfaces;
using System.Text;

namespace MilitaryElite.Models;

public class LieutenantGeneral : Private, ILieutenantGeneral
{
    public LieutenantGeneral(string id, string firstName, string lastName, decimal salary) 
        : base(id, firstName, lastName, salary)
    {
        Privates = new List<IPrivate>();
    }

    public ICollection<IPrivate> Privates { get; private set; }

    public void AddPrivate(IPrivate @private)
    {
        Privates.Add(@private);
    }

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:F2}");
        sb.AppendLine("Privates:");
        foreach (var @private in Privates)
        {
            sb.AppendLine($"  {@private}");
        }
        return sb.ToString().TrimEnd();
    }
}

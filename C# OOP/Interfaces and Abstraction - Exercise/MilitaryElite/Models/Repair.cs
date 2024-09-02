using MilitaryElite.Interfaces;
using System.Text;

namespace MilitaryElite.Models;

public class Repair : IRepair
{
    public Repair(string partName, int hoursWorked)
    {
        PartName = partName;
        HoursWorked = hoursWorked;
    }

    public string PartName { get; private set; }

    public int HoursWorked { get; private set; }

    public string PrintRepair()
    {
        StringBuilder sb = new();
        sb.AppendLine($"  Part Name: {PartName} Hours Worked: {HoursWorked}");
        return sb.ToString().TrimEnd();
    }
}

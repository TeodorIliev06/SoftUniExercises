using MilitaryElite.Interfaces;
using MilitaryElite.Models.Enums;
using System.Text;

namespace MilitaryElite.Models;

public class Commando : SpecialisedSoldier, ICommando
{
    public Commando(string id, string firstName, string lastName, decimal salary, string corps) 
        : base(id, firstName, lastName, salary, corps)
    {
        Missions = new List<IMission>();
    }

    public ICollection<IMission> Missions { get; private set; }

    public void AddMission(IMission mission) => Missions.Add(mission);    

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:F2}");
        sb.AppendLine($"Corps: {Corps.ToString()}");
        sb.AppendLine("Missions:");
        foreach (var mission in Missions)
        {
            sb.AppendLine(mission.PrintMission());
        }

        return sb.ToString().TrimEnd();
    }
}

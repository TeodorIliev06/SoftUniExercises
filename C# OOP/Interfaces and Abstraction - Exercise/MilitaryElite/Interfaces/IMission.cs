using MilitaryElite.Models.Enums;

namespace MilitaryElite.Interfaces;

public interface IMission
{
    string CodeName { get; }
    State State { get; }
    void CompleteMission();
    string PrintMission();
}

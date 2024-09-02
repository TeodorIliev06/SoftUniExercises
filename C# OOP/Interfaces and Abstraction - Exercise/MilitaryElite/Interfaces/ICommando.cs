namespace MilitaryElite.Interfaces;

public interface ICommando : ISpecialisedSoldier
{
    ICollection<IMission> Missions { get; }
    void AddMission(IMission mission);
}

namespace MilitaryElite.Interfaces;

public interface IEngineer : ISpecialisedSoldier
{
    ICollection<IRepair> Repairs { get; }
    void AddRepair(IRepair repair);
}

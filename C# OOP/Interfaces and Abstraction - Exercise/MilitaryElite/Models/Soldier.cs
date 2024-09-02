using MilitaryElite.Interfaces;

namespace MilitaryElite.Models;

public abstract class Soldier : ISoldier
{
    protected Soldier(string id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    public string Id { get; init; }

    public string FirstName { get; init; }

    public string LastName { get; init; }
}

using Prototype.Models;

namespace Prototype.Repositories;

public class SandwichMenu
{
    private Dictionary<string, SandwichPrototype> _sandwiches = new();

    //Indexer property
    public SandwichPrototype this[string name]
    {
        get => _sandwiches[name];
        set => _sandwiches.Add(name, value);
    }
}

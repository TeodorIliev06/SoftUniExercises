namespace CollectionHierarchy;

public class AddCollection : ICustomCollection
{
    public ICollection<string> Collection { get; private set; }
    public AddCollection()
    {
        Collection = new List<string>();
    }

    public int Add(string element)
    {
        Collection.Add(element);
        return Collection.Count - 1;
    }
}

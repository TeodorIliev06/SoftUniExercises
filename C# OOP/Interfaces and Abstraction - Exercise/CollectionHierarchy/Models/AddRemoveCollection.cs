namespace CollectionHierarchy;

public class AddRemoveCollection : ICustomCollection
{
    public ICollection<string> Collection { get; private set; }
    public AddRemoveCollection()
    {
        Collection = new List<string>();
    }
    public int Add(string element)
    {
        ((List<string>)Collection).Insert(0, element);
        return 0;
    }

    public string Remove()
    {
        string toReturn = Collection.Last();
        ((List<string>)Collection).RemoveAt(Collection.Count - 1);
        return toReturn;
    }
}

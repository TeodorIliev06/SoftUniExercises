namespace CollectionHierarchy;

public class MyList : ICustomCollection
{
    public ICollection<string> Collection { get; private set; }
    public MyList()
    {
        Collection = new List<string>();
    }
    public int Used => Collection.Count;

    public int Add(string element)
    {
        ((List<string>)Collection).Insert(0, element);
        return 0;
    }

    public string Remove()
    {
        string toReturn = Collection.First();
        ((List<string>)Collection).RemoveAt(0);
        return toReturn;
    }


}

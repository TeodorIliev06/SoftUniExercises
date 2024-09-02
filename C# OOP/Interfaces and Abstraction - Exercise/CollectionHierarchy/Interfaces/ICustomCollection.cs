namespace CollectionHierarchy;

public interface ICustomCollection
{
    ICollection<string> Collection { get; }
    int Add(string element);
}

using System.Collections;

namespace Collection;

public class ListyIterator<T> : IEnumerable<T>
{
    private List<T> list;
    private int index = 0;

    public ListyIterator()
    {
        this.list = new();
    }

    public ListyIterator(IEnumerable<T> collection)
    {
        this.list = new(collection);
    }

    public List<T> List
    {
        get { return list; }
        set { list = value; }
    }

    public void Create(params T[] elements)
    {
        foreach (var element in elements)
        {
            list.Add(element);
        }
    }

    public bool HasNext()
    {
        return index < list.Count - 1;
    }

    public void Print()
    {
        if (list.Count == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        Console.WriteLine(list[index]);
    }

    public void PrintAll()
    {
        if (list.Count == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        foreach (var element in list)
        {
            Console.Write($"{element} ");
        }
        Console.WriteLine();
    }

    public bool Move()
    {
        if (HasNext())
        {
            index++;
            return true;
        }
        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var element in list)
        {
            yield return element;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
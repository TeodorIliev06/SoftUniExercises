namespace CollectionHierarchy;

public class StartUp
{
    static void Main(string[] args)
    {
        AddCollection firstCol = new();
        AddRemoveCollection secondCol = new();
        MyList thirdCol = new();

        string[] arguments = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        AddToCol(firstCol, arguments);
        AddToCol(secondCol, arguments);
        AddToCol(thirdCol, arguments);

        int removeElements = int.Parse(Console.ReadLine());
        for (int i = 0; i < removeElements; i++)
        {
            Console.Write(secondCol.Remove() + " ");
        }
        Console.WriteLine();

        for (int i = 0; i < removeElements; i++)
        {
            Console.Write(thirdCol.Remove() + " ");
        }
    }

    private static void AddToCol(ICustomCollection firstCol, string[] arguments)
    {
        foreach (string arg in arguments)
        {
            Console.Write(firstCol.Add(arg) + " ");
        }
        Console.WriteLine();
    }
}

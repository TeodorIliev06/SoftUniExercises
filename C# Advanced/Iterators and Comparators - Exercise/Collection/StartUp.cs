namespace Collection;
public class StartUp
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        ListyIterator<string> listy;
        if (input.Length > 1)
        {
            listy = new ListyIterator<string>();
            listy.Create(input.Skip(1).ToArray());
        }
        else
        {
            listy = new ListyIterator<string>();
        }

        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            switch (command)
            {
                case "Move":
                    Console.WriteLine(listy.Move());
                    break;
                case "Print":
                    try
                    {
                        listy.Print();
                    }
                    catch (InvalidOperationException IOE)
                    {
                        Console.WriteLine("Invalid Operation!");
                    }
                    break;
                case "PrintAll":
                    listy.PrintAll();
                    break;
                case "HasNext":
                    Console.WriteLine(listy.HasNext());
                    break;
            }
        }
    }
}
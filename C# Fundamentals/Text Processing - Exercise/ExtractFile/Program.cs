namespace ExtractFile;

internal class Program
{

    static void Main(string[] args)
    {
        char[] separator = new char[] { '\\', '.' };
        string[] input = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);
        string name = input[input.Length - 2];
        string extention = input[input.Length - 1];

        Console.WriteLine($"File name: {name}");
        Console.WriteLine($"File extension: {extention}");
    }
}
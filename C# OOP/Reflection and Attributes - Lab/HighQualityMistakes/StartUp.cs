namespace Stealer;

public class StartUp
{
    static void Main(string[] args)
    {
        Spy spy = new();
        string output = spy.AnalyzeAccessModifiers("Stealer.Hacker");
        Console.WriteLine(output);
    }
}
namespace Stealer;

public class StartUp
{
    static void Main(string[] args)
    {
        Spy spy = new();
        string output = spy.StealFieldInfo("Stealer.Hacker", "username", "password");
        Console.WriteLine(output);
    }
}
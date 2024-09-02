using Telephony.Models.Interfaces;

namespace Telephony.Models;

public class Smartphone : ICall, IBrowse
{
    public void Call(string phoneNumber)
    {
        foreach (char ch in phoneNumber)
        {
            if (!char.IsDigit(ch))
            {
                Console.WriteLine("Invalid number!");
                return;
            }
        }

        Console.WriteLine($"Calling... {phoneNumber}");
    }
    public void Browse(string website)
    {
        foreach (char ch in website)
        {
            if (char.IsDigit(ch))
            {
                Console.WriteLine("Invalid URL!");
                return;
            }
        }

        Console.WriteLine($"Browsing: {website}!");
    }
}

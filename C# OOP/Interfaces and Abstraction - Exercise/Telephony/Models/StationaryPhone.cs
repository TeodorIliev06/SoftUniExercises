using Telephony.Models.Interfaces;

namespace Telephony.Models;

public class StationaryPhone : ICall
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

        Console.WriteLine($"Dialing... {phoneNumber}");
    }
}

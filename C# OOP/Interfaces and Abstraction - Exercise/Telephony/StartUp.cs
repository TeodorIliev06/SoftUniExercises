using Telephony.Models.Interfaces;
using Telephony.Models;

namespace Telephony;

public class StartUp
{
    static void Main(string[] args)
    {
        string[] phoneNumbers = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string[] websites = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);
        
        ICall calling = null;
        foreach (string phoneNumber in phoneNumbers)                            
        {
            if(phoneNumber.Length == 10)
            {
                calling = new Smartphone();
                calling.Call(phoneNumber);
            }
            else if(phoneNumber.Length == 7)
            {
                calling = new StationaryPhone();
                calling.Call(phoneNumber);
            }
        }

        foreach (string website in websites)
        {
            IBrowse browser = new Smartphone();
            browser.Browse(website);
        }
    }
}

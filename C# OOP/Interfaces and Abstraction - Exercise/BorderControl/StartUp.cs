using BorderControl.Models;

namespace BorderControl;

public class StartUp
{
    static void Main(string[] args)
    {
        Control bordercontrol = new();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] visitorTokens = input.Split();
            string id;
            if (visitorTokens.Length == 2)
            {
                string model = visitorTokens[0];
                id = visitorTokens[1];
                bordercontrol.AddEntityCheck(new Robot(model, id));
            }
            else
            {
                string name = visitorTokens[0];
                int age = int.Parse(visitorTokens[1]);
                id = visitorTokens[2];
                bordercontrol.AddEntityCheck(new Citizen(name, age, id));
            }
        }

        string fakeId = Console.ReadLine();

        var detainList = bordercontrol.Entities.Where(entity => entity.Id.EndsWith(fakeId));
        foreach (var detained in detainList)
        {
            Console.WriteLine(detained.Id);
        }
    }
}

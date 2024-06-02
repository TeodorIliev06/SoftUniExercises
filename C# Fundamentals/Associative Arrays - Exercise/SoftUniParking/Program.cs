namespace SoftUniParking;

internal class Program
{
    static void Main(string[] args)
    {
        int lines = int.Parse(Console.ReadLine());
        Dictionary<string, User> users = new();

        for (int i = 0; i < lines; i++)
        {
            string[] commandTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string command = commandTokens[0];
            string username = commandTokens[1];

            switch (command)
            {
                case "register":
                    string licencePlate = commandTokens[2];
                    User newUser = new(username, licencePlate);

                    if (users.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licencePlate}");
                    }
                    else
                    {
                        users.Add(username, newUser);
                        Console.WriteLine($"{newUser.UserName} registered {newUser.LicensePlate} successfully");
                    }
                    break;

                case "unregister":

                    if (users.ContainsKey(username))
                    {
                        users.Remove(username);
                        Console.WriteLine($"{username} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                    break;
            }
        }

        foreach (var userPair in users)
        {
            Console.WriteLine(userPair.Value);
        }
    }
}
public class User
{
    public User(string userName, string licensePlate)
    {
        UserName = userName;
        LicensePlate = licensePlate;
    }

    public string UserName { get; set; }

    public string LicensePlate { get; set; }

    public override string ToString() => $"{UserName} => {LicensePlate}";
}
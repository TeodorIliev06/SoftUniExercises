namespace Zad_28
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = @"../../../data.txt";
            using var reader = new StreamReader(path);

            var kinderGarden = new KinderGarden();

            string line;
            while ((line = reader.ReadLine()) != "END")
            {
                var tokens = line.Split();
                var command = tokens[0];

                string id;
                Kid kid;
                switch (command)
                {
                    case "enrollment":
                        try
                        {
                            var firstName = tokens[1];
                            var lastName = tokens[2];
                            id = tokens[3];
                            var age = int.Parse(tokens[4]);
                            var parentLastName = tokens[5];
                            var parentGSM = tokens[6];
                            kid = new Kid(firstName, lastName, id, age, parentLastName, parentGSM);

                            kinderGarden.EnrollKid(kid);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "unsubscribe":
                        id = tokens[1];
                        kinderGarden.ReleaseKid(id);
                        break;
                    case "information":
                        var group = tokens[1];
                        kinderGarden.GroupInfo(group);
                        break;
                    default:
                        Console.WriteLine($"{command} - invalid command");
                        break;
                }
            }

            Console.WriteLine("Have a nice day!");
        }
    }
}

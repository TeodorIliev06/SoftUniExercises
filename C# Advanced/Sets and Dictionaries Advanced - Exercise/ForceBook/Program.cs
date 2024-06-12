namespace _10._ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {

            var forceBook = new Dictionary<string, HashSet<string>>();
            string input;

            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                string[] inputParts = input.Split(new[] { " | ", " -> " }, StringSplitOptions.RemoveEmptyEntries);

                if (input.Contains("|"))
                {
                    string forceSide = inputParts[0];
                    string forceUser = inputParts[1];

                    if (!forceBook.ContainsKey(forceSide))
                    {
                        forceBook.Add(forceSide, new HashSet<string>());
                    }

                    if (!forceBook.Values.Any(set => set.Contains(forceUser)))
                    {
                        forceBook[forceSide].Add(forceUser);
                    }
                }
                else if (input.Contains(" -> "))
                {
                    string forceUser = inputParts[0];
                    string forceSide = inputParts[1];

                    if (!forceBook.ContainsKey(forceSide))
                    {
                        forceBook.Add(forceSide, new HashSet<string>());
                    }

                    if (forceBook.Values.Any(list => list.Contains(forceUser)))
                    {
                        foreach (var side in forceBook
                                     .Where(side => side.Value.Contains(forceUser)))
                        {
                            side.Value.Remove(forceUser);
                            break;
                        }
                    }

                    forceBook[forceSide].Add(forceUser);
                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }
            }

            foreach (var (forceSide, forceUsers) in forceBook
                         .OrderByDescending(x => x.Value.Count)
                         .ThenBy(x => x.Key)
                         .Where(x => x.Value.Count > 0))
            {
                Console.WriteLine($"Side: {forceSide}, Members: {forceUsers.Count}");
                foreach (var forceUser in forceUsers.OrderBy(x => x))
                {
                    Console.WriteLine($"! {forceUser}");
                }
            }
        }
    }
}
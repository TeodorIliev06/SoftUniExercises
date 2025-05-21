namespace Zad_26
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Add matematika informatika IT fizika izpit
            Remove 2
            Add BEL papka
            Update
            Print
            Insert 4 Istoria
            Length 5
            Search IT
            Insert 9 Matura
            Insert 3 DZI
            Print
            END
             */

            var words = new List<string>();

            string line;
            while ((line = Console.ReadLine()) != "END")
            {
                var tokens = line.Split();
                var command = tokens[0];

                int index;
                switch (command)
                {
                    case "Add":
                        var wordsToAdd = tokens.Skip(1);
                        foreach (var word in wordsToAdd)
                        {
                            words.Add(word);
                        }

                        break;
                    case "Update":
                        for (int i = 0; i < words.Count; i++)
                        {
                            var currentWord = words[i];
                            var currentFirstCharacter = currentWord[0];
                            if (Char.IsLetter(currentFirstCharacter))
                            {
                                words[i] = Char.ToUpper(currentFirstCharacter) +
                                           currentWord.Substring(1);
                            }
                        }

                        break;
                    case "Remove":
                        index = int.Parse(tokens[1]);
                        words.RemoveAt(index);

                        break;
                    case "Search":
                        var searchedWord = tokens[1];
                        if (words.Contains(searchedWord))
                        {
                            Console.WriteLine(searchedWord);
                            break;
                        }

                        Console.WriteLine("Not contained");
                        break;
                    case "Length":
                        var desiredLength = int.Parse(tokens[1]);
                        var output = words
                            .Where(w => w.Length == desiredLength)
                            .ToList();

                        if (!output.Any())
                        {
                            Console.WriteLine("Not contained");
                            break;
                        }

                        Console.WriteLine(string.Join('-', output));
                        break;
                    case "Insert":
                        try
                        {
                            index = int.Parse(tokens[1]);
                            var wordToInsert = tokens[2];

                            words.Insert(index, wordToInsert);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("There are not enough items in the list.");
                        }

                        break;
                    case "Print":
                        Console.WriteLine(string.Join("; ", words));
                        break;
                }
            }
        }
    }
}

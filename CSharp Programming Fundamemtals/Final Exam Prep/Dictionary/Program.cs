namespace Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> dictionary = new();

            // Storing words and their definitions in the dictionary
            string[] wordDefinitions = Console.ReadLine().Split(" | ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var wordDefinition in wordDefinitions)
            {
                string[] parts = wordDefinition.Split(": ");
                string word = parts[0];
                string definition = parts[1];

                //If the dictionary doesn't contain the word - we create a list for its definitions
                if (!dictionary.ContainsKey(word))
                {
                    dictionary[word] = new List<string>();
                }
                dictionary[word].Add(definition);
            }


            string[] wordsToTest = Console.ReadLine().Split(" | ");
            string command = Console.ReadLine();

            if (command == "Test")
            {
                //Check each word in the dictionary that matches the test words
                foreach (var word in wordsToTest)
                {
                    if (dictionary.ContainsKey(word))
                    {
                        Console.WriteLine($"{word}:");
                        foreach (var definition in dictionary[word])
                        {
                            Console.WriteLine($" -{definition}");
                        }
                    }
                }
            }
            else
            {
                foreach (var word in dictionary.Keys)
                {
                    Console.Write($"{word} ");
                }
            }
        }
    }
}
/*
programmer: an animal, which turns coffee into code | developer: a magician
fish | domino
Hand Over
 */
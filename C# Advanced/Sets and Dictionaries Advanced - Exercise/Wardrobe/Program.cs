namespace _06._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var clothes = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < count; i++)
            {
                var input = ReadStringArr(" -> ");
                string colour = input[0];
                var clothing = input[1].Split(',', StringSplitOptions.RemoveEmptyEntries);

                if (!clothes.ContainsKey(colour))
                {
                    clothes[colour] = new Dictionary<string, int>();
                }
                foreach (string item in clothing)
                {
                    if (!clothes[colour].ContainsKey(item))
                    {
                        clothes[colour].Add(item, 0);
                    }
                    clothes[colour][item]++;
                }
            }

            string[] searchedClothing = ReadStringArr(" ");
            string searchedColour = searchedClothing[0];
            string searchedType = searchedClothing[1];

            foreach (var (colour, clothing) in clothes)
            {
                Console.WriteLine($"{colour} clothes:");
                foreach (var (type, ctr) in clothing)
                {
                    if (type == searchedType && colour == searchedColour)
                    {
                        Console.WriteLine($"* {type} - {ctr} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {type} - {ctr}");
                    }
                }
            }
        }

        private static string[] ReadStringArr(string separator)
        {
            return Console.ReadLine()
                .Split(separator, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}

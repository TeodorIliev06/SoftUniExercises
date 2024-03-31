namespace AMinerTask;

internal class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, uint> resourcesMap = new();

        string input;
        while ((input = Console.ReadLine()) != "stop")
        {
            if (!resourcesMap.ContainsKey(input))
            {
                resourcesMap.Add(input, 0);
            }

            uint quantity = uint.Parse(Console.ReadLine());
            resourcesMap[input] += quantity;
        }

        foreach (var itemPair in resourcesMap)
        {
            Console.WriteLine($"{itemPair.Key} -> {itemPair.Value}");
        }
    }
}
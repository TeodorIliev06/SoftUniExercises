namespace TempleOfDoom;

public class StartUp
{
    static void Main(string[] args)
    {
        int[] firstSeq = ReadIntArr();
        Queue<int> tools = new(firstSeq);

        int[] secondSeq = ReadIntArr();
        Stack<int> substances = new(secondSeq);

        List<int> challenges = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        while (true)
        {
            int currTool = tools.Peek();
            int currSubstance = substances.Peek();
            int currValue = currTool * currSubstance;

            if (challenges.Any(c => c == currValue))
            {
                tools.Dequeue();
                substances.Pop();
                challenges.Remove(currValue);

                if (challenges.Count == 0)
                {
                    Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");
                    break;
                }
            }
            else
            {
                tools.Enqueue(tools.Dequeue() + 1);
                substances.Push(substances.Pop() - 1);

                if (substances.Peek() == 0)
                {
                    substances.Pop();
                }

                if (substances.Count == 0)
                {
                    Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");
                    break;
                }
            }
        }

        if (tools.Count > 0)
        {
            Console.WriteLine($"Tools: {string.Join(", ", tools)}");
        }
        if (substances.Count > 0)
        {
            Console.WriteLine($"Substances: {string.Join(", ", substances)}");
        }
        if (challenges.Count > 0)
        {
            Console.WriteLine($"Challenges: {string.Join(", ", challenges)}");
        }
    }

    private static int[] ReadIntArr()
    {
        return Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
    }
}
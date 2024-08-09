namespace WormsAndHoles;

public class StartUp
{
    static void Main(string[] args)
    {
        int[] firstSeq = ReadIntArr();
        Stack<int> worms = new Stack<int>(firstSeq);

        int[] secondSeq = ReadIntArr();
        Queue<int> holes = new Queue<int>(secondSeq);

        int initialWorms = worms.Count;
        int matches = 0;

        while (worms.Any() && holes.Any())
        {
            int currWormValue = worms.Peek();
            int currHoleValue = holes.Peek();

            if (currWormValue == currHoleValue)
            {
                worms.Pop();
                holes.Dequeue();
                matches++;
            }
            else
            {
                holes.Dequeue();
                worms.Push(worms.Pop() - 3);
                if (worms.Peek() < 1)
                {
                    worms.Pop();
                }
            }
        }

        //First output
        if (matches == 0)
        {
            Console.WriteLine("There are no matches.");
        }
        else
        {
            Console.WriteLine($"Matches: {matches}");
        }

        //Second output
        if (!worms.Any() && matches == initialWorms)
        {
            Console.WriteLine("Every worm found a suitable hole!");
        }
        else if (!worms.Any())
        {
            Console.WriteLine("Worms left: none");
        }
        else
        {
            Console.WriteLine($"Worms left: {string.Join(", ", worms)}");
        }

        //Third output
        if (!holes.Any())
        {
            Console.WriteLine("Holes left: none");
        }
        else
        {
            Console.WriteLine($"Holes left: {string.Join(", ", holes)}");
        }
    }

    private static int[] ReadIntArr()
    {
        return Console.ReadLine().Split().Select(int.Parse).ToArray();
    }
}

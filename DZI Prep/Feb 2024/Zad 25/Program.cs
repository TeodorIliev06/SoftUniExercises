namespace Zad_25
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
1 23 29 18 43 21 20
Add 5 
Remove 5 
Shift left 3 
Shift left 1 
End 
             */
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var numbers = new List<int>(input);

            string line;
            while ((line = Console.ReadLine()) != "End")
            {
                var tokens = line.Split();
                var command = tokens[0];

                int number, index, count;
                switch (command)
                {
                    case "Add":
                        number = int.Parse(tokens[1]);
                        numbers.Add(number);

                        break;
                    case "Insert":
                        number = int.Parse(tokens[1]);
                        index = int.Parse(tokens[2]);
                        numbers.Insert(index, number);

                        break;
                    case "Remove":
                        index = int.Parse(tokens[1]);
                        numbers.RemoveAt(index);

                        break;
                    case "Shift":
                        var shiftDirection = tokens[1];
                        count = int.Parse(tokens[2]);
                        if (shiftDirection == "left")
                        {
                            for (int i = 0; i < count; i++)
                            {
                                numbers.Add(numbers[0]);
                                numbers.RemoveAt(0);
                            }
                        }
                        else if (shiftDirection == "right")
                        {
                            for (int i = 0; i < count; i++)
                            {
                                numbers.Insert(0, numbers[numbers.Count - 1]);
                                numbers.RemoveAt(numbers.Count - 1);
                            }
                        }

                        break;
                }
            }

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}

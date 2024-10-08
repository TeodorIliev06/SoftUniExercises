namespace EnterNumbers;

public class StartUp
{    
    static void Main(string[] args)
    {
        int start = 1;
        int end = 100;

        int[] numbers = new int[10];
        int currIndex = 0;
        while (numbers[numbers.Length - 1] == 0) // Until the last index is filled
        {
            try
            {
                int currNum = ReadNumber(start, end);
                start = currNum;
                numbers[currIndex] = currNum;
                currIndex++;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Number!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        Console.WriteLine(String.Join(", ", numbers));
    }
    public static int ReadNumber(int start, int end)
    {

        int number = int.Parse(Console.ReadLine());
        if (number <= start || number >= end)
        {
            throw new ArgumentException($"Your number is not in range {start} - 100!");
        }
        return number;
    }
}
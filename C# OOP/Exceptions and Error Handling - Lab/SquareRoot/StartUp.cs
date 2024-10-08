namespace SquareRoot;

public class StartUp
{
    static void Main(string[] args)
    {
        try
        {
            int number = int.Parse(Console.ReadLine());
            if (number < 0)
            {
                throw new ArithmeticException("Invalid number.");
            }
            Console.WriteLine(Math.Sqrt(number));
        }
        catch (ArithmeticException ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("Goodbye.");
        }
    }
}
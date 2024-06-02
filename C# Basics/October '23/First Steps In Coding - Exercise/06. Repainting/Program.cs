
public class Program
{
    public static void Main()
    {
        int naylon = int.Parse(Console.ReadLine());
        int paint = int.Parse(Console.ReadLine());
        int diluent = int.Parse(Console.ReadLine());
        int hours = int.Parse(Console.ReadLine());

        naylon += 2;
        double bags = 0.40;
        double newPaint = paint * 1.1;
        double naylonPrice = 1.5;
        double paintPrice = 14.5;
        double diluentPrice = 5.0;

        double totalPrice = naylon * naylonPrice + newPaint * paintPrice + diluent * diluentPrice + bags;
        double workersPrice = hours * (totalPrice * 0.3);
        double sum = workersPrice + totalPrice;

        Console.Write(sum);
    }
}
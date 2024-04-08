using System.Numerics;

namespace MultiplyBigNumber;

internal class Program
{
    static void Main(string[] args)
    {
        BigInteger a = BigInteger.Parse(Console.ReadLine());
        BigInteger b = BigInteger.Parse(Console.ReadLine());

        BigInteger product = a * b;
        Console.WriteLine(product);
    }
}
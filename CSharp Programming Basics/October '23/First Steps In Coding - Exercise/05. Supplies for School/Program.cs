using System;

public class Program
{
    public static void Main()
    {
        int pens = int.Parse(Console.ReadLine());
        int markers = int.Parse(Console.ReadLine());
        int preparat = int.Parse(Console.ReadLine());
        int discount = int.Parse(Console.ReadLine());

        double pensprice = 5.8;
        double markersprice = 7.2;
        double preparatprice = 1.2;

        double fullprice = pens * pensprice + markers * markersprice + preparat * preparatprice;
        double discounted = fullprice - fullprice * discount / 100;

        Console.Write(discounted);
    }
}
using System;

public class Program
{
    public static void Main()
    {
        double suma = double.Parse(Console.ReadLine());
        int months = int.Parse(Console.ReadLine());
        double interest = double.Parse(Console.ReadLine());

        double lihva = suma * (interest / 100);
        double mesechnalihva = lihva / 12;
        double obshto = suma + (mesechnalihva * months);

        Console.WriteLine(obshto);
    }
}
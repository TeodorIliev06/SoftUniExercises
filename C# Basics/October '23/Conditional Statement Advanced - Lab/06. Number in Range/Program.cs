using System;

public class Program
{
    public static void Main()
    {
        double n = double.Parse(Console.ReadLine());
        if (n >= -100 && n <= 100 && n != 0)         
            Console.WriteLine("Yes");        
        else  
            Console.WriteLine("No");
    
    }
}
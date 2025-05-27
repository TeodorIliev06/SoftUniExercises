namespace Zad_25
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            if (a == 0)
            {
                if (b < 0)
                {
                    Console.WriteLine("No real roots");
                }
                else
                {
                    Console.WriteLine("All roots are a solution");
                }
            }

            double discriminant = b / a;

            if (discriminant < 0)
            {
                Console.WriteLine("No real solution, as b/a < 0.");
                if (a > 0)
                    Console.WriteLine("Solution: (-inf, +inf)"); // Always true if a > 0 and b/a < 0
                else
                    Console.WriteLine("Solution: No solution.");
                return;
            }

            double sqrtDiscriminant = Math.Sqrt(discriminant);
            double x1 = -sqrtDiscriminant;
            double x2 = sqrtDiscriminant;

            // Case 3: a > 0 (U-shaped parabola, inequality holds between the roots)
            if (a > 0)
            {
                Console.WriteLine("Solution: x ∈ (" + x1 + ", " + x2 + ")");
            }
            // Case 4: a < 0 (Inverted U-shaped parabola, inequality holds outside the roots)
            else
            {
                Console.WriteLine("Solution: x ∈ (-inf, " + x1 + ") ∪ (" + x2 + ", +inf)");
            }
        }
    }
}

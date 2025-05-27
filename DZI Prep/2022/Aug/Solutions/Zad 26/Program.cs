namespace Zad_26
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var output = new List<Human>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++) 
            {
                var firstName = Console.ReadLine();
                var lastName = Console.ReadLine();
                var age = int.Parse(Console.ReadLine());

                Console.Write("Your choice[s - student] , [w - worker]: ");
                var key = Console.ReadKey();
                Console.WriteLine();

                Human element = null;
                if (char.ToLower(key.KeyChar) == 'w')
                {
                    Console.WriteLine("Please enter the wage and work hours on the next 2 lines");
                    var wage = double.Parse(Console.ReadLine());
                    var workHours = int.Parse(Console.ReadLine());

                    element = new Worker(firstName, lastName, age, wage, workHours);
                }
                else if (char.ToLower(key.KeyChar) == 's')
                {
                    Console.WriteLine("Please enter the grade on the next line");
                    var grade = double.Parse(Console.ReadLine());

                    element = new Student(firstName, lastName, age, grade);
                }

                output.Add(element);
            }

            output.Reverse();
            
            foreach (var element in output)
            {
                Console.WriteLine(element.ToString());
            }
        }
    }
}

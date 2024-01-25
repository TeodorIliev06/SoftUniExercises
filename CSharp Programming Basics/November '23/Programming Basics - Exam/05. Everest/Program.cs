namespace _05._Everest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command;
            int climbedMeters;
            int start = 5364, ctr = 1;
            while (true)
            {
                if (ctr > 5 || start >= 8848)
                {
                    if (start >= 8848)
                    {
                        Console.WriteLine($"Goal reached for {ctr} days!");
                    }
                    else
                    {
                        Console.WriteLine($"Failed!");
                        Console.WriteLine($"{start}");
                    }
                    break;
                }

                command = Console.ReadLine();

                if (command == "END")
                {
                    if (start >= 8848)
                    {
                        Console.WriteLine($"Goal reached for {ctr} days!");
                    }
                    else
                    {
                        Console.WriteLine($"Failed!");
                        Console.WriteLine($"{start}");
                    }
                    break;
                }

                climbedMeters = int.Parse(Console.ReadLine());       
                
                if (command == "Yes")
                {
                    ctr++;
                    if (ctr > 5 || start >= 8848)
                    {
                        if (start >= 8848)
                        {
                            Console.WriteLine($"Goal reached for {ctr} days!");
                        }
                        else
                        {
                            Console.WriteLine($"Failed!");
                            Console.WriteLine($"{start}");
                        }
                        break;
                    }
                    start += climbedMeters;                                        
                }
                else if (command == "No")
                {
                    start += climbedMeters;                    
                }
            }
        }
    }
}
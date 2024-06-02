using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        string pattern = @"[-+]?\d*\.\d+|[-+]?\d+";
        string[] demonNames = input.Split(new char [] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

        List<Demon> demons = new List<Demon>();

        foreach (string name in demonNames)
        {
            int health = CalculateHealth(name);
            double damage = CalculateDamage(name, pattern);
            demons.Add(new Demon(name, health, damage));
        }

        demons = demons.OrderBy(d => d.Name).ToList();
        demons.ForEach(d => Console.WriteLine(d));
    }

    static int CalculateHealth(string name)
    {
        int health = 0;
        foreach (char c in name)
        {
            if (!char.IsDigit(c) && c != '+' && c != '-' && c != '.' && c != '*' && c != '/')
            {
                health += (int)c;
            }
        }
        return health;
    }

    static double CalculateDamage(string name, string pattern)
    {
        double damage = 0;
        List<string> numbers = Regex.Matches(name, pattern)
            .Select(m => m.Value)
            .ToList();

        foreach (string number in numbers)
        {
            double parsedNumber;
            if (double.TryParse(number, out parsedNumber))
            {
                damage += parsedNumber;
            }
        }

        bool multiply = false;
        bool divide = false;

        foreach (char c in name)
        {
            if (c == '*')
            {
                multiply = true;
            }
            else if (c == '/')
            {
                divide = true;
            }

            if (multiply)
            {
                damage *= 2;
                multiply = false;
            }

            if (divide)
            {
                damage /= 2;
                divide = false;
            }
        }

        return damage;
    }
}

class Demon
{
    public string Name { get; }
    public int Health { get; }
    public double Damage { get; }

    public Demon(string name, int health, double damage)
    {
        Name = name;
        Health = health;
        Damage = damage;
    }
    public override string ToString()
    {
        return $"{Name} - {Health} health, {Damage:f2} damage";
    }
}

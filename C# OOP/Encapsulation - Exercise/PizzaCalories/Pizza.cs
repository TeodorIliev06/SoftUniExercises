namespace PizzaCalories;

internal class Pizza
{
    private readonly string name;
    private List<Topping> toppings;
    private Dough dough;

    public Pizza(string name)
    {
        Name = name;
        toppings = new();
    }

    public string Name
    {
        get => name;
        init
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            if (value.Length is < 1 or > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            name = value;
        }
    }
    public List<Topping> Toppings
    {
        get => toppings;
        set => toppings = value;
    }
    public Dough Dough
    {
        get => dough; 
        set => dough = value;
    }

    public void AddToping(Topping topping)
    {
        if (toppings.Count is (< 0 or > 10))
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }
        toppings.Add(topping);
    }

    public double GetTotalCals()
    {
        double totalCals = 0;
        totalCals += dough.GetDoughCals();
        foreach (Topping topping in toppings)
        {
            totalCals += topping.GetToppingCals();
        }
        return totalCals;
    }

    public override string ToString() => $"{Name} - {GetTotalCals():F2} Calories.";
}

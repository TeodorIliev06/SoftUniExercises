namespace PizzaCalories;

internal class Topping
{
	private const double BaseCalories = 2.0;
	private readonly string toppingType;
	private readonly double weight;

    public Topping(string toppingType, double weight)
    {
        ToppingType = toppingType;
        Weight = weight;
    }

    public string ToppingType
    {
		get => toppingType; 
		init
		{
			if(value.ToLower() is not ("meat" or "veggies" or "cheese" or "sauce"))
			{
				throw new ArgumentException($"Cannot place {value} on top of your pizza.");
			}
			toppingType = value;
		}
	}
	public double Weight
	{
		get => weight;
        init
        {
            if (value is <1 or >50)
            {
                throw new ArgumentException($"{ToppingType} weight should be in the range [1..50].");
            }
			weight = value;
        }
    }

    public double GetToppingCals()
    {
        double toppingCals = BaseCalories * weight;
        switch (toppingType.ToLower())
        {
            case "meat":
                toppingCals *= 1.2;
                break;
            case "veggies":
                toppingCals *= 0.8;
                break;
            case "cheese":
                toppingCals *= 1.1;
                break;
            case "sauce":
                toppingCals *= 0.9;
                break;
        }
        return toppingCals;
    }

}

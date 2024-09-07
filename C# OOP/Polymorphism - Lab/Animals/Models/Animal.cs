namespace Animals.Models;

public class Animal
{
	private string name;
	private string favouriteFood;

    public Animal(string name, string favouriteFood)
    {
        Name = name;
        FavouriteFood = favouriteFood;
    }

    public string Name
	{
		get => name; 
		private set { name = value; }
	}
	public string FavouriteFood
	{
		get => favouriteFood;
        private set { favouriteFood = value; }
	}

	public virtual string ExplainSelf() => $"I am {Name} and my favourite food is {FavouriteFood}";
}

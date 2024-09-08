namespace WildFarm.Models;

public abstract class Bird : Animal
{
    private double wingSize;

    protected Bird(string name, double weight, double wingSize)
        : base(name, weight)
    {
        WingSize = wingSize;
    }

    public double WingSize
    {
        get => wingSize;
        protected set { wingSize = value; }
    }

    public override string ToString() => $"{GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";   
}

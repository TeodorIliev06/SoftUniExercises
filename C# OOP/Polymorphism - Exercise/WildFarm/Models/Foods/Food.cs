namespace WildFarm.Models;

public abstract class Food
{
    private int quantity;

    protected Food(int quantity)
    {
        Quantity = quantity;
    }

    public int Quantity
    {
        get => quantity;
        protected set { quantity = value; }
    }

}

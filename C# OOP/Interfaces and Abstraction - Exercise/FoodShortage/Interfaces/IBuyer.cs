namespace FoodShortage.Interfaces;

public interface IBuyer
{
    int Food { get; set; }
    int BuyFood();
    string Name { get; set; }
}

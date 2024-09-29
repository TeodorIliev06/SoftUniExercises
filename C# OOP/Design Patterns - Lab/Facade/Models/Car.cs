namespace Facade.Models;

public class Car
{
    private string _type;
    private string _colour;
    private int _numberOfDoors;
    private string _city;
    private string _address;

    public string Type
    {
        get => _type;
        set => _type = value;
    }
    public string Colour
    {
        get => _colour;
        set => _colour = value;
    }
    public int NumberOfDoors
    {
        get => _numberOfDoors;
        set => _numberOfDoors = value;
    }
    public string City
    {
        get => _city;
        set => _city = value;
    }
    public string Address
    {
        get => _address;
        set => _address = value;
    }

    public override string ToString() => $"Car type: {Type}, Colour: {Colour}, " +
        $"Number of doors: {NumberOfDoors}, Manifactured in: {City}, at address: {Address}";
}

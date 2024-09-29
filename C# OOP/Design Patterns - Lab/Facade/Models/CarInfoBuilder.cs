namespace Facade.Models;

public class CarInfoBuilder : CarBuilderFacade
{
    public CarInfoBuilder(Car car)
    {
        Car = car;
    }

    public CarInfoBuilder WithType(string type)
    {
        Car.Type = type;
        return this;
    }

    public CarInfoBuilder WithColour(string colour)
    {
        Car.Colour = colour;
        return this;
    }

    public CarInfoBuilder WithNumberOfDoors(int numberOfDoors)
    {
        Car.NumberOfDoors = numberOfDoors;
        return this;
    }
}

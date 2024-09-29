namespace Facade.Models;

public class CarBuilderFacade
{
    protected Car Car { get; set; }

    public CarBuilderFacade()
    {
        Car = new Car();
    }

    public Car Build() => Car;
    public CarInfoBuilder Info => new(Car);
    public CarAddressBuilder Built => new(Car);
}

﻿using Facade.Models;

namespace Facade;

internal class Program
{
    static void Main(string[] args)
    {
        var car = new CarBuilderFacade()
            .Info.WithType("BMW").WithColour("Black").WithNumberOfDoors(5)
            .Built.InCity("Leipzig").AtAddress("Some address 254")
            .Build();

        Console.WriteLine(car);
    }
}

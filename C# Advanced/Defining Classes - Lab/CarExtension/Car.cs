﻿namespace CarManufacturer;

public class Car
{
    private string make;
    private string model;
    private int year;
    private double fuelQuantity;
    private double fuelConsumption;

    public string Make
    {
        get { return this.make; }
        set { this.make = value; }
    }
    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }
    public int Year
    {
        get { return this.year; }
        set { this.year = value; }
    }
    public double FuelQuantity
    {
        get { return this.fuelQuantity; }
        set { this.fuelQuantity = value; }
    }
    public double FuelConsumption
    {
        get { return this.fuelConsumption; }
        set { this.fuelConsumption = value; }
    }

    public void Drive(double distance)
    {
        if (this.FuelQuantity - (distance * this.FuelConsumption) > 0)
        {
            this.FuelQuantity -= (distance * this.FuelConsumption);
        }
        else
        {
            Console.WriteLine("Not enough fuel to perfom this trip!");
        }
    }
    public string WhoAmI()
    {
        return $"Make: {this.Make}\nModel: {this.Model}\nYear: {this.Year}\nFuel: {this.FuelQuantity:f2}";
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingSystem;

public class VendingMachine
{
    public VendingMachine(int buttonCapacity)
    {
        ButtonCapacity = buttonCapacity;
        Drinks = new();
    }

    public int ButtonCapacity { get; set; }
    public List<Drink> Drinks { get; set; }
    public int GetCount => Drinks.Count;
    public void AddDrink(Drink drink)
    {
        if(ButtonCapacity > GetCount)
        {
            Drinks.Add(drink);
        }
    }
    public bool RemoveDrink(string name)
    {
        return Drinks.Remove(Drinks.FirstOrDefault(d => d.Name == name));
    }
    public Drink GetLongest()
    {
        return Drinks.OrderByDescending(d => d.Volume).FirstOrDefault();
    }
    public Drink GetCheapest()
    {
        return Drinks.OrderBy(d => d.Price).FirstOrDefault();
    }
    public string BuyDrink(string name)
    {
        return Drinks.FirstOrDefault(d => d.Name == name).ToString();
    }
    public string Report()
    {
        StringBuilder sb = new();
        sb.AppendLine("Drinks available:");
        foreach (var drink in Drinks)
        {
            sb.AppendLine(drink.ToString());
        }
        return sb.ToString().TrimEnd();
    }
}

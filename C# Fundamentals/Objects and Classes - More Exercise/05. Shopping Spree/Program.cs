using System;
using System.Collections.Generic;
using System.Linq;


class Program
{
    static void Main()
    {
        List<Person> people = new List<Person>();

        string[] peopleInput = Console.ReadLine().Split(';');
        foreach (string personInput in peopleInput)
        {
            string[] personData = personInput.Split('=');
            string personName = personData[0];
            int personMoney = int.Parse(personData[1]);
            people.Add(new Person(personName, personMoney));
            /*same as: 
             * Person person = new Person (personName, personMoney);
               people.Add(person);
            */
        }

        List<Product> products = new List<Product>();

        string[] productsInput = Console.ReadLine().Split(';');
        foreach (string productInput in productsInput)
        {
            string[] productData = productInput.Split('=');
            string productName = productData[0];
            int productCost = int.Parse(productData[1]);
            products.Add(new Product(productName, productCost));
        }

        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            string[] purchaseData = command.Split();
            string personName = purchaseData[0];
            string productName = purchaseData[1];

            Person person = people.FirstOrDefault(p => p.Name == personName);
            Product product = products.FirstOrDefault(p => p.Name == productName);

            if (person != null && product != null)
            {
                person.BuyProduct(product.Name, product.Cost);
            }
        }

        people.ForEach(Console.WriteLine);
    }
}

class Person
{
    public string Name { get; }
    public int Money { get; set; }
    public List<string> Bag { get; } = new List<string>();

    public Person(string name, int money)
    {
        Name = name;
        Money = money;
    }

    public void BuyProduct(string productName, int productCost)
    {
        if (Money >= productCost)
        {
            Bag.Add(productName);
            Money -= productCost;
            Console.WriteLine($"{Name} bought {productName}");
        }
        else
        {
            Console.WriteLine($"{Name} can't afford {productName}");
        }
    }

    public override string ToString()
    {
        if (Bag.Count == 0)
        {
            return $"{Name} - Nothing bought";
        }
        string productsStr = string.Join(", ", Bag);
        return $"{Name} - {productsStr}";
    }
}
class Product
{
    public string Name { get; }
    public int Cost { get; }

    public Product(string name, int cost)
    {
        Name = name;
        Cost = cost;
    }
}

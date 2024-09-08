using System.ComponentModel.Design;
using WildFarm.Models;

namespace WildFarm;

public class StartUp
{
    static void Main(string[] args)
    {
        List<Animal> animals = new();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] animalTokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string animalType = animalTokens[0];
            string name = animalTokens[1];
            double weight = double.Parse(animalTokens[2]);

            string[] foodTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string foodType = foodTokens[0];
            int foodQuantity = int.Parse(foodTokens[1]);

            Food food = null;
            switch (foodType)
            {
                case "Vegetable":
                    food = new Vegetable(foodQuantity);
                    break;
                case "Fruit":
                    food = new Fruit(foodQuantity);
                    break;
                case "Meat":
                    food = new Meat(foodQuantity);
                    break;
                case "Seeds":
                    food = new Seeds(foodQuantity);
                    break;
            }

            double wingSize;
            string livingRegion, breed;

            Animal animal;
            switch (animalType)
            {
                case "Hen":
                    wingSize = double.Parse(animalTokens[3]);
                    animal = new Hen(name, weight, wingSize);
                    BehaveAndAdd(animals, animal);
                    ((Hen)animal).Eat(food);
                    break;
                case "Owl":
                    wingSize = double.Parse(animalTokens[3]);
                    animal = new Owl(name, weight, wingSize);
                    BehaveAndAdd(animals, animal);
                    ((Owl)animal).Eat(food);
                    break;
                case "Mouse":
                    livingRegion = animalTokens[3];
                    animal = new Mouse(name, weight, livingRegion);
                    BehaveAndAdd(animals, animal);
                    ((Mouse)animal).Eat(food);
                    break;
                case "Dog":
                    livingRegion = animalTokens[3];
                    animal = new Dog(name, weight, livingRegion);
                    BehaveAndAdd(animals, animal);
                    ((Dog)animal).Eat(food);
                    break;
                case "Cat":
                    livingRegion = animalTokens[3];
                    breed = animalTokens[4];
                    animal = new Cat(name, weight, livingRegion, breed);
                    BehaveAndAdd(animals, animal);
                    ((Cat)animal).Eat(food);
                    break;
                case "Tiger":
                    livingRegion = animalTokens[3];
                    breed = animalTokens[4];
                    animal = new Tiger(name, weight, livingRegion, breed);
                    BehaveAndAdd(animals, animal);
                    ((Tiger)animal).Eat(food);
                    break;
            }
        }

        Console.WriteLine(String.Join("\n", animals));
    }

    private static void BehaveAndAdd(List<Animal> animals, Animal animal)
    {
        animal.ProduceSound();
        animals.Add(animal);
    }
}

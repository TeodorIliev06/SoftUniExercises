using Singleton.Models.Contracts;

namespace Singleton.Models;

public class SingletonDataContainer : ISingletonContainer
{
    private Dictionary<string, int> _capitals = new();
    private static SingletonDataContainer _instance = new();
    private SingletonDataContainer()
    {
        Console.WriteLine("Initializing singleton object");

        string[] elements = File.ReadAllLines("../../../Utilities/capitals.txt");
        for (int i = 0; i < elements.Length; i += 2)
        {
            _capitals.Add(elements[i], int.Parse(elements[i + 1]));
        }
    }

    public static SingletonDataContainer Instance => _instance;

    public int GetPopulation(string name)
    {
        return _capitals[name];
    }
}

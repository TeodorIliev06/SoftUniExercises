namespace CustomRandomList;

class RandomList : List<string>
{
    private Random random;

    public RandomList()
    {
        random = new();
    }

    public string RandomString()
    {
        int index = random.Next(0, Count);
        string element = this[index];
        RemoveAt(index);
        return element;
    }
}

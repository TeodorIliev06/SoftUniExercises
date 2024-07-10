namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            Person first = new Person();
            Person second = new Person(18);
            Person third = new Person("Jose", 43);
        }
    }
}

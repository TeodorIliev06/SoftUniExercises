namespace GenericScale
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int> test = new EqualityScale<int>(2, 3);
            Console.WriteLine(test.AreEqual());
        }
    }
}

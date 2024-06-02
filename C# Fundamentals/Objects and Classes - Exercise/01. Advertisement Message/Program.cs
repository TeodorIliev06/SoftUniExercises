namespace Advertisement_Message;

internal class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        Ad advertisement = new Ad();

        advertisement.Phrases = new[] {"Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can't live without this product."};

        advertisement.Events = new[] {"Now I feel good.",
            "I have succeeded with this product.",
            "Makes miracles. I am happy of the results!",
            "I cannot believe but now I feel awesome.",
            "Try it yourself, I am very satisfied.",
            "I feel great!"};

        advertisement.Authors = new[] { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };

        advertisement.Cities = new[] { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

        Random rnd = new();

        for (int i = 0; i < n; i++)
        {
            int randomIndex = rnd.Next(advertisement.Phrases.Length);
            string phrase = advertisement.Phrases[randomIndex];

            randomIndex = rnd.Next(advertisement.Events.Length);
            string ev = advertisement.Phrases[randomIndex];

            randomIndex = rnd.Next(advertisement.Authors.Length);
            string author = advertisement.Phrases[randomIndex];

            randomIndex = rnd.Next(advertisement.Cities.Length);
            string city = advertisement.Phrases[randomIndex];
            Console.WriteLine($"{phrase} {ev} {author} – {city}.");
        }
    }
}
public class Ad
{
    public string[] Phrases { get; set; }
    public string[] Events { get; set; }
    public string[] Authors { get; set; }
    public string[] Cities { get; set; }
}
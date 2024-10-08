using System.Text;
namespace Cards;

public class StartUp
{
    static void Main(string[] args)
    {
        List<Card> cards = new();

        string[] cardsTokens = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < cardsTokens.Length; i++)
        {
            try
            {
                string[] currCardTokens = cardsTokens[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);           
                string currCardFace = currCardTokens[0];
                string currCardValue = currCardTokens[1];
                cards.Add(new Card(currCardFace, currCardValue));
            }                       
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                continue;
            }
        }

        Console.WriteLine(String.Join(' ', cards));
    }
}
public class Card
{
    private readonly ICollection<string> faces = new List<string> { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
    private readonly ICollection<string> suits = new List<string> { "S", "H", "D", "C" };

    private string face;
    private string suit;

    public Card(string face, string suit)
    {
        Face = face;
        Suit = suit;
    }

    public string Face
    {
        get => face;
        init
        {
            if (!faces.Contains(value))
            {
                throw new ArgumentException("Invalid card!");
            }
            face = value;
        }
    }
    public string Suit
    {
        get => suit;
        init
        {
            if (!suits.Contains(value))
            {
                throw new ArgumentException("Invalid card!");
            }
            suit = value;
        }
    }

    public override string ToString()
    {
        //Will get the UTF8 value using byte[]
        byte[] bytes;
        string suitToAppend;
        StringBuilder sb = new();
        sb.Append($"[{face}");
        switch (suit)
        {
            case "S":
                bytes = Encoding.UTF8.GetBytes("\u2660");
                suitToAppend = Encoding.UTF8.GetString(bytes);
                sb.Append($"{suitToAppend}]");
                break;
            case "H":
                bytes = Encoding.UTF8.GetBytes("\u2665");
                suitToAppend = Encoding.UTF8.GetString(bytes);
                sb.Append($"{suitToAppend}]");
                break;
            case "D":
                bytes = Encoding.UTF8.GetBytes("\u2666");
                suitToAppend = Encoding.UTF8.GetString(bytes);
                sb.Append($"{suitToAppend}]");
                break;
            case "C":
                bytes = Encoding.UTF8.GetBytes("\u2663");
                suitToAppend = Encoding.UTF8.GetString(bytes);
                sb.Append($"{suitToAppend}]");
                break;
        }
        return sb.ToString().TrimEnd();
    }
}
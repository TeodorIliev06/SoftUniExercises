internal class Program
{
    static void Main(string[] args)
    {
        int lines = int.Parse(Console.ReadLine());
        List<Article> articles = new();

        for (int i = 0; i < lines; i++)
        {
            string[] text = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string title = text[0];
            string content = text[1];
            string author = text[2];

            articles.Add(new Article(title, content, author));
        }

        articles.ForEach(a => Console.WriteLine(a));
    }
}
public class Article
{
    public string Title;
    public string Content;
    public string Author;

    public Article(string title, string content, string author)
    {
        Title = title;
        Content = content;
        Author = author;
    }

    public override string ToString()
    {
        return $"{Title} - {Content}: {Author}";
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        string[] text = ReadStringArr(", ");
        int lines = int.Parse(Console.ReadLine());

        string title = text[0];
        string content = text[1];
        string author = text[2];
        Article article = new(title, content, author);

        for (int i = 0; i < lines; i++)
        {
            string[] tokens = ReadStringArr(": ");
            string command = tokens[0];
            string newChange = tokens[1];

            switch (command)
            {
                case "Edit":
                    article.ChangeContent(newChange);
                    break;
                case "ChangeAuthor":
                    article.ChangeAuthor(newChange);
                    break;
                case "Rename":
                    article.ChangeTitle(newChange);
                    break;
            }
        }
        Console.WriteLine(article);
    }

    private static string[] ReadStringArr(string separator)
    {
        return Console.ReadLine()
                    .Split(separator, StringSplitOptions.RemoveEmptyEntries);
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

    public void ChangeTitle(string newTitle)
    {
        Title = newTitle;
    }
    public void ChangeContent(string newContent)
    {
        Content = newContent;
    }
    public void ChangeAuthor(string newAuthor)
    {
        Author = newAuthor;
    }
    public override string ToString()
    {
        return $"{Title} - {Content}: {Author}";
    }
}

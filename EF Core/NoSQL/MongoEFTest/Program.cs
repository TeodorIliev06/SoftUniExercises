namespace MongoEFTest
{
	using System.Text.Json;
	using MongoDB.Driver;

	using Data.Models;

	internal class Program
	{
		static async Task Main(string[] args)
		{
			//TODO - Download Compass. Add connection string
			var mongoClient = new MongoClient("mongodb://teodor:test@localhost:27017");
			var db = mongoClient.GetDatabase("Articles");
			var collection = db.GetCollection<Article>("Articles");

			string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
				"..", "..", "..", "..", "MongoEFTest.Data", "Datasets", "articles.json");
			string data = await File.ReadAllTextAsync(path);

			var articles = JsonSerializer.Deserialize<List<Article>>(data);
			await collection.InsertManyAsync(articles);
		}
	}
}

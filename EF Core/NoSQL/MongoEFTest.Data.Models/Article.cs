namespace MongoEFTest.Data.Models
{
	using MongoDB.Bson;

	public class Article
	{
		public ObjectId Id { get; set; }

		public required string Author { get; set; }

		public DateTime Date { get; set; }

		public required string Name { get; set; }

		public int Rating { get; set; }
	}
}

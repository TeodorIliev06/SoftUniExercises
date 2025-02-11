namespace BlogWorkshopMVC.Services.Data
{
	using BlogWorkshopMVC.Data.Models;
	using Services.Data.Contracts;

	public class ArticleService : IArticleService
	{
		public ArticleService() //Should be done with a DI of a generic repository
		{
			
		}

		public IEnumerable<Article> GetAllArticles()
		{
			throw new NotImplementedException();
		}
	}
}

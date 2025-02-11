namespace BlogWorkshopMVC.Services.Data.Contracts
{
	using BlogWorkshopMVC.Data.Models;

	public interface IArticleService
	{
		IEnumerable<Article> GetAllArticles();
	}
}

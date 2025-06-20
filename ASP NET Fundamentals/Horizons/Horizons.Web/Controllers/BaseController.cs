namespace Horizons.Web.Controllers
{
    using System.Security.Claims;
    using Microsoft.AspNetCore.Mvc;

    public abstract class BaseController : Controller
    {
        protected bool IsUserAuthenticated()
        {
            return this.User.Identity?.IsAuthenticated ?? false;
        }

        protected string? GetUserId()
        {
            string? userId = null;
            var isAuthenticated = this.IsUserAuthenticated();

            if (isAuthenticated)
            {
                userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            return userId;
        }
    }
}

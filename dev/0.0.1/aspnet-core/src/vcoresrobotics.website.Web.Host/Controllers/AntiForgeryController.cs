using Microsoft.AspNetCore.Antiforgery;
using vcoresrobotics.website.Controllers;

namespace vcoresrobotics.website.Web.Host.Controllers
{
    public class AntiForgeryController : websiteControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}

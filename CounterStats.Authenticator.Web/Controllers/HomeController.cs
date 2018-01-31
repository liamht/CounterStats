using System.Web.Mvc;

namespace CounterStats.Authenticator.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string steamId)
        {
            return Content(steamId);
        }
    }
}
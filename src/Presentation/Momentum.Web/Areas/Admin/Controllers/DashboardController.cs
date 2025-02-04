using Microsoft.AspNetCore.Mvc;

namespace Momentum.Web.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}

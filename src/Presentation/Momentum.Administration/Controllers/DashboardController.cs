using Microsoft.AspNetCore.Mvc;

namespace Momentum.Administration.Controllers
{
    public class DashboardController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}

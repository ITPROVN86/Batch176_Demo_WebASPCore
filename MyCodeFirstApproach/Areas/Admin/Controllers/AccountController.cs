using Microsoft.AspNetCore.Mvc;

namespace MyCodeFirstApproach.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

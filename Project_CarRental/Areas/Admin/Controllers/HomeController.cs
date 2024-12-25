using Project_CarRental.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Project_CarRental.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //if (!Functions.IsLogin())
                //return RedirectToAction("Index", "Login");
            return View();
        }
        public IActionResult Logout()
        {
            Functions._AdminUserID = 0;
            Functions._UserName = string.Empty;
            Functions._Email = string.Empty;
            Functions._Message = string.Empty;
            Functions._MessageEmail = string.Empty;

            return RedirectToAction("Index", "Home");
        }
    }
}

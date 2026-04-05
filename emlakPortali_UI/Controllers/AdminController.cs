using Microsoft.AspNetCore.Mvc;

namespace emlakPortali_Web.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Listings()
        {
            return View();
        }
        public IActionResult Approvals()
        {
            return View();
        }
        public IActionResult Users()
        {
            return View();
        }
    }
}
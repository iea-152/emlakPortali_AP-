using Microsoft.AspNetCore.Mvc;

namespace emlakPortali_Web.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult MyListings()
        {
            return View();
        }

        public IActionResult AddListing()
        {
            return View();
        }
    }
}
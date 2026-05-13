using Microsoft.AspNetCore.Mvc;

namespace emlakPortali_Web.Controllers
{
    public class ListingController : Controller
    {
        public IActionResult Detail(int id)
        {
            ViewBag.AdId = id;
            return View();
        }
    }
}
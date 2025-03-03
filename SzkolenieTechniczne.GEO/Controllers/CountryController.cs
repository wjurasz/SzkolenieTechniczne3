using Microsoft.AspNetCore.Mvc;

namespace SzkolenieTechniczne.GEO.Controllers
{
    public class CountryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

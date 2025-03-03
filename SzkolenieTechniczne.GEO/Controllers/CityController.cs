using Microsoft.AspNetCore.Mvc;

namespace SzkolenieTechniczne.GEO.Controllers
{
    public class CityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

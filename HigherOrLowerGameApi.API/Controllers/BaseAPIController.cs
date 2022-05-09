using Microsoft.AspNetCore.Mvc;

namespace HigherOrLowerGameApi.API.Controllers
{
    public class BaseAPIController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}
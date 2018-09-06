using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Portfolio.Controllers
{
    public class PortfolioController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        
        [Route("projects")]

        public IActionResult Projects()
        {
            return View();
        }

        [Route("contact")]

        public IActionResult Contact()
        {
            return View();
        }
    }
}
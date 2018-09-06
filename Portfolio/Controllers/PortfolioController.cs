using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    public class PortfolioController : Controller
    {
        [HttpGet]
        [Route("")]
        public string Index()
        {
            return $"This is my Index!";
        }

        
        [Route("projects")]

        public string Projects()
        {
            return "These are my projects";
        }

        [Route("contact")]

        public string Contact()
        {
            return "This is my contact info!";
        }
    }
}
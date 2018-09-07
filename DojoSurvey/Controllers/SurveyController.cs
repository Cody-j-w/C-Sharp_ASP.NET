using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DojoSurvey.Models;
using System;

namespace DojoSurvey.Controllers
{
    public class SurveyController : Controller
    {
        public static Survey survey;

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }

        
        [HttpPost("Results")]
        public IActionResult Results(Survey entry)
        {
            
            Console.WriteLine("##################");
            Console.WriteLine("Making it to the Results action!");
            Console.WriteLine(entry.Name);
            Console.WriteLine(entry.Language);
            Console.WriteLine("##################");
            if(ModelState.IsValid)
            {
            
                return View("Results", entry);
            }
            else
            {

                return View("Index");
            }
        }

        
    }
}
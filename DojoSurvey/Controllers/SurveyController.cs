using Microsoft.AspNetCore.Mvc;

using DojoSurvey.Models;
using System;

namespace DojoSurvey.Controllers
{
    public class SurveyController : Controller
    {   
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        

        
        [HttpPost("Submit")]
        public IActionResult Submit(Survey entry)
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

                return View("Index", entry);
            }
        }

        
    }
}
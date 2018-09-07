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
            return View();
        }

        
        [HttpPost("Submit")]
        public IActionResult SubmitData(Survey entry)
        {
            SurveyController.survey = entry;
            return RedirectToAction("Results");
        }

        [HttpGet]
        [Route("Results")]
        public IActionResult Results()
        {
           Survey survey = SurveyController.survey;
           Console.WriteLine("####################");
           Console.WriteLine(survey.Name);
           Console.WriteLine("####################");
            return View(survey);
            
        }

        
    }
}
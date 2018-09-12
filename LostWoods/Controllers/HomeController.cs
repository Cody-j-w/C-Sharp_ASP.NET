using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LostWoods.Models;
using LostWoods.Factory;

namespace LostWoods.Controllers
{

    
    public class HomeController : Controller
    {

        private readonly TrailFactory _trailFactory;

       public HomeController(TrailFactory tFactory)
       {
           _trailFactory = tFactory;
       }

       [HttpGet("")]
        public IActionResult Index()
        {

            IEnumerable<Trail> AllTrails = _trailFactory.FindAll();

            foreach(Trail trail in AllTrails)
            {
                Console.WriteLine(trail.Name);
            }
            ViewBag.AllTrails = AllTrails;
            return View(AllTrails);
        }

        [HttpGet("NewTrail")]
        public IActionResult NewTrail()
        {
            

            return View();
        }

        [HttpPost("Submit")]
        public IActionResult Submit(Trail trail)
        {
            if(ModelState.IsValid)
            {
                _trailFactory.Add(trail);
                return RedirectToAction("Index");
            }
            else
            {
                return View("NewTrail");
            }
        }

        [HttpGet("trails/{id}")]
        public IActionResult ATrail(int id)
        {
            Trail ThisTrail = _trailFactory.FindOne(id);

            return View("Trail", ThisTrail);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

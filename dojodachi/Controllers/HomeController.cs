using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using dojodachi.Models;

namespace dojodachi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Dojodachi dojodachi = new Dojodachi();

            if(HttpContext.Session.GetInt32("Happiness") != null)
            {
                dojodachi.Happiness = (int)HttpContext.Session.GetInt32("Happiness");
            }
            else
            {
                dojodachi.Happiness = 20;
                HttpContext.Session.SetInt32("Happiness", 20);

            }
            if(HttpContext.Session.GetInt32("Fullness") != null)
            {
                dojodachi.Fullness = (int)HttpContext.Session.GetInt32("Fullness");
            }
            else
            {
                dojodachi.Fullness = 20;
                HttpContext.Session.SetInt32("Fullness", 20);
            }
            if(HttpContext.Session.GetInt32("Energy") != null)
            {
                dojodachi.Energy = (int)HttpContext.Session.GetInt32("Energy");
            }
            else
            {
                dojodachi.Energy = 50;

                HttpContext.Session.SetInt32("Energy", 50);
            }
            if(HttpContext.Session.GetInt32("Meals") != null)
            {
                dojodachi.Meals = (int)HttpContext.Session.GetInt32("Meals");
            }
            else
            {
                dojodachi.Meals = 3;
                HttpContext.Session.SetInt32("Meals", 3);
            }
            
            
            if(HttpContext.Session.GetString("Message") == null)
            {
                dojodachi.Message = "This is your new Dojodachi! Play for it, care for it, keep it from falling into the cold embrace of oblivion!";
            }
            else if(dojodachi.Fullness == 0 || dojodachi.Happiness == 0)
            {
                dojodachi.Message = "Your dojodachi has died!";
            }
            else if(dojodachi.Fullness >= 100 && dojodachi.Happiness >= 100 && dojodachi.Energy >= 100)
            {
                dojodachi.Message = "Congratulations! You've won!";
            }

            else
            {
                dojodachi.Message = HttpContext.Session.GetString("Message");
            }
            
            return View(dojodachi);
        }

        public IActionResult Feed()
        {
            int? Meals = HttpContext.Session.GetInt32("Meals");
            int? Fullness = HttpContext.Session.GetInt32("Fullness");
            Random rand = new Random();
            int dejection = rand.Next(4);
            int consumption = rand.Next(5,11);

            HttpContext.Session.SetInt32("Meals", (int)Meals-1);
            if(dejection == 3)
            {
                HttpContext.Session.SetInt32("Fullness", (int)Fullness);
                HttpContext.Session.SetString("Message", "Your Dojodachi didn't like that one! Meals -1, Fullness unchanged.");
            }
            else
            {
                HttpContext.Session.SetInt32("Fullness", (int)Fullness+consumption);
                HttpContext.Session.SetString("Message", "Your Dojodachi is feeling much more full! Meals -1, Fullness +"+consumption);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Play()
        {
            int? Energy = HttpContext.Session.GetInt32("Energy");
            int? Happiness = HttpContext.Session.GetInt32("Happiness");
            Random rand = new Random();
            int dejection = rand.Next(4);
            int consumption = rand.Next(5,11);

            HttpContext.Session.SetInt32("Energy", (int)Energy-5);
            if(dejection == 3)
            {
                HttpContext.Session.SetInt32("Happiness", (int)Happiness);
                HttpContext.Session.SetString("Message", "Your Dojodachi isn't in the mood to play! Energy -5, Happiness unchanged.");
                
            }
            else
            {
                HttpContext.Session.SetInt32("Happiness", (int)Happiness+consumption);
                HttpContext.Session.SetString("Message", "Your Dojodachi enjoyed that! Energy -5, Happiness +"+consumption);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Work()
        {

            int? Energy = HttpContext.Session.GetInt32("Energy");
            int? Meals = HttpContext.Session.GetInt32("Meals");
            Random rand = new Random();
            int consumption = rand.Next(1,4);

            HttpContext.Session.SetInt32("Energy", (int)Energy-5);
            
            HttpContext.Session.SetInt32("Meals", (int)Meals+consumption);

            HttpContext.Session.SetString("Message", "Your Dojodachi has earned some food! Energy -5, Meals +"+consumption);
            
            return RedirectToAction("Index");
        }

        public IActionResult Sleep()
        {
            int? Energy = HttpContext.Session.GetInt32("Energy");
            int? Fullness = HttpContext.Session.GetInt32("Fullness");
            int? Happiness = HttpContext.Session.GetInt32("Happiness");

            HttpContext.Session.SetInt32("Energy", (int)Energy+15);
            HttpContext.Session.SetInt32("Fullness", (int)Fullness-5);
            HttpContext.Session.SetInt32("Happiness", (int)Happiness-5);
            HttpContext.Session.SetString("Message", "Your Dojodachi is feeling well rested, but eager to do something! Or eat something.");


            return RedirectToAction("Index");

        }

        public IActionResult Reset()
        {
            HttpContext.Session.SetInt32("Fullness", 20);
            HttpContext.Session.SetInt32("Happiness", 20);
            HttpContext.Session.SetInt32("Meals", 3);
            HttpContext.Session.SetInt32("Energy", 50);
            HttpContext.Session.SetString("Message", "Here's your NEW Dojodachi! Try to keep this one away from that cold lonely oblivion, eh?");

            return RedirectToAction("Index");
        }
    }
}

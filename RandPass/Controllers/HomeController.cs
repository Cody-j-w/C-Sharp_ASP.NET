using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RandPass.Models;

namespace RandPass.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {   
            int? Count = 0;
            if(HttpContext.Session.GetInt32("Counter") != null)
            {
            Count = HttpContext.Session.GetInt32("Counter");
            }
            else
            {
                Count = 1;
            }
            
            string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            char[] RandChars = new char[14];
            Random rand = new Random();

            for(int i = 0; i<RandChars.Length; i++)
            {
                RandChars[i] = Chars[rand.Next(Chars.Length)];
            }
            string RandomString = new string(RandChars);

            HttpContext.Session.SetString("RandomString", RandomString);

           
           HttpContext.Session.SetInt32("Counter", (int)Count);

                Counter random = new Counter();
                random.String = HttpContext.Session.GetString("RandomString");
                random.Count = (int)HttpContext.Session.GetInt32("Counter");
            


            return View("Index", random);
        }

        public IActionResult Randomize()
        {
            int? CountInc = HttpContext.Session.GetInt32("Counter");

            CountInc = CountInc + 1;

            HttpContext.Session.SetInt32("Counter", (int)CountInc);

            return RedirectToAction("Index");
        }

        
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuotingDojo.Models;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            
            return View();
        }

        public IActionResult Quotes()
        {
            
            ViewBag.AllQuotes = DbConnector.Query("SELECT * FROM quote");
            return View();
        }

    public IActionResult Submit(string Message, string User)
        {
            DbConnector.Execute($"INSERT INTO quote (Message, User) VALUES ('{Message}', '{User}')");

            return RedirectToAction("Quotes");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

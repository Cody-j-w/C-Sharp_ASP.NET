using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewModel.Models;

namespace ViewModel.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {

            string Message;

            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut et sem vitae diam imperdiet volutpat nec ut arcu. Maecenas luctus consectetur massa, in ultrices metus sagittis at. In semper nunc in varius varius. Curabitur a sapien at arcu aliquam sodales. Phasellus maximus tristique mattis. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur dignissim interdum diam sed maximus. Donec finibus consequat sodales. ";
            return View("Index", Message);
        }
    

        public IActionResult Number()
        {
            int[] Numbers = new int[]
            {
                5,42,72,33,10
            };
            
            return View(Numbers);
        }

        public IActionResult Users()
        {
            User User1 = new User
            {
                FirstName = "Chuck",
                LastName = "Barry"
            };
            User User2 = new User
            {
                FirstName = "Buddy",
                LastName = "Holly"
            };
            User User3 = new User
            {
                FirstName = "Uther",
                LastName = "Pendragon"
            };
            User User4 = new User
            {
                FirstName = "Doc",
                LastName = "Watson"
            };
            User[] Names = new User[4]
            {
                User1, User2, User3, User4
            };

            UserList AllUsers = new UserList(Names);
            foreach(User user in Names)
            {
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine(user.FirstName+" "+ user.LastName);
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~");
            }
            return View(AllUsers);
        }
        public IActionResult AUser()
        {
            User ShownUser = new User()
            {
                FirstName = "Uther",
                LastName = "Pendragon"
            };

            return View(ShownUser);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

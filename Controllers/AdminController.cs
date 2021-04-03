using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientConsuming.Controllers
{
    public class AdminController : Controller
    {
        string Baseurl = "https://localhost:44322/";
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Notification()
        {
            return View();
        }
        
    }
}

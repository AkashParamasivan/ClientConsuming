using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientConsuming.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace ClientConsuming.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login user)
        {
            string token = "";
            using (var httpclient = new HttpClient())
            {
                httpclient.BaseAddress = new Uri("https://localhost:44336/");
                var postData = httpclient.PostAsJsonAsync<Login>("api/Authentication/AuthenicateUser", user);
                var res = postData.Result;
                if (res.IsSuccessStatusCode)
                {
                    token = await res.Content.ReadAsStringAsync();
                    TempData["token"] = token;
                    if (token != null)
                    {
                        return RedirectToAction("Index", "Booking");
                    }
                }
            }
            return View("Login");

        }
    }
}

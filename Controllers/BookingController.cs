using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientConsuming.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace ClientConsuming.Controllers
{
    public class BookingController : Controller
    {
        string Baseurl = "https://localhost:44349/";
        public IActionResult Index(string id)
        {
            return View();
        }
        
        public ActionResult BookService(string id,int cost)
        {
            /*   Booking b = new Booking();
               Booking data = id;*/
            TempData["msg"] = id;
            TempData["msg1"] = cost;
            Booking booking = new Booking();
            booking.Estimatedcost = cost;
            return View(booking);
        }
     
        [HttpPost]
        public async Task<IActionResult> BookService(Booking spec,UserService user)
        {
            string id = (string)TempData.Peek("msg");
            int cost= (int)TempData.Peek("msg1");
            Booking Obj = new Booking();
            spec.CustomerId = id;
            spec.ServiceProviderId = id;
            spec.Estimatedcost = cost * spec.Starttime;
            if (spec.CustomerId == id)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);


                    client.DefaultRequestHeaders.Clear();

                    StringContent content = new StringContent(JsonConvert.SerializeObject(spec), Encoding.UTF8, "application/json");

                    using (var response = await client.PostAsync("/api/Bookings", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        Obj = JsonConvert.DeserializeObject<Booking>(apiResponse);

                    }

                }
                return RedirectToAction("Index");
            }
            else
                return View();
        }

   
    }
}

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
    public class SpecilizationController : Controller
    {
        string Baseurl = "https://localhost:44350/";
        public ActionResult AddSpecilization()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSpecilization(Specilization spec)
        {
            Specilization Obj = new Specilization();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);


                client.DefaultRequestHeaders.Clear();

                StringContent content = new StringContent(JsonConvert.SerializeObject(spec), Encoding.UTF8, "application/json");

                using (var response = await client.PostAsync("/api/Specializations", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Obj = JsonConvert.DeserializeObject<Specilization>(apiResponse);

                }

            }
            return RedirectToAction("Index");
        }
    }
}


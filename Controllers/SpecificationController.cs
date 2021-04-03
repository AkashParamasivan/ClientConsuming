using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientConsuming.Models;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;

namespace ClientConsuming.Controllers
{
    public class SpecificationController : Controller
    {
        string Baseurl = "https://localhost:44306/";
        public ActionResult AddSpecification()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSpecification(Specification spec)
        {
            Specification Obj = new Specification();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);


                client.DefaultRequestHeaders.Clear();

                StringContent content = new StringContent(JsonConvert.SerializeObject(spec), Encoding.UTF8, "application/json");

                using (var response = await client.PostAsync("api/Specifications", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Obj = JsonConvert.DeserializeObject<Specification>(apiResponse);

                }

            }
            return RedirectToAction("Index");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientConsuming.Models;
using System.Net.Http;
using Microsoft.Recognizers.Definitions;
using Newtonsoft.Json;
using System.Text;
using MimeKit;
using System.IO;
using System.Net.Mail;

namespace ClientConsuming.Controllers
{
    public class UserServiceController : Controller
    {
        string Baseurl = "https://localhost:44322/";
        public UserServiceController()
        {

        }
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(UserService user)
        {
            UserService Obj = new UserService();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);


                client.DefaultRequestHeaders.Clear();

                StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

                using (var response = await client.PostAsync("/api/Users", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Obj = JsonConvert.DeserializeObject<UserService>(apiResponse);

                }

            }
            return RedirectToAction("Index");
        }

        public ActionResult UserRegistration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UserRegistration(UserService user)
        {
            UserService Obj = new UserService();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);


                client.DefaultRequestHeaders.Clear();

                StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

                using (var response = await client.PostAsync("/api/Users", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Obj = JsonConvert.DeserializeObject<UserService>(apiResponse);

                }

            }
            return RedirectToAction("Index");
        }


        public async Task<ActionResult> GetUserDetails(string id)
        {
           // _log4net.Info("Booking method called");
            UserService fur = new UserService();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44322/api/Users/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    fur = JsonConvert.DeserializeObject<UserService>(apiResponse);
                }

            }


            //Bill bill = new Bill() { BillOwner = HttpContext.Session.GetString("owner"), FurnitureName = fur.FurnitureName, BillAmount = fur.Price };

            //return RedirectToAction("AddBill", "Billing", bill);
            return View(fur);
        }

        public async Task<bool> IsUserNameExist(string Username, int? id)
      {
            //var validateName = db.ServiceProviders.FirstOrDefault(x => x.ElectricianID == ElectricianID && x.Sid != id);
            UserService validateName = new UserService();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44322/api/Users/Username/" + Username))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    validateName = JsonConvert.DeserializeObject<UserService>(apiResponse);
                }

            }
            if (validateName.Usid != null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public async Task<bool> IsUserAadhaarExist(string Aadhaarno, int? id)
        {
            //var validateName = db.ServiceProviders.FirstOrDefault(x => x.ElectricianID == ElectricianID && x.Sid != id);
            UserService validateName = new UserService();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44322/api/Users/Aadhaar/" + Aadhaarno))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    validateName = JsonConvert.DeserializeObject<UserService>(apiResponse);
                }

            }
            if (validateName.Usid != null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }




    }
}

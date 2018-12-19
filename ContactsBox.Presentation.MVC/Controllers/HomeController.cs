using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ContactsBox.Presentation.MVC.Models;
using AutoMapper;
using ContactsBox.Domain.Entities;
using ContactsBox.Presentation.MVC.ViewModels;
using System;
using System.Net.Http;
using System.Collections;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ContactsBox.Presentation.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;

        public HomeController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = client.GetAsync("https://contactsboxapi.azurewebsites.net/api/contacts").Result;
                    var lista = JsonConvert.DeserializeObject<IList<ContactViewModel>>(response.Content.ReadAsStringAsync().Result);
                    return View(lista);
                }
            }

            catch (Exception) { return View(new List<ContactViewModel>()); }


        }

        public IActionResult Contact()
        {
            return View(new ContactViewModel());
        }

        public IActionResult Edit(int id)
        {
            ContactViewModel contact = new ContactViewModel();
            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = client.GetAsync($"https://contactsboxapi.azurewebsites.net/api/contacts/{id}").Result;
                    contact = JsonConvert.DeserializeObject<ContactViewModel>(response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception) { }

            return View(contact);
        }

        public IActionResult Save(ContactViewModel contact)
        {
            try
            {

                var _contact =  Mapper.Map<ContactViewModel, Contact>(contact);
                using (var client = new HttpClient())
                {
                    if (_contact.Id > 0)
                    {
                        HttpResponseMessage response = client.PutAsJsonAsync($"https://contactsboxapi.azurewebsites.net/api/contacts/", _contact).Result;                     
                    }
                    else
                    {
                        HttpResponseMessage response = client.PostAsJsonAsync($"https://contactsboxapi.azurewebsites.net/api/contacts/", _contact).Result;
                    }
                }
            }
            catch (Exception) { }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = client.DeleteAsync($"https://contactsboxapi.azurewebsites.net/api/contacts/{id}").Result;
                    var lista = JsonConvert.DeserializeObject<IList<ContactViewModel>>(response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception) { }

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

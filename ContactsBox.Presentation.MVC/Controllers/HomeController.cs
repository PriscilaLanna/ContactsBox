using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ContactsBox.Presentation.MVC.Models;
using AutoMapper;
using ContactsBox.Domain.Entities;

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
            return View();
        }
        
        public IActionResult Contact(Contact contact)
        {
            return View();
        }
        
        public IActionResult Save()
        {
            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            return RedirectToAction("Index");
        }

        public IActionResult Delete()
        {
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

using Assignment1.Areas.Identity.Data;
using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Assignment1.Controllers
{
    public class HomeController : Controller
    {
        private Assignment1Context _Context { get; set; }
        private readonly IWebHostEnvironment _hostingEnvironment;

        public HomeController(Assignment1Context content, IWebHostEnvironment hEnvironment)
        {
            _Context = content;
            this._hostingEnvironment = hEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Data()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }



    }
}
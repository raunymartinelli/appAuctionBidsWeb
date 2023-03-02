using Assignment1.Areas.Identity.Data;
using Assignment1.Models;
using Microsoft.AspNet.Identity;
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
            var user = User.Identity.GetUserId();
            var pro = _Context.Products.Where(p => p.user ==user);
            return View(pro);
        }
        public IActionResult Delete(int id)
        {
            var user = User.Identity.GetUserId();
            var pro = _Context.Products.Find(id);
            _Context.Products.Remove(pro);
            _Context.SaveChanges();
            
            return RedirectToAction("Data");
        }
        public IActionResult Add()
        {
            ViewBag.cat = _Context.Categories;
            return View();
        }
        public async Task<IActionResult> addBid(Bid product) {

            product.user = User.Identity.GetUserId();
            string fileName = Path.GetFileNameWithoutExtension(product.ImageUpload.FileName);
            string extension = Path.GetExtension(product.ImageUpload.FileName);
            product.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(_hostingEnvironment.WebRootPath, fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await product.ImageUpload.CopyToAsync(fileStream);
            }
            //Insert record
            _Context.Add(product);
            await _Context.SaveChangesAsync();
            return RedirectToAction("Data");
        }

        public IActionResult Search(string searchText)
        
        {
           var pro =  _Context.Products.Where(bidItem=> bidItem.ItemName.Contains(searchText) || bidItem.ItemDescription.Contains(searchText)).ToList();
            return View(pro);
        }

        public IActionResult Info(int id)
        {
            
            var pro = _Context.Products.Find(id);
            return View(pro);
            


        }


    }
}
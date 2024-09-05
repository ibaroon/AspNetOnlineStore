using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models;
using System.Diagnostics;

namespace OnlineStore.Controllers
{
    public class HomeController : Controller
    {
        SouqcomContext db = new SouqcomContext();
       
        public IActionResult Index()
        {           
            var cats = db.Catigories.ToList();
            ViewBag.prod = db.Products.ToList();
            return View(cats);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Cat()
        {
            var cats =  db.Catigories.ToList();
            return View(cats);
        }

        public IActionResult Products(int id)
        {
            var prods = db.Products.Where(x => x.CatId == id).ToList();
            ViewBag.Cat = db.Catigories.Where(x => x.Id == id).ToList();
            return View(prods);
        }

        public IActionResult ProductDetails(int id)
        {
            var prod = db.Products.Where(x => x.Id == id).ToList();
            return View(prod);
        }

        [HttpGet]
        public IActionResult ProductSearch(string pname)
        {
            var prod = db.Products.Where(x => x.Name.Contains(pname)).ToList();
            ViewBag.pname = pname;
            return View(prod);


        }

        public IActionResult Cart()
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

using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models;
using System.Diagnostics;

namespace OnlineStore.Controllers
{
    public class HomeController : Controller
    {
       

        public IActionResult Index()
        {
            SouqcomContext db = new SouqcomContext();
            var cats = db.Catigories.ToList();
            return View(cats);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Cat()
        {
            SouqcomContext db = new SouqcomContext();
            var cats =  db.Catigories.ToList();
            return View(cats);
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

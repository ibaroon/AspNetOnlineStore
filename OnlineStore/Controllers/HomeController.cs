using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Models;
using System.Diagnostics;
using System.Runtime.InteropServices.JavaScript;

namespace OnlineStore.Controllers
{
    public class HomeController : Controller
    {
        SouqcomContext db = new SouqcomContext();
       
        public IActionResult Index()
        {           
            //var cats = db.Catigories.ToList();
            // you cant pass more than one object so we use viewbag
            //ViewBag.prod = db.Products.ToList();
            //return View(cats);
            //---------------------------------------------------
            //to pass more than one object we have to create class and put all thes object inside it 
            //var cats = db.Catigories.ToList();
            //var prod = db.Products.ToList();
            //var Reve = db.Reviews.ToList();
            // declare object of the class indexVm
            //IndexVm result = new IndexVm();
            //result.Categories = cats;
            //result.Products = prod;
            //result.Reviews = Reve;
            //return View(result);
            //--------------------------- same previous code but in simple way
            IndexVm result = new IndexVm();
            result.Categories = db.Catigories.ToList();
            result.Products = db.Products.ToList();
            result.Reviews = db.Reviews.ToList();
            result.LatestProducts = db.Products.OrderByDescending(x=>x.CreatedAt).Take(4).ToList();
            return View(result);
            //NOTE: see comment into indexVm class  Page
            //NOTE: WE can add any variable into the class and set its value hear and pass it then we can use it in index 
            //example variable sts can be added into the class indexVm
            //and assigned its value controller result.sts=0;
            //And display it in index by @Model.sts
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
            var prod = db.Products.Include(x => x.Cat).Include(x => x.ProductImages).FirstOrDefault(x => x.Id == id);
            // we add Include function to get category details
            return View(prod);
        }

        [HttpGet]
        public IActionResult ProductSearch(string pname)
        {
            var prod = new List<Product>();

            if (String.IsNullOrEmpty(pname))
            {  prod = db.Products.ToList(); }
            else
            {  prod = db.Products.Where(x => x.Name.Contains(pname)).ToList(); }
           
            ViewBag.pname = pname;
            return View(prod);
        }

        [HttpPost]
        public IActionResult SendReview(ReviewFormVm model)
        {
            // --------------------------first way if using GET
            //Review rev = new Review();
            //rev.Name = cname;
            //rev.Email=cemail;
            //rev.Subject = csubject;
            //rev.Description = cmessage;
            //db.Reviews.Add(rev);
            //db.SaveChanges();
            // -------------------------second way if using GET
            //db.Reviews.Add(new Review {Name=cname,Email=cemail,Subject=csubject,Description=cmessage });
            //db.SaveChanges();
            //--------------------------------------------------------Using POST

            // to use DB model ,Form fields must be same as the table columns in names and quantity , so the bet way is to create new class of model example => ReviewFormVm.cs.cs
            //db.Reviews.Add(new Review { Name = model.Name, Email = model.Email, Subject = model.Subject, Description = model.Description });
            //db.SaveChanges();

            //------------------------------------------------------------------------------
            // after creating new class 
            // Form fields names must be same as the class attributs names
            db.Reviews.Add(new Review { Name = model.cName, Email = model.cEmail, Subject = model.cSubject, Description = model.cDescription });
            db.SaveChanges();
            // not returning value but redirecting to index page

           
            GlobalVals.msg = 1;
            return RedirectToAction("Index");
           

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

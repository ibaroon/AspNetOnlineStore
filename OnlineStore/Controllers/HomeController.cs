using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using OnlineStore.Data;
using OnlineStore.Models;
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices.JavaScript;

namespace OnlineStore.Controllers
{
 
    public class HomeController : Controller
    { // logger use to display any messages in the output section below
      // logger use to display any messages in the output section below
        private readonly ILogger<HomeController> _logger;

         ApplicationDbContext IdentityDbTables; // we made an istance of ApplicationDbContext named IdentityDbTables , so it will be used to deal with identity tables 

        // once the IdentityUser,IdentityRole,ApplicationDbContext are injected into program.cs we can use them any where in system like below
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext IdentityDb)
        {
            _logger = logger;
           
            IdentityDbTables = IdentityDb;
        }


        SouqcomContext db = new SouqcomContext();
       

        //ApplicationDbContext dbb = new ApplicationDbContext();

        public IActionResult Index()
        {
            //HttpContext.Session.SetString("TestSession", "hiiiii"); // adding sesion value
           

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
            result.CartCount = db.Carts.Count(x => x.UserId == User.Identity.Name);
            // viewing most sold items
            ViewBag.MostSold = db.OrderDetails.Include(x => x.Product).GroupBy(x => new { x.Product.Name,x.Product.Photo, x.Product.Id }).Select(g => new { id = g.Key.Id, name = g.Key.Name, photo = g.Key.Photo, count = g.Count() }).OrderByDescending(x=>x.count).Take(4).ToList();
            ViewBag.CatCount = db.Catigories.Count();
            ViewBag.ProductCount = db.Products.Count();
            ViewBag.ClientCount = IdentityDbTables.Users.Count();
            ViewBag.OrderCount=db.OrderDetails.Count();
            int CartTotItems = 0;
            if (User.Identity.IsAuthenticated)
            {
                CartTotItems = int.Parse(db.Carts.Where(x=>x.UserId==User.Identity.Name).Sum(x=>x.Quan).ToString());
            }
            else { CartTotItems = 0; }
           

            HttpContext.Session.SetInt32("CartTot", CartTotItems);
            return View(result);
            //NOTE: see comment into indexVm class  Page
            //NOTE: WE can add any variable into the class and set its value hear and pass it then we can use it in index 
            //example variable sts can be added into the class indexVm
            //and assigned its value controller result.sts=0;
            //And display it in index by @Model.sts
        }

        public IActionResult Privacy()
        {
            //var x= HttpContext.Session.GetString("TestSession");
            return View();
        }

        public IActionResult Cat()
        {
            var cats =  db.Catigories.ToList();
            ViewBag.isAdmin = true;
            return View(cats);
        }

        public IActionResult Products(int id)
        {
            var prods = db.Products.Where(x => x.CatId == id).ToList();
            ViewBag.Cat = db.Catigories.Where(x => x.Id == id).ToList();
            ViewBag.isAdmin = true;
            return View(prods);
           
        }

        public IActionResult ProductDetails(int id)
        {
            var prod = db.Products.Include(x => x.Cat).Include(x => x.ProductImages).FirstOrDefault(x => x.Id == id);
            // we add Include function to get category details and product images
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
        [Authorize]
        public IActionResult Cart()
        {
            return View(db.Carts.Include(x=>x.Product).Where(x=>x.UserId==User.Identity.Name).ToList());
        }
        [Authorize]
        public IActionResult AddProductToCart(int id)
        {

            var price = db.Products.Find(id).Price;
            var userid = User.Identity.Name;
            var item=db.Carts.FirstOrDefault(x => x.ProductId == id && x.UserId == userid);
            if (item != null) 
            {
                item.Quan = item.Quan + 1;

            }
            else
            {
                db.Carts.Add(new Cart { ProductId = id, UserId = userid, Quan = 1, Price = price });
               
            }
            db.SaveChanges();
           //var CartTot = HttpContext.Session.GetInt32("CartTot");
            //HttpContext.Session.SetInt32("CartTot",5);


            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public IActionResult CartDeletElement(int id)
        {
            var item = db.Carts.Find(id);
            if (item != null)
            { db.Carts.Remove(item); }
            db.SaveChanges();

            // int CartTotItems = db.Carts.Where(x => x.UserId == User.Identity.Name).Count();
            int CartTotItems = int.Parse(db.Carts.Where(x=>x.UserId==User.Identity.Name).Sum(x=>x.Quan).ToString());
            HttpContext.Session.SetInt32("CartTot", CartTotItems);

            return RedirectToAction("Cart");
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddOrder(Order model)
        {
            DateTime localDate = DateTime.Now;


            Order o = new Order { Name = model.Name, Address = model.Address, Email = model.Email, Phone = model.Phone, PayMeth = model.PayMeth, UserId = User.Identity.Name,OrderDate=localDate,OrderSts=0};
            
            var cartItems = db.Carts.Where(x => x.UserId == User.Identity.Name).ToList();
            OrderDetail od = new OrderDetail();
            
            foreach (var item in cartItems)
            {
                var total= item.Quan * item.Price;
                // !!!!! Important Note : by this way we didnt need to add OrderId in OrderDetails table manualy
                o.OrderDetails.Add(new OrderDetail { ProductId= item.ProductId ,Quan=item.Quan,Price=item.Price,TotalPrice=total});
               
            }
            
            db.Orders.Add(o);
                 
            // remove all data of this dataitems
            db.RemoveRange(cartItems);
            db.SaveChanges();

            ViewBag.OrderId = o.Id;
            ViewBag.UserId = User.Identity.Name;
            ViewBag.PayMeth = model.PayMeth;
            ViewBag.Name = db.Orders.FirstOrDefault(x=>x.Id==o.Id).Name;
            ViewBag.Email = db.Orders.FirstOrDefault(x => x.Id == o.Id).Email;
            ViewBag.Phone = db.Orders.FirstOrDefault(x => x.Id == o.Id).Phone;
            ViewBag.Address = db.Orders.FirstOrDefault(x => x.Id == o.Id).Address;
            ViewBag.Items = db.OrderDetails.Where(x => x.OrderId == o.Id).ToList();
            ViewBag.Itemscount = db.OrderDetails.Where(x => x.OrderId == o.Id).Count();
            ViewBag.tot= db.OrderDetails.Where(x => x.OrderId == o.Id).Sum(x => x.TotalPrice);
            var result = db.OrderDetails.Include(x=>x.Order).Where(x=>x.OrderId==o.Id).Include(x=>x.Product).ToList();
            return View("OrderSuccess");
            
                }

        [Authorize]
        [HttpGet]
        public IActionResult OrderSuccess()
        {
           
            return View();
        }

        [Authorize]
        public IActionResult Orders()
        {
            return View(db.Orders.Include(x => x.OrderDetails).ThenInclude(x=>x.Product).Where(x => x.UserId == User.Identity.Name).ToList());
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult PaymentSuccess()
        {

            return View();
        }
        public IActionResult PaymentFaild()
        {

            return View();
        }
    }
}

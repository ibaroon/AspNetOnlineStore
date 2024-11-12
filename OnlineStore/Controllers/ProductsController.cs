using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Models;
using System;
using System.IO;

namespace OnlineStore.Controllers
{
    public class ProductsController : Controller
    {
        SouqcomContext db = new SouqcomContext();
        private object file;

       
        private readonly IWebHostEnvironment _environment;
        public ProductsController(IWebHostEnvironment environment)
        {

            _environment = environment;
        }

        [Authorize]
        public IActionResult Index()
        {
            var prod = db.Products.Include(x=>x.Cat).ToList();
            return View(prod);
        }
        [Authorize]
        public  IActionResult Details(int? id)
        {
            if (id == null)
            { return NotFound();  }

            var product = db.Products.Include(x=>x.Cat).FirstOrDefault(x => x.Id == id);
            if (product == null)
            { return NotFound();  }

            return View(product);
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Create(ProductVm model)
        {
            if (ModelState.IsValid) 
            { Catigory c = new Catigory();
                c.Name = model.CatName;
                //db.Catigories.Add(c); we didnt use it beacuse it cause duplicate ( this line and Cat=c ) results 2 records od cat
                // After Adding Category , the product we want to add has the same category we added pervious
                // this is present in Cat=c below
                db.Products.Add(new Product { Cat=c,Name = model.ProductName,Price=model.ProductPrice, Description = model.ProductDesc,Quan=model.ProductQuan});
                db.SaveChanges();
            }
            return View("Create", model);
        }
        [Authorize]
        public IActionResult Create2()
        {
            var Catlist = db.Catigories.Select(x => new { x.Id, x.Name }).ToList();
                // converting Catlist into selectlist to display it into the creat2 page 
                ViewBag.CatList= new SelectList(Catlist, "Id", "Name");

            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Create2(ProductVm model, IFormFile file)
        {
            Product p = new Product();
            p.CatId= model.CatId;
            p.Name = model.ProductName;
            p.Price = model.ProductPrice;
            p.Description= model.ProductDesc;
            p.Quan= model.ProductQuan;
            p.CreatedAt= model.CreatedAt;
            db.Products.Add(p);
            //db.Products.Add(entity: new Product { CatId = model.CatId, Name = model.ProductName, Price = model.ProductPrice, Description = model.ProductDesc, Quan = model.ProductQuan, CreatedAt = model.CreatedAt });
            db.SaveChanges();

            if (file != null)
            {   
                string fileName = p.Id + "_" + file.FileName;

                using (var fileStream = new FileStream(Path.Combine(_environment.WebRootPath, "images/products/" + fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                
                p.Photo= "images/products/" + fileName;
               
                db.SaveChanges(); 
            }
       
            return RedirectToAction("index");
        }
        [Authorize]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {  return NotFound();   }

            var product =  db.Products.Include(x=>x.Cat).FirstOrDefault(x => x.Id == id);
            if (product == null)
            {  return NotFound();   }

            return View(product);
        }
        [Authorize]
        // POST: Products/Delete
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = db.Products.Find(id);
            if (product != null)
            {    db.Products.Remove(product);    }
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [Authorize]
        public  IActionResult Edit(int? id)
        {
            var Catlist = db.Catigories.Select(x => new { x.Id, x.Name }).ToList();
           
            if (id == null)
            {    return NotFound();  }

            var product = db.Products.Include(x=>x.Cat).FirstOrDefault(x=>x.Id==id);
            if (product == null)
            {     return NotFound(); }
            ViewBag.CatList = new SelectList(Catlist, "Id", "Name", product.CatId);
            return View(product);
        }
        [Authorize]
        // POST: Catigories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit(int id, ProductVm model,  Product prodcut, IFormFile file)
        {
            var record = db.Products.First(x => x.Id == id);
            if (file != null)
            {
                string fileName = id + "_" + file.FileName;

                using (var fileStream = new FileStream(Path.Combine(_environment.WebRootPath, "images/products/" + fileName), FileMode.Create))
                { file.CopyTo(fileStream); }



                record.Name = model.Name;
                record.CatId = model.CatId;
                record.Price = model.Price;
                record.Quan = model.Quan;
                record.Description = model.Description;
                record.CreatedAt = model.CreatedAt;
                record.Photo = "images/products/" + fileName;
            }
            else
            {
                var old = db.Products.Where(x => x.Id == id).Select(x => new { x.Photo }).ToList();

                record.Name = model.Name;
                record.CatId = model.CatId;
                record.Price = model.Price;
                record.Quan = model.Quan;
                record.Description = model.Description;
                record.CreatedAt = model.CreatedAt;
                //record.Photo = "images/products/" + fileName;

                if(old!=null)
                {
                    foreach (var m in old)
                    { record.Photo = m.Photo; }
                }
                else { record.Name = null; }
               
            }
            
           

                 db.SaveChanges();
                 return RedirectToAction("index");
                   
        }
        [Authorize]
        public IActionResult ProductImages(int? id)
        {
            var img = new List<ProductImage>();
            img=db.ProductImages.Where(x => x.ProductId == id).ToList();
            ViewBag.ProductId= id;
            var Product = db.Products.FirstOrDefault(x => x.Id == id);
            ViewBag.ProductName = Product.Name;
            return View(img);
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddImages(int ProductId, IFormFile file)
        {
            int x = ProductId;
            ProductImage prodImg= new ProductImage();
            prodImg.ProductId = x;  
            db.Add(prodImg);
            db.SaveChanges();


            string fileName = prodImg.Id + "_" + file.FileName;

            using (var fileStream = new FileStream(Path.Combine(_environment.WebRootPath, "images/products/" + fileName), FileMode.Create))
            {   file.CopyTo(fileStream);    }

            // db.ProductImages.Add(entity: new ProductImage {ProductId= ProductId,  Image = "images/products/" + fileName });
            prodImg.Image = "images/products/" + fileName;
            db.SaveChanges();


            return RedirectToAction("ProductImages", new { id = x });
        }
        [Authorize]
        public IActionResult DeleteImage(int? id)
        {
            if (id == null)
            {  return NotFound();   }

            var productImg = db.ProductImages.Include(x => x.Product).FirstOrDefault(x => x.Id == id);
            if (productImg == null)
            {    return NotFound();   }

            return View(productImg);
        }
        [Authorize]
        // POST: ProductImages/Delete
        [HttpPost, ActionName("DeleteImageConfirmed")]
        public IActionResult DeleteImageConfirmed(int id,int ProductId)
        { int x= ProductId;
            var productImg = db.ProductImages.Find(id);
            if (productImg != null)
            {
                db.ProductImages.Remove(productImg);
            }
            db.SaveChanges();
            return RedirectToAction("ProductImages", new { id = x });

        }


    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Models;
using System.Text.Json.Serialization;

namespace OnlineStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesApiController : ControllerBase
    {
        SouqcomContext db = new SouqcomContext();
        // you should define the way of accessing the method (get , post , etc ... ) and define its name like below
        [HttpGet("GetCats")]
        
        public IActionResult ApiGetCats()
        {// Api link = https://localhost:7245/api/ValuesApi/GetCats
          var result = db.Catigories.Select(x =>new{x.Id,x.Name,x.Description,x.Photo }).ToList();
            return Ok(result);
        }
        [HttpGet("GetProducts")]
        public IActionResult ApiGetProducts()
        {// Api link = https://localhost:7245/api/ValuesApi/ApiGetProducts
         //this Api method use to get all product data and  should be called by jquery
         // return Ok(db.Products.Select(x => new { x.Id, x.Name, x.Price, x.Quan }).ToList());
         // to return a result of query like this below you have to make achange in program.cs file
         //below builder.Services.AddControllersWithViews(); put 
         // builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
         // to avoid serialization use a query that select a specific coulmns like below 
            return Ok(db.Products.Include(x => x.Cat).Select(x => new { x.Id, x.Name, x.Price, x.Quan, x.Photo, catname = x.Cat == null ? "" : x.Cat.Name }).ToList());
        }
        [HttpPost("SaveProduct")]
        public IActionResult SaveProduct(Product p)
        {// Api link = https://localhost:7245/api/ValuesApi/SaveProduct
         //this Api method use to save product data and  should be called by jquery
         // this method recive an object of data from type product p
            try
            {
                db.Products.Add(p);
                db.SaveChanges();
                return Ok("Data Saved");
            }
            catch (Exception ex) {
               // internalserver error syntax
               //return StatusCode(StatusCodes.Status500InternalServerError,p);
                return BadRequest(ex.Message);
            }

           
        }

        // if this method recive several prameters [HttpPost("DeleteProduct/{id}/{data}/{etc}")]
        [HttpDelete("DeleteProduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {// Api link = https://localhost:7245/api/ValuesApi/SaveProduct
         //this Api method use to delete product data and  should be called by jquery
         // this method recive a product id
            try
            { 
               var p = db.Products.Find(id);
                if (p != null) {
                    db.Products.Remove(p);
                    db.SaveChanges();
                }
               
                return Ok("Data Removed");
            }
            catch (Exception ex)
            {
                // internalserver error syntax
                //return StatusCode(StatusCodes.Status500InternalServerError,p);
                return BadRequest(ex.Message);
            }


        }

        [HttpPost("UpdateProduct")]
        public IActionResult UpdateProduct(Product p)
        {// Api link = https://localhost:7245/api/ValuesApi/SaveProduct
         //this Api method use to save product data and  should be called by jquery
         // this method recive an object of data from type product p
           
            try
            {
                var record = db.Products.First(x => x.Id == p.Id);
                record.Name =p.Name;
                record.Quan = p.Quan;
                record.Price = p.Price;
                db.SaveChanges();
                return Ok("Data Updated");
            }
            catch (Exception ex)
            {
                // internalserver error syntax
                //return StatusCode(StatusCodes.Status500InternalServerError,p);
                return BadRequest(ex.Message);
            }


        }
    }
}

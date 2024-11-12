using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Data;
using OnlineStore.Models;

namespace OnlineStore.Controllers
{
    public class AdminController : Controller
    {
        // ------------------------------------------------------- Users, Roles ----------------------------------------------------
        
                
        // logger use to display any messages in the output section below
        private readonly ILogger<AdminController> _logger;

        UserManager<IdentityUser> usermanager; // usermanager is an object from UserManager which is IdentityUser type
        RoleManager<IdentityRole> rolemanager; // rolemanager is an object from RoleManager which is IdentityRole type
        ApplicationDbContext IdentityDbTables; // we made an istance of ApplicationDbContext named IdentityDbTables , so it will be used to deal with identity tables 

        // once the IdentityUser,IdentityRole,ApplicationDbContext are injected into program.cs we can use them any where in system like below
        public AdminController(ILogger<AdminController> logger, UserManager<IdentityUser> user, RoleManager<IdentityRole> role, ApplicationDbContext IdentityDb)
        {
            _logger = logger;
            usermanager = user;
            rolemanager = role;
            IdentityDbTables = IdentityDb;
        }

        // ------------------------------------------------------- Users , Roles End -------------------------------------------------

        SouqcomContext db = new SouqcomContext();


        [Authorize(Roles ="Admin")]
        // multi roles if have Admin or SuperAdmin Roles [Authorize(Roles ="Admin,SuperAdmin")]
        // Claim [Authorize(policy: "test")]
        public IActionResult Index()
        {           
            return RedirectToAction("Charts");
        }
        [Authorize]
        public IActionResult Users()
        {
            //var users = usermanager.Users.ToList(); // hear we use usermanager
            var users = IdentityDbTables.Users.ToList(); // hear we use IdentityDbTables as entityframwork
            return View(users ); 
           
        }

        public IActionResult Roles()
        {
            //var roles = rolemanager.Roles.ToList(); // hear we use rolemanager
            var roles = IdentityDbTables.Roles.ToList(); // hear we use IdentityDbTables as entityframwork
            return View(roles); 

        }
       
        // this method use to create roles
        public async Task<IActionResult> AutoCreateRoles()
        {
         //to create Role we can use code below in create page
            await rolemanager.CreateAsync(new IdentityRole { Name = "Admin" });
            await rolemanager.CreateAsync(new IdentityRole { Name = "User" });
            await rolemanager.CreateAsync(new IdentityRole { Name = "Sales" });
         // Note we use CreateAsync Async should use befor it await , so function should be change to async function and add Task<>

            return RedirectToAction("Roles");

        }
//------------------------------------- Role CRUD Functions -----------------------------------//
        public IActionResult RoleDetails(string? id)
        {
            if (id == null)
            { return NotFound(); }

            var role = IdentityDbTables.Roles.FirstOrDefault(x => x.Id == id);
            if (role == null)
            { return NotFound(); }

            return View(role);
        }
        
        public IActionResult CreateRole()
        {
            return View();

        }
        [HttpPost]
        public IActionResult CreateRole(string name,string normalizedname,string concurrencyStamp)
        { 
            IdentityDbTables.Roles.Add(new IdentityRole {Name=name,NormalizedName= normalizedname, ConcurrencyStamp= concurrencyStamp });
            IdentityDbTables.SaveChanges();
            return RedirectToAction("Roles");

        }
        public IActionResult DeleteRole(string? id)
        {
            if (id == null)
            { return NotFound(); }

            var role = IdentityDbTables.Roles.FirstOrDefault(x => x.Id == id);
            if (role == null)
            { return NotFound(); }

            return View(role);
        }
        [HttpPost, ActionName("DeleteRoleConfirmed")]
        public IActionResult DeleteRoleConfirmed(string id)
        {
            var role = IdentityDbTables.Roles.Find(id);
            if (role != null)
            { IdentityDbTables.Roles.Remove(role); }
            IdentityDbTables.SaveChanges();
            return RedirectToAction("Roles");

        }

        public IActionResult EditRole(string? id)
        {   var role = IdentityDbTables.Roles.FirstOrDefault(x => x.Id == id);
            if (role == null)
            { return NotFound(); }
              return View(role);
        }

        [HttpPost]
        public IActionResult EditRole(string? id,string name,string normalizedName,string concurrencyStamp)
        {
            var record = IdentityDbTables.Roles.First(x => x.Id == id);
                record.Name = name;
                record.NormalizedName = normalizedName;
                record.ConcurrencyStamp = concurrencyStamp;


            IdentityDbTables.SaveChanges();
            return RedirectToAction("Roles");

        }
        //------------------------------------- End Role CRUD Functions -------------------------------//
        //------------------------------------- Role CRUD Functions -----------------------------------//
        public IActionResult UserDetails(string? id)
        {
            if (id == null)
            { return NotFound(); }

            var user = IdentityDbTables.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            { return NotFound(); }

            return View(user);
        }

        public IActionResult CreateUser()
        {
            return View();

        }
        [HttpPost]
        public IActionResult CreateUser(string userName, string email, string phoneNumber)
        {
            IdentityDbTables.Users.Add(new IdentityUser { UserName = userName, Email = email, PhoneNumber = phoneNumber });
            IdentityDbTables.SaveChanges();
            return RedirectToAction("Users");

        }

        public IActionResult DeleteUser(string? id)
        {
            if (id == null)
            { return NotFound(); }

            var user = IdentityDbTables.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            { return NotFound(); }

            return View(user);
        }
        [HttpPost, ActionName("DeleteUserConfirmed")]
        public IActionResult DeleteUserConfirmed(string id)
        {
            var user = IdentityDbTables.Users.Find(id);
            if (user != null)
            { IdentityDbTables.Users.Remove(user); }
            IdentityDbTables.SaveChanges();
            return RedirectToAction("Users");

        }
        public IActionResult EditUser(string? id)
        {
            var user = IdentityDbTables.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            { return NotFound(); }
            return View(user);
        }

        [HttpPost]
        public IActionResult EditUser(string? id, string userName, string email, string phoneNumber)
        {
            var record = IdentityDbTables.Users.First(x => x.Id == id);
            record.UserName = userName;
            record.Email = email;
            record.PhoneNumber = phoneNumber;


            IdentityDbTables.SaveChanges();
            return RedirectToAction("Users");

        }

 //------------------------------------- End User CRUD Functions -----------------------------------//
 //------------------------------------------ Permissions -------------------------------------------//
        public async Task<IActionResult> Permissions()
        {
            var users = IdentityDbTables.Users.ToList();// all users
            // now we have to get each user roles through this function
            // now we have to save the user and his roles into a model named UserRoles
            List<UserRolesVm> result = new List<UserRolesVm>(); // declare result as an object of type UserRoleVm
            foreach (var user in users)
            {
              var uRoles= await usermanager.GetRolesAsync(user);
                result.Add(new UserRolesVm {user=user, userRoles= (List<string>)uRoles}); // add values into object
            }
            
            ViewBag.AllRoles = IdentityDbTables.Roles.ToList();
           
            return View(result);

        }
        [HttpGet]
             public async Task<IActionResult> ChangeUserRole(string UserId,string Role)
        {
                var user= await usermanager.FindByIdAsync(UserId);
                var result= await usermanager.AddToRoleAsync(user, Role);
            if(!result.Succeeded)
            {
                await usermanager.RemoveFromRoleAsync(user,Role);
            }
            // we can use IdentityDbTables as entityframework
            return RedirectToAction("Permissions");
        }

 //-------------------------------------- End Permissions -------------------------------------------//

            [Authorize(Roles = "Admin")]
        public IActionResult Charts()
        {
            IndexVm result = new IndexVm();
            result.Categories = db.Catigories.ToList();
            result.Products = db.Products.ToList();
            result.Reviews = db.Reviews.ToList();
            // result.LatestProducts = db.Products.OrderByDescending(x => x.CreatedAt).Take(4).ToList();
            return View(result);
           
        }
        public IActionResult GetAllProducts()
        { // Api link = https://localhost:7245/admin/GetAllProducts
            // API method that send all products as api to the same project and returning ok 
            return Ok(db.Products.Select(x => new { x.Name, x.Price, x.Quan }).ToList());

        }
        [Authorize(Roles = "Admin")]
        public IActionResult ApiTut()
        {
            return View();
        }
        public IActionResult ApiGetProducts()
        {// Api link = https://localhost:7245/admin/ApiGetProducts
            //this Api method user to get all product data and  should be called by jquery
            return Ok(db.Products.Select(x => new { x.Id, x.Name, x.Price, x.Quan }).ToList());
        }
    }
}

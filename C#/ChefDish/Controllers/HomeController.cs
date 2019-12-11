using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChefDish.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ChefDish.Controllers
{
    public class HomeController : Controller
    {
       private MyContext dbContext;
     
        // here we can "inject" our context service into the constructor
        public HomeController(MyContext context)
        {
            dbContext = context;
        }
     
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("dishes")]
        public IActionResult Next()
        {
            return View();
        }
        [HttpGet("new")]
        public IActionResult New()
        {
            return View();
        }
        [HttpGet("dishes/new")]
        public IActionResult newDish()
        {
            return View();
        }
        [HttpPost("addDish")]
        public IActionResult addDish(Dish dish)
        {
             if(ModelState.IsValid)
            {
                dbContext.Add(dish);
                dbContext.SaveChanges();
                return Redirect("/dishes");
            }
        
        return Redirect("/dishes/new");
            
        }
        [HttpPost("addChef")]
        public IActionResult addChef(Chef chef)
        {
             if(ModelState.IsValid)
            {
                dbContext.Add(chef);
                dbContext.SaveChanges();
                return View("Index");
            }
           
            
        return Redirect("/");  
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

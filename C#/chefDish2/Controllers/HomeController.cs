using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using chefDish2.Models;
using Microsoft.EntityFrameworkCore;

namespace chefDish2.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
     
        // here we can "inject" our context service into the constructor
        public HomeController(MyContext context)
        {
            dbContext = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            List<Chef> AllChefs = dbContext.Chefs.Include(i => i.Dishes).ToList();
            ViewBag.AllChefs = AllChefs;
            return View();
        }
        [HttpGet("dishes")]
        public IActionResult Next()
        {
            List<Dish> AllDishes = dbContext.Dishes.Include(i => i.Creator).ToList();
            
            ViewBag.AllDishes = AllDishes;
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
            List<Chef> AllChefs = dbContext.Chefs.ToList();
            ViewBag.AllChefs = AllChefs;
            return View();
        }
        [HttpPost("addDish")]
        public IActionResult addDish(Dish dish)
        {
           
             if(ModelState.IsValid)
            {
                if(dbContext.Dishes.Any(i => i.Calories < 0))
                {
                    ModelState.AddModelError("Calories", "Calories must be greater than 0");
                    return View("newDish");
                }
                
                
                    
                dbContext.Add(dish);
                dbContext.SaveChanges();
                
                 return Redirect("/dishes");
            }
            else 
            {
                List<Chef> AllChefs = dbContext.Chefs.ToList();
                ViewBag.AllChefs = AllChefs;
                return View("newDish");
            }
        
        
            
        }
        [HttpPost("addChef")]
        public IActionResult addChef(Chef chef)
        {
             if(ModelState.IsValid)
            {
                if(dbContext.Chefs.Any(i => i.Age > DateTime.Now))
                {
                ModelState.AddModelError("Age", "Birthday must be in the Past!");
               
                return View("New");
                
                }
                
                
                
                    dbContext.Add(chef);
                    dbContext.SaveChanges();
                return Redirect("/");  
            }
            else 
            {
                return View("New"); 
                 
            }
           
            
        
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    
    }
}

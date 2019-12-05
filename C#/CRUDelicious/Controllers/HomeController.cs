using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
        public HomeController(MyContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
            ViewBag.Dishes = dbContext.Dishes.ToList();
            
            
            return View();
        }

        [HttpGet("new")]
        public IActionResult Dish()
        {
            return View();
        }

         [HttpPost("Add")]
        public IActionResult Add(Dish dish)
        {
            if(ModelState.IsValid)
            {
                dbContext.Add(dish);
                dbContext.SaveChanges();
                return Redirect("/");
            }
            else
            {
                return View("Dish");
            }
            
        }
        [HttpGet("{DishId}")]
        public IActionResult showDish(int DishId)
        {
            ViewBag.Dish = dbContext.Dishes.FirstOrDefault(x => x.DishId == DishId);
            return View();
        }
         [HttpGet("edit/{DishId}")]
        public IActionResult editDish(int DishId)
        {
            ViewBag.Dish = dbContext.Dishes.FirstOrDefault(x => x.DishId == DishId);
            return View();
        }
          [HttpPost("update/{DishId}")]
        public IActionResult updateDish(int DishId, Dish dish)
        {
              if(ModelState.IsValid)
            {
                dbContext.Update(dish);
                dbContext.SaveChanges();
                return RedirectToAction("showDish", new{DishId});
            }
            else
            {
                return View("Dish");
            }
            
        }


       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

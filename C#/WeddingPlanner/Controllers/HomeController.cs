using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers
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
             int? session = HttpContext.Session.GetInt32("loggedinUser");
            
            if (session != null)
            {
                
                return RedirectToAction("Dashboard");
            }
            return View();
        }
        [HttpPost("register")]
        public IActionResult Register(User user)
        {
             if(ModelState.IsValid)
            {
                
                // If a User exists with provided email
                if(dbContext.Users.Any(u => u.Email == user.Email))
                {
                // Manually add a ModelState error to the Email field, with provided
                // error message
                 ModelState.AddModelError("Email", "Email already in use!");
            
                 // You may consider returning to the View at this point
                 return View("Index");
                }
        
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                user.Password = Hasher.HashPassword(user, user.Password);
                dbContext.Add(user);
                dbContext.SaveChanges();
                HttpContext.Session.SetInt32("loggedinUser", user.UserId);
                return Redirect("/dashboard");
                
                
            }
            
            else 
            {
                return View("Index");
            }
        }
        [HttpPost("login")]
        public IActionResult Login(LoginUser userSubmission)
        {
            if(ModelState.IsValid)
            {
                // If inital ModelState is valid, query for a user with provided email
                var userInDb = dbContext.Users.FirstOrDefault(u => u.Email == userSubmission.Email);
                

                
                // If no user exists with provided email
                if(userInDb == null)
                {
                    // Add an error to ModelState and return to View!
                    ModelState.AddModelError("Email", "Invalid Email/Password");
                    return View("Log");
                }
                
                // Initialize hasher object
                var hasher = new PasswordHasher<LoginUser>();
                
                // verify provided password against hash stored in db
                var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.Password);
                
                // result can be compared to 0 for failure
                if(result == 0)
                {
                    // handle failure (this should be similar to how "existing email" is handled)
                    ModelState.AddModelError("Password", "Incorrect Password");
                    return View("Log");
                }
            
                HttpContext.Session.SetInt32("loggedinUser", userInDb.UserId);
                return Redirect("/dashboard");
                
            }
            return View("Log");
        }
        [HttpGet("/dashboard")]
        public IActionResult Dashboard(int UserId)
        {
            int? session = HttpContext.Session.GetInt32("loggedinUser");
             if (session == null)
            {
                HttpContext.Session.Clear();
                return View("Index");
            }
            ViewBag.CurrentUser = dbContext.Users.FirstOrDefault (i => i.UserId == (int)session);
            ViewBag.AllWeddings = dbContext.Weddings.Include(i => i.Creator).Include(i => i.Guests);
        
            return View("Dashboard");
        }

        [HttpGet("/plan/{UserId}")]
        public IActionResult newPlan(int UserId)
        {
            int? session = HttpContext.Session.GetInt32("loggedinUser");  
             
            
            if (session == null)
            {
                HttpContext.Session.Clear();
                return View("Index");
            } 

            return View("newPlan"); 
        }
        [HttpPost("/plan")]
        public IActionResult Plan(Wedding wedding)
        {
            int? session = HttpContext.Session.GetInt32("loggedinUser");
             if(ModelState.IsValid)
            {
                if(wedding.Date < DateTime.Now)
                {
                    ModelState.AddModelError("Date", "Date must be in the Future!");
               
                    return View("newPlan");
                
                }                
                    wedding.UserId = (int)session;
                    dbContext.Add(wedding);
                    dbContext.SaveChanges();
                   
                return Redirect($"wedding/{wedding.WeddingId}");
            }
            else
                {
                    return View("newPlan");
                }
            
            }
    
        [HttpGet("/wedding/{WeddingId}")]
        public IActionResult Wedding(int WeddingId)
        {
            int? session = HttpContext.Session.GetInt32("loggedinUser");
            
            if (session == null)
            {
                HttpContext.Session.Clear();
                return View("Index");
            }
            ViewBag.AllGuests = dbContext.GuestLists.Include(i => i.Guest).Where(i => i.WeddingId == WeddingId);
            ViewBag.PlannedWeddings = dbContext.Weddings.FirstOrDefault(i => i.WeddingId == WeddingId);
            return View("Wedding");
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/dashboard");
        }

        [HttpGet("delete/{WeddingId}")]
        public IActionResult Delete(int WeddingId)
        {   
           
           Wedding weddingToDelete = dbContext.Weddings.SingleOrDefault(i => i.WeddingId == WeddingId);
            
            dbContext.Remove(weddingToDelete);
            dbContext.SaveChanges();
            return Redirect("/dashboard");
        }

        [HttpGet("rsvp/{WeddingId}")]
        public IActionResult RSVP(int WeddingId)
        {   
            int? session = HttpContext.Session.GetInt32("loggedinUser");
            GuestList guest = new GuestList();
            guest.UserId = (int)session;
            guest.WeddingId = WeddingId;

            dbContext.Add(guest);
            dbContext.SaveChanges();


            return Redirect("/dashboard");
        }

        [HttpGet("unrsvp/{WeddingId}")]
        public IActionResult UNRSVP(int WeddingId)
        {   
            int? session = HttpContext.Session.GetInt32("loggedinUser");
            GuestList guestToRemove = dbContext.GuestLists.Where(i => i.WeddingId == WeddingId).FirstOrDefault(i => i.UserId == (int)session);
            
           
            dbContext.Remove(guestToRemove);
            dbContext.SaveChanges();


            return Redirect("/dashboard");
        }

    }
}

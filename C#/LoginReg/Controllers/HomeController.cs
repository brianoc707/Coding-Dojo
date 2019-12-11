using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoginReg.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace LoginReg.Controllers
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
                else
                {
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                user.Password = Hasher.HashPassword(user, user.Password);
                dbContext.Add(user);
                dbContext.SaveChanges();
                return Redirect("/log");
                }
                
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
                else
                {
                    return View("Success", userInDb);
                }
            }
            return View("Success");
        }
        [HttpGet("log")]
        public IActionResult Log()
        {
            return View();
        }
        [HttpGet("/success")]
        public IActionResult Success(LoginUser userSubmission)
        {
            var userInDb = dbContext.Users.FirstOrDefault(u => u.Email == userSubmission.Email);
            ViewBag.LoggedIn = dbContext.Users.FirstOrDefault();
            return View();
        }
        
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}

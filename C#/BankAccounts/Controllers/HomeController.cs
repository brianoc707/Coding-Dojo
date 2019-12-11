using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankAccounts.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace BankAccounts.Controllers
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
        [HttpGet("log")]
        public IActionResult Log()
        {
            return View("Log");
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
                return Redirect($"account/{user.UserId}");
                
                
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
                return Redirect($"account/{userInDb.UserId}");
                
            }
            return View("Log");
        }

        [HttpGet("account/{UserId}")]
        public IActionResult Account(int UserId)
        {
            int? session = HttpContext.Session.GetInt32("loggedinUser");
            ViewBag.LoggedIn = dbContext.Users.FirstOrDefault(i => i.UserId == (int)session);
            ViewBag.Trans = dbContext.Transactions.OrderByDescending(i => i.CreatedAt).ToList();
            List<Transaction> AllTrans = dbContext.Transactions.Where(i => i.UserId == (int)session).ToList();
            
            decimal Balance = 0;
            foreach(var i in AllTrans)
            {
                Balance += i.Amount;
            }

            ViewBag.Balance = Balance;


            

            return View();
        }
        [HttpPost("deposit")]
        public IActionResult Deposit(Transaction trans)
        {
            int? session = HttpContext.Session.GetInt32("loggedinUser");
            if(ModelState.IsValid)
                {
                List<Transaction> AllTrans = dbContext.Transactions.Where(i => i.UserId == (int)session).ToList();
                decimal Balance = 0;
                foreach(var i in AllTrans)
                {
                    Balance += i.Amount;
                }
                Console.WriteLine($"***********I got the total: {Balance}");
                decimal total = Balance + trans.Amount;
                if(trans.Amount < 0)
                {
                    if(total <= 0)
                    {
                        Console.WriteLine("You overdrew!*****************************");
                        ModelState.AddModelError("Amount", "You dont have enough money!");
                        return Redirect("Account/{(int)session}");
                    }
                }
                
                trans.UserId = (int)session;
                Console.WriteLine($"***************{trans.Amount} ************ {total}");
                dbContext.Add(trans);
                dbContext.SaveChanges();
                

                return Redirect($"account/{(int)session}");
            }
            return Redirect("Account/{(int)session}");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

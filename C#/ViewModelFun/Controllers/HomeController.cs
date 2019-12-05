using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using ViewModelFun.Models;
namespace ViewModelFun

{
    public class HomeController : Controller
    {
        [HttpGet("")]
        
        public ViewResult Home()
        {
            Message someMessage = new Message()
            {
                message = "HELLOOOOOOOOO"
            };
            
            
            return View(someMessage);
        }
        
        [HttpGet("numbers")]
        public ViewResult Numbers()
        {
           Numbers someNumbers = new Numbers()
           {
               number = new int[] {1,2,3,10,43,5}
           };
           
            return View(someNumbers);
        }
         [HttpGet("users")]
        public ViewResult Users()
        {
            Users someUsers = new Users()
            {
                FirstName = "Brian",
                LastName ="O'Connor"
            };

            Users newUsers = new Users()
            {
                FirstName = "Brian2",
                LastName ="O'Connor2"
            };
             Users newerUsers = new Users()
            {
                FirstName = "Brian3",
                LastName ="O'Connor3"
            };
            List<Users> viewModel = new List<Users>()
            {
                someUsers, newerUsers, newUsers,
            };
           
            return View(viewModel);
        }
       
        [HttpGet("user")]
        public ViewResult user()
        {
               User user = new User()
            {
                FirstName = "Brian4",
                LastName ="O'Connor4"
            };
           
            return View(user);
        }
       
       
    }
}
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using DojoSurvey.Models;
namespace DojoSurvey
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        
        public ViewResult Home()
        {
            
            
            return View();
        }

        [HttpPost("Add")]
        public IActionResult Add(Survey survey)
        {
            if(ModelState.IsValid)
            {
                return Redirect("Result");
            }
            else
            {
                return View("Home");
            }
            
        }
        
        [HttpPost("result")]
        public ViewResult Result(string Name, string Location, string Language, string Comment)
        {
            Survey newSurvey = new Survey()
            {
                Name = Name,
                Location = Location,
                Language = Language,
                Comment = Comment,

            };
             
            return View(newSurvey);
        }
       
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DojoSurvey1.Models;

namespace DojoSurvey1.Controllers
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
                return RedirectToAction("Result", survey);
            }
            else
            {
                return View("Home");
            }
            
        }
       
    }
}

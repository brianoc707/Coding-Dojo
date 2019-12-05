using Microsoft.AspNetCore.Mvc;
using System;
namespace Portfolio
{
    public class IndexController : Controller
    {
        [HttpGet("")]
        public ViewResult Index()
        {
            
            return View();
        }
        
        [HttpGet("projects")]
        public ViewResult Project()
        {
            DateTime CurrentTime = DateTime.Now;
            ViewBag.Time = CurrentTime;
            
            return View();
        }
        [HttpGet("contact")]
        public ViewResult Contact()
        {
            return View();
        }
    }
}
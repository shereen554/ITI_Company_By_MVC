using Microsoft.AspNetCore.Mvc;

namespace Project_ITI.Controllers
{
    public class StatusController : Controller
    {
        public IActionResult setSession()
        {
            HttpContext.Session.SetString("Name", "Sheree");
            HttpContext.Session.SetInt32("Age", 22);
            return Content("Session Saved");
        }

        public IActionResult getSession()
        { 
            string name = HttpContext.Session.GetString("Name");
            int? age = HttpContext.Session.GetInt32("Age");
            return Content($"Name = {name} , Age ={age}");
        }
    }
}

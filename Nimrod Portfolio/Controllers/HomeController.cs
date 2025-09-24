using DAASWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Nimrod_Portfolio.Models;

namespace Nimrod_Portfolio.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IEmailService _EmailService;

        //public HomeController(IEmailService emailService)
        //{
        //    _EmailService = emailService;
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Resume()
        {
            return View();
        }

        public IActionResult Skills()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(Mail model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //_EmailService.SendEmail(model);

            TempData["ShowSuccess"] = true;
            return RedirectToAction("Contact");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}

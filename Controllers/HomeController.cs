using AspNetCore.ReCaptcha;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Web3_Assignment3_ContactUs.Data;
using Web3_Assignment3_ContactUs.Models;

namespace Web3_Assignment3_ContactUs.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, IEmailSender email, ApplicationDbContext dbContext)
        {
            _emailSender = email;
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet("contact")]
        public IActionResult Contact()
        {
            ViewBag.Title = "Contact Us";
            return View();
        }
        [ValidateReCaptcha]
        [HttpPost("contact")]
        public async Task<IActionResult> ContactAsync(ContactModel contact)
        {
            if (ModelState.IsValid)
            {
                await _emailSender.SendEmailAsync(contact.Email, contact.Topic, contact.Message);
                _dbContext.contacts.Add(contact);
                _dbContext.SaveChanges();
                return View("Success", contact);
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Resume.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Resume.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            TimeSpan morning = new TimeSpan(06, 00, 00);
            TimeSpan afternoon = new TimeSpan(12, 00, 00);
            TimeSpan evening = new TimeSpan(18, 00, 00);
            TimeSpan night = new TimeSpan(23, 59, 59);


            if (DateTime.Now.TimeOfDay >= morning && DateTime.Now.TimeOfDay < afternoon)
            {
                ViewBag.WelcomeMessage = "Good morning ";
            }
            else if (DateTime.Now.TimeOfDay >= afternoon && DateTime.Now.TimeOfDay < evening)
            {
                ViewBag.WelcomeMessage = "Good afternoon ";
            }
            else if (DateTime.Now.TimeOfDay >= evening && DateTime.Now.TimeOfDay < night)
            {
                ViewBag.WelcomeMessage = "Good evening ";
            }
            else
            {
                ViewBag.WelcomeMessage = "Whoaa, you're up late!";
            }
            
            return View();

        }

        public IActionResult WhoAmI()
        {
            return View();
        }
        public IActionResult WhatIBeenUpTo()
        {
            return View();
        }
        public IActionResult StuffIMade()
        {
            return View();
        }
        public IActionResult CV()
        {
            return View();
        }
        public IActionResult MyEducation()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Message(string name, string email, string message)
        {
            SmtpClient Client = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                    UserName = "christopherberglund87@gmail.com",
                    Password = "qexqbanudpauccha"
                }
            };

            MailAddress FromEmail = new MailAddress("christopherberglund87@gmail.com", "MyCvPage");
            MailAddress ToEmail = new MailAddress("christopherberglund87@gmail.com");
            MailMessage Message = new MailMessage()
            {
                From = FromEmail,
                Subject = "Incoming Mail!",
                Body = $"Namn: {name} \nEmail: {email} \nMessage: {message}"
            };

            Message.To.Add(ToEmail);
            Client.Send(Message);

            ViewBag.YourName = name;

            return View();
        }







        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}

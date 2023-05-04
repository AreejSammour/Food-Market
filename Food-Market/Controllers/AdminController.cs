using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Market.Models.SupportModels;
using Microsoft.AspNetCore.Mvc;

namespace Food_Market.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationContext Context;

        public AdminController(ApplicationContext context)
        {
            Context = context;
        }

        //[AllowAnonymous]
        // get ADMIN INDEX view
        public IActionResult Index()
        {
            return View();
        }

        //[AllowAnonymous]
        // get LOGIN 
        public IActionResult LogIn()
        {
            return View();
        }

        //[AllowAnonymous]
        // verify the admin
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Validate the user's credentials
            if (username == "Admin" && password == "Password123")
            {
                // Authentication succeeded, redirect to the tickets page
                return RedirectToAction("Tickets");
            }
            else
            {
                // Authentication failed, display an error message
                ViewBag.ErrorMessage = "Invalid username or password";
                return View("Index");
            }
        }

        //[Authorize(Roles = "Admin")]
        // get TICKETS view - EJ GJORT DENNA VIEW ÄN
        public IActionResult Tickets(int ticketId)
        {
            Ticket ticket = Context.Tickets.FirstOrDefault(x => x.TicketId == ticketId);
            return View(ticket);

        }

        //[Authorize(Roles = "Admin")]
        // get EDIT view - EJ GJORT DENNA VIEW ÄN
        public IActionResult Edit()
        {
            return View();
        }
    }
}


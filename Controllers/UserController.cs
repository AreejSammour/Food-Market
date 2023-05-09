using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using Food_Market.Models.SupportModels;
using Microsoft.AspNetCore.Mvc;

namespace Food_Market.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationContext Context;

        // context-object
        public UserController(ApplicationContext context)
        {
            Context = context;
        }

        // get INDEX view
        public IActionResult Index()
        {
            return View();
        }

        // method to receice/save variables from user-form
        [HttpPost]
        public IActionResult Create(string Name, string Password, string Email, string Subject, string Message)
        {
            // check if the email already exists in database, both email and password has to match
            User ExistingEmail = Context.Users.SingleOrDefault(u => u.Email == Email && u.Password == Password);

            // if the user/email already exist, add new ticket
            if (ExistingEmail != null)
            {
                // create new ticket referering to the UserId
                Ticket NewTicket = new Ticket { Subject = Subject, Message = Message, UserId = ExistingEmail.UserId };
                Context.Tickets.Add(NewTicket);
            }
            // if email does not exist, create new user and new ticket
            else
            {
                // create object for new user
                User NewUser = new User();
                NewUser.Name = Name;
                NewUser.Password = Password;
                NewUser.Email = Email;

                // save the new user in database
                Context.Users.Add(NewUser);
                Context.SaveChanges();

                // create object for Ticket
                Ticket NewTicket = new Ticket();
                NewTicket.Subject = Subject;
                NewTicket.Message = Message;

                // set the UserId from User to UserId in Tickets
                NewTicket.UserId = NewUser.UserId;

                // add the ticket to database
                Context.Tickets.Add(NewTicket);
            }

            // save changes
            Context.SaveChanges();

            // after user press send, they will be redirected to a confirmation-page
            return RedirectToAction(nameof(Confirmation));
        }

        // get MESSAGESUBMITTED view
        public IActionResult Confirmation()
        {
            return View();
        }


        public IActionResult Details()
        {
            List<Ticket> MyTickets = Context.Tickets.ToList();
            return View(MyTickets);
        }

        // get FAQ view
        public IActionResult FAQ()
        {
            return View();
        }
    }
}


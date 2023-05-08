using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Market.Models;
using Microsoft.AspNetCore.Mvc;

namespace Food_Market.Controllers
{
	public class TicketController : Controller
	{
        private readonly ApplicationContext Context;

        // context-object
        public TicketController(ApplicationContext context)
        {
            Context = context;
        }

        // index view - contact us form
        public IActionResult Index()
        {
            return View();
        }

        // method for userid 1 to make new ticket
        [HttpPost]
        public IActionResult Create(string Account, string Subject, string Message)
        {
            // not necessary in this validation, they have another validation
            ModelState.Remove("Account");
            ModelState.Remove("Subject");

            if (string.IsNullOrEmpty(Message))
            {
                ModelState.AddModelError("Message", "The Message field is required.");
            }
     
            if (!ModelState.IsValid)
            {
                // If the validation fails, return the view with the validation errors
                return View(nameof(Index));
            }
            // create new ticket for userid 1 - lionel messi is already logged in to the site
            Ticket NewTicket = new Ticket();
            NewTicket.Account = 1;
            NewTicket.Subject = Subject;
            NewTicket.Message = Message;

            // add the ticket to database
            Context.Tickets.Add(NewTicket);

            // save changes
            Context.SaveChanges();

            // after user press send, they will be redirected to a confirmation-page
            return RedirectToAction(nameof(Confirmation));
        }

        // confirmaion view - for user
        public IActionResult Confirmation()
        {
            return View();
        }

        // my tickets - for user
        public IActionResult MyTickets()
        {
            List<Ticket> MyTickets = Context.Tickets.ToList();
            return View(MyTickets);
        }

        // FAQ view
        public IActionResult FAQ()
        {
            return View();
        }

        // List of all ticket - for admin
        public IActionResult AllTickets()
        {
            List<Ticket> MyTickets = Context.Tickets.ToList();
            return View(MyTickets);
        }

        // edit - for admin
        public IActionResult Edit(int TicketId)
        {
            Ticket Ticket = Context.Tickets.FirstOrDefault(x => x.TicketId == TicketId);
            return View(Ticket);
        }

        [HttpPost]
        public IActionResult Edit(int TicketId, string Response)
        {
            Ticket Ticket = Context.Tickets.FirstOrDefault(x => x.TicketId == TicketId);

            // only reponse i editable
            Ticket.Response = Response;

            Context.Tickets.Update(Ticket);
            Context.SaveChanges();
            return RedirectToAction(nameof(AllTickets));
        }

        // delete method - for admin
        public IActionResult Delete(int id)
        {
            // Retrieve the ticket from the database based on the provided id
            var ticket = Context.Tickets.FirstOrDefault(x => x.TicketId == id);

            if (ticket == null)
            {
                return NotFound();
            }
            // Remove the ticket from the database
            Context.Tickets.Remove(ticket);
            Context.SaveChanges();

            return RedirectToAction(nameof(DeleteConfirmation));
        }

        // deleted confirmation - for admin
        public IActionResult DeleteConfirmation()
        {
            return View();
        }

    }
}


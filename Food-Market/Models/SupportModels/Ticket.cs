using System;
using System.ComponentModel.DataAnnotations;

namespace Food_Market.Models.SupportModels
{
	public class Ticket
	{
        public int TicketId { get; set; }

        [Required(ErrorMessage = "Subject is required")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Please enter your message.")]
        public string Message { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        // AdminId foreign key is nullable because a ticket may not necessarily be assigned to an admin
        public int? AdminId { get; set; }
        public Admin Admin { get; set; }
    }
}

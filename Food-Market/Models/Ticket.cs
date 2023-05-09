using System;
using System.ComponentModel.DataAnnotations;

// made by Amanda

namespace Food_Market.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public int Account { get; set; }

        // response - from Admin
        // nullable
        public string? Response { get; set; }
    }
}

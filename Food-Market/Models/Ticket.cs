using System;
using System.ComponentModel.DataAnnotations;

namespace Food_Market.Models
{
    public class Ticket
    {
        // dotnet ef database update
        // dotnet ef migrations add InitialCreate
        // dotnet ef migrations remove
        // dotnet ef database update -c ApplicationContext

        public int TicketId { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public int Account { get; set; }

        // response - from Admin
        // nullable
        public string? Response { get; set; }
    }
}

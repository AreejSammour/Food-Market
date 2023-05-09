using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace Food_Market.Models.SupportModels
{
	public class User
	{
        // commands for mac-migrations
        // (1. dotnet ef database update)
        // 2. dotnet ef migrations add InitialCreate
        // 3. dotnet ef migrations remove
        // 4. dotnet ef migrations add AddingUsersTable
        // 5. dotnet ef migrations add AddingAdminsTable
        // 6. dotnet ef migrations add AddingTicketsTable
        // 7. dotnet ef database update
        // dotnet ef database update -c ApplicationContext

        // id with Entity Framework
        public int UserId { get; set; }

        //Forms with NAME, PASSWORD AND ERROR-MESSAGE
        [Required(ErrorMessage = "Please enter your name.")]
        public string Name { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]

        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        // one user can make many tickets
        public ICollection<Ticket> Tickets { get; set; }

    }
}



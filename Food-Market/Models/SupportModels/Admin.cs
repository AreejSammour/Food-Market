using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace Food_Market.Models.SupportModels
{
	public class Admin
	{
        public int AdminId { get; set; }

        [Required(ErrorMessage = "Please enter your username.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter your password.")]
        public string Password { get; set; }

        public ICollection<Ticket> Tickets { get; set; }

    }
}



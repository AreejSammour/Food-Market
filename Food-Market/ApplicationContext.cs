using System;
using System.Reflection.Emit;
using Food_Market.Models;
using Food_Market.Models.ShoppingCart;
using Food_Market.Models.ProductModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Food_Market.Models.OrderModels;

namespace Food_Market
{
	public class ApplicationContext : DbContext
	{
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> ShoppingCarts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Checkout> Checkout { get; set; }


        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetail> ordersDetail { get; set; }


        //Constructor
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        // data seed for TICKETS - Amanda
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

             modelBuilder.Entity<Ticket>().HasData(
                new Ticket
                {
                    TicketId = 1,
                    Subject = "Tomatoes were crushed",
                    Message = "My tomatoes were crushed when i receieved them. I want my money back.",
                    Response = "Dear Lionel Messi,\n\nThank you for bringing this issue to our attention. We apologize for any inconvenience caused by the crushed tomatoes you received." +
                    "\n\nWe have reviewed your order and have issued a full refund to your account. The refund may take up to 3 days to process." +
                    "\n\nIf there is anything else we can do to assist you, please do not hesitate to let us know." +
                    "\n\nThank you for your understanding.\n\nBest regards,\n Food Market",
                    Account = 1 // lionel messi
                },
                new Ticket
                {
                    TicketId = 2,
                    Subject = "Rotten banana",
                    Message = "I receieved some rotten bananas in my latest order. I want new ones and a compensation cuz I was not able to make my smoothie this morning :@",
                    Response = "Dear Lionel Messi,\n\nThank you for bringing this issue to our attention. We apologize for any inconvenience. We have reviewed your order and " +
                    "have arranged for a new shipment of bananas to be sent to you as soon as possible. " +
                    "Additionally, we have made a transfer of 10 dollars to your bank account to compensate you for the inconvenience. " +
                    "We understand how important it is to receive fresh, high-quality produce, and we are committed to providing our customers with the best possible service. " +
                    "Please let us know if there is anything else we can do to assist you.\n\nThank you for your understanding.\n\nBest regards,\nFood Market",
                    Account = 1 // lionel messi
                },
                new Ticket
                {
                    TicketId = 3,
                    Subject = "I lost my package",
                    Message = "I cant find my shipment id and i cant remember if i have already received my order.",
                    Response = null,
                    Account = 1 // lionel messi
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}


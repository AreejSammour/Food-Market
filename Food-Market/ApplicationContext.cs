using System;
using Food_Market.Models;
using Food_Market.Models.ShoppingCart;
using Microsoft.EntityFrameworkCore;

namespace Food_Market
{
	public class ApplicationContext : DbContext
	{
        

        //Constructor
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        //public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        //public DbSet<User> Users { get; set; }
        //public DbSet<Admin> Admins { get; set; }
        //public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}


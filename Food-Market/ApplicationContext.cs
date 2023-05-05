using System;
using Food_Market.Models;
using Food_Market.Models.ShoppingCart;
using Food_Market.Models.SupportModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Food_Market
{
	public class ApplicationContext : DbContext
	{
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> ShoppingCarts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categories { get; set; }

        //Constructor
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

		//Här är ett exempel på hur man lägger till rådata
		//När vi add-migration och updata-database visas det i tabellerna

		//protected override void OnModelCreating(ModelBuilder modelBuilder)
		//{
		//	Skill Skill1 = new Skill() { Id = 1,Name = "C-Sharp",Description = "C#",ImageURL = "/images/C-Sharp.png"};
		//	Skill Skill2 = new Skill() { Id = 2, Name = "SQL", Description = "DataBase", ImageURL = "/images/SQL.png" };

		//	modelBuilder.Entity<Skill>().HasData(Skill1, Skill2);
		//}
	}


}


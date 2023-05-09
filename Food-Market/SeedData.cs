using Food_Market.Models.ProductModels;
using Microsoft.EntityFrameworkCore;

namespace Food_Market
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationContext>>()))
            {
                //Look for any movie

                if (context.Products.Any())
                {
                    return;
                }

                context.Products.AddRange(
                    new Product
                    {
                        ProductName = "Organic Apples",
                        Categories = new List<Category>
                        {
                               new Category { CategoryName = "Produce" },
                               new Category { CategoryName = "Organic" }
                        },
                        Price = 35.99M,
                        Description = "Organic apples grown locally",
                        Tags = new List<Tag>
                        {
                            new Tag {TagName = "Fruit"},
                            new Tag {TagName = "Healthy"},
                            new Tag {TagName = "Local"}
                        },
                        ImageUrl = "https://picsum.photos/id/1/200/200"
                    },
                    new Product
                    {
                        ProductName = "Whole Grain Bread",
                        Categories = new List<Category>
                        {
                               new Category { CategoryName = "Bakery" },
                               new Category { CategoryName = "Whole grain" }
                        },
                        Price = 40.99M,
                        Description = "Freshly baked whole grain bread",
                        Tags = new List<Tag>
                        {
                            new Tag {TagName = "Bread"},
                            new Tag {TagName = "Healthy"},
                            new Tag {TagName = "Local"}
                        },
                        ImageUrl = "https://picsum.photos/id/1/200/200"
                    },
                    new Product
                    {
                        ProductName = "Organic Carrots",
                        Categories = new List<Category>
                        {
                               new Category { CategoryName = "Produce" },
                               new Category { CategoryName = "Organic" }
                        },
                        Price = 19.99M,
                        Description = "Organic carrots with no pesticides",
                        Tags = new List<Tag>
                        {
                            new Tag {TagName = "Vegetables"},
                            new Tag {TagName = "Healthy"},
                            new Tag {TagName = "Local"}
                        },
                        ImageUrl = "https://picsum.photos/id/1/200/200"
                    },
                    new Product
                    {
                        ProductName = "Milk",
                        Categories = new List<Category>
                        {
                               new Category { CategoryName = "Dairy" }
                        },
                        Price = 15.49M,
                        Description = "Fresh milk from local farms",
                        Tags = new List<Tag>
                        {
                            new Tag {TagName = "Dairy"},
                            new Tag {TagName = "Local"}
                        },
                        ImageUrl = "https://picsum.photos/id/1/200/200"
                    },
                    new Product
                    {
                        ProductName = "Organic Bananas",
                        Categories = new List<Category>
                        {
                               new Category { CategoryName = "Produce" },
                               new Category { CategoryName = "Organic" }
                        },
                        Price = 20.69M,
                        Description = "Organic bananas from sustainable farms",
                        Tags = new List<Tag>
                        {
                            new Tag {TagName = "Fruit"},
                            new Tag {TagName = "Healthy"},
                            new Tag {TagName = "Sustainable"}
                        },
                        ImageUrl = "https://picsum.photos/id/1/200/200"
                    },
                    new Product
                    {
                        ProductName = "Eggs",
                        Categories = new List<Category>
                        {
                               new Category { CategoryName = "Dairy" },
                               new Category { CategoryName = "Organic" }
                        },
                        Price = 10.69M,
                        Description = "Free range eggs from local farms",
                        Tags = new List<Tag>
                        {
                            new Tag {TagName = "Eggs"},
                            new Tag {TagName = "Healthy"},
                            new Tag {TagName = "Sustainable"}
                        },
                        ImageUrl = "https://picsum.photos/id/1/200/200"
                    },
                    new Product
                    {
                        ProductName = "Wild-Caught Salmon",
                        Categories = new List<Category>
                        {
                               new Category { CategoryName = "Seafood" }
                        },
                        Price = 90.39M,
                        Description = "Freshly caught salmon from the Pacific Northwest",
                        Tags = new List<Tag>
                        {
                            new Tag {TagName = "Fish"},
                            new Tag {TagName = "Healthy"},
                            new Tag {TagName = "Sustainable"}
                        },
                        ImageUrl = "https://picsum.photos/id/1/200/200"
                    },
                    new Product
                    {
                        ProductName = "Avocado",
                        Categories = new List<Category>
                        {
                               new Category { CategoryName = "Produce" }
                        },
                        Price = 20.69M,
                        Description = "Ripe avocados from Mexico",
                        Tags = new List<Tag>
                        {
                            new Tag {TagName = "Fruit"},
                            new Tag {TagName = "Healthy"},
                            new Tag {TagName = "Exported"}
                        },
                        ImageUrl = "https://picsum.photos/id/1/200/200"
                    },
                    new Product
                    {
                        ProductName = "Organic Red Onions",
                        Categories = new List<Category>
                        {
                               new Category { CategoryName = "Produce" },
                               new Category { CategoryName = "Organic" }
                        },
                        Price = 10.29M,
                        Description = "Organic red onions with no pesticides",
                        Tags = new List<Tag>
                        {
                            new Tag {TagName = "Onions"},
                            new Tag {TagName = "Organic"},
                            new Tag {TagName = "Vegetables"}
                        },
                        ImageUrl = "https://picsum.photos/id/1/200/200"
                    },
                    new Product
                    {
                        ProductName = "Organic Chicken Breast",
                        Categories = new List<Category>
                        {
                               new Category { CategoryName = "Meat" },
                               new Category { CategoryName = "Organic" }
                        },
                        Price = 70.69M,
                        Description = "Organic chicken breast from local farms",
                        Tags = new List<Tag>
                        {
                            new Tag {TagName = "Chicken"},
                            new Tag {TagName = "Organic"},
                            new Tag {TagName = "Meat"}
                        },
                        ImageUrl = "https://picsum.photos/id/1/200/200"
                    },
                    new Product
                    {
                        ProductName = "Whole Wheat Pasta",
                        Categories = new List<Category>
                        {
                               new Category { CategoryName = "Pasta" },
                               new Category { CategoryName = "Grains" }
                        },
                        Price = 8.69M,
                        Description = "Whole wheat pasta made with organic grains",
                        Tags = new List<Tag>
                        {
                            new Tag {TagName = "Pasta"},
                            new Tag {TagName = "Healthy"},
                            new Tag {TagName = "Grains"}
                        },
                        ImageUrl = "https://picsum.photos/id/1/200/200"
                    },
                    new Product
                    {
                        ProductName = "Almond Milk",
                        Categories = new List<Category>
                        {
                               new Category { CategoryName = "Dairy" },
                               new Category { CategoryName = "Vegan" }
                        },
                        Price = 30.69M,
                        Description = "Fresh almond milk made with organic almonds",
                        Tags = new List<Tag>
                        {
                            new Tag {TagName = "Almond milk"},
                            new Tag {TagName = "Vegan"},
                            new Tag {TagName = "Dairy-free"}
                        },
                        ImageUrl = "https://picsum.photos/id/1/200/200"
                    },
                    new Product
                    {
                        ProductName = "Organic Quinoa",
                        Categories = new List<Category>
                        {
                               new Category { CategoryName = "Grains" },
                               new Category { CategoryName = "Organic" }
                        },
                        Price = 33.69M,
                        Description = "Organic quinoa from sustainable farms",
                        Tags = new List<Tag>
                        {
                            new Tag {TagName = "Quinoa"},
                            new Tag {TagName = "Organic"},
                            new Tag {TagName = "Grains"}
                        },
                        ImageUrl = "https://picsum.photos/id/1/200/200"
                    }


                    );
                context.SaveChanges();
            }

        }
    }
}

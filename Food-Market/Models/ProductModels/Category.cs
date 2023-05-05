using System;

namespace Food_Market.Models.ProductModels
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public List<Product> Products { get; set; }
    }
}

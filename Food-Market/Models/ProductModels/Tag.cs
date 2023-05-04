using System;

namespace Food_Market.Models.ProductModels
{
    public class Tag
    {
        public int Id { get; set; }
        public string TagName { get; set; }

        public List<Product> Products { get; set; }
    }
}

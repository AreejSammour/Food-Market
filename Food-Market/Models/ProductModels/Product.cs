using System;
using System.ComponentModel.DataAnnotations;

namespace Food_Market.Models.ProductModels
{
	public class Product
	{
        public int Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "The Product Name value must be between 1-20 characters")]
        public string ProductName { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "The Product Category value must be between 1-20 characters")]
        public string ProductCategory { get; set; }
        [Required]
        [StringLength(int.MaxValue, MinimumLength = 5, ErrorMessage = "The Product Description value must be at least 5 characters")]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string ImageUrl { get; set; }

        public string ProductTag { get; set; }

        public List<Category> Categories { get; set; }
        public List<Tag> Tags { get; set; }
    }
}


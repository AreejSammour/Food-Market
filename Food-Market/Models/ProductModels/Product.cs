﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Food_Market.Models.ProductModels
{
	public class Product
	{
        public int Id { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "The Product Name value must be between 1-200 characters")]
        public string? ProductName { get; set; }
        [StringLength(200, MinimumLength = 1, ErrorMessage = "The Product Category value must be between 1-200 characters")]
        public string? ProductCategory { get; set; }
        [Required]
        [StringLength(int.MaxValue, MinimumLength = 5, ErrorMessage = "The Product Description value must be at least 5 characters")]
        public string Description { get; set; }
        [Required]
		[Range(0.01, double.MaxValue)]
		[DataType(DataType.Currency)]
		[Column(TypeName = "decimal(18, 2)")]
		public decimal Price { get; set; }
        [Required]
        public string ImageUrl { get; set; }

        public string? ProductTag { get; set; }

        public List<Category>? Categories { get; set; }
        public List<Tag>? Tags { get; set; }
    }
}


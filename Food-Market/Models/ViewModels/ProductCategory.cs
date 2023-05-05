using System;
using Food_Market.Models.ProductModels;
using Microsoft.AspNetCore.Mvc.Rendering; // imported to render the items in SelectListItem property

namespace Food_Market.Models.ViewModels
{
	public class ProductCategory
	{
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        // The singel selected category
        public string SelectedCategory { get; set; }

        // The property which will display the entire select list
        public List<SelectListItem> CategoriesSelectList { get; set; }
    }
}


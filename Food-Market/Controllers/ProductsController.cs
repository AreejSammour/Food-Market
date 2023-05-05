using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Market.Models.ProductModels;
using Food_Market.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Food_Market.Controllers
{
    public class ProductsController : Controller
    {
        // GET: /<controller>/
        private readonly ApplicationContext Context;
        public ProductsController(ApplicationContext context)
        {
            Context = context;
        }
        public IActionResult Index()
        {
            List<Product> AllProducts = Context.Products.ToList();
            List<Category> AllCategories = Context.Categories.OrderBy(o => o.CategoryName).ToList(); // Sorted alphabetically

            ProductCategory vm = new ProductCategory();
            vm.Products = AllProducts;
            vm.Categories = AllCategories;
            vm.CategoriesSelectList = new List<SelectListItem>();

            foreach (var category in AllCategories)
            {
                vm.CategoriesSelectList.Add(new SelectListItem { Text = category.CategoryName, Value = category.Id.ToString() });
            }

            return View(vm);
        }

        [HttpPost]
        public IActionResult Index(ProductCategory vm)
        {
            var SelectedCategory = vm.SelectedCategory;
            return RedirectToAction("Index"); // Change to a view displaying according to choosen category
        }
    }
}


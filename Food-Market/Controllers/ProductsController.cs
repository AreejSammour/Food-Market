using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Market.Models.ProductModels;
using Food_Market.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


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

		public IActionResult Details(int id)
		{
			var product = Context.Products
				.Include(p => p.Categories)
				.Include(p => p.Tags)
				.FirstOrDefault(p => p.Id == id);

			if (product == null)
			{
				return NotFound();
			}

			return View(product);
		}
        /*
         When a user requests this page, they provide a "tagName" parameter in the URL or click on a
        tagname in the details section on the page. The method takes
        this parameter and uses it to retrieve a tag from the database that has the specified name. 
        If no such tag is found, it returns a "NotFound" response.

        If a tag is found, the method retrieves a list of 
        products associated with that tag, and sets a ViewBag properties for use in the viewfile. 
        EMMY
        */
        public IActionResult ProductsByTag(string tagName)
        {
            // Retrieve the tag based on the tag name
            var tag = Context.Tags
                .Include(t => t.Products)
                .SingleOrDefault(t => t.TagName == tagName);

            if (tag == null)
            {
                return NotFound();
            }

            // Retrieve the products associated with the tag
            var products = tag.Products.ToList();

            // Set the ViewBag properties for use in the view
            ViewBag.TagName = tag.TagName;


            return View(products);
        }
        /*
         The method takes an int parameter, 
        this parameter will contain the id of the category that the user wants to view products for.
        the method retrieve the category with the specified id from the database. 
        It uses the Categories property of the Context object to access the categories in the database, 
        and the Include method to eager load the products associated with the category. 
        If no category with the specified id is found, the method returns a 404 Not Found response.
        If the category is found, the method retrieves the products associated with the category.
        The method sets a ViewBag property named CategoryName to the name of the category, 
        so that the viewfile can display the name of the category.
        EMMY
        */
        public IActionResult ProductsByCategory(int categoryid)
        {
            // Retrieve the category with the specified id
            var category = Context.Categories
                .Include(c => c.Products)
                .SingleOrDefault(c => c.Id == categoryid);

            if (category == null)
            {
                return NotFound();
            }

            // Retrieve the products associated with the category
            var products = category.Products.ToList();

            // Set the ViewBag properties for use in the view
            ViewBag.CategoryName = category.CategoryName;

            return View(products);
        }

        
    }
}
    

﻿using Food_Market.Models.ShoppingCart;
using Food_Market.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Food_Market.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationContext Context;
        Cart cart = new Cart();
        public CartController(ApplicationContext context)
        {
            Context = context;
        }
        public async Task<IActionResult> Index()
        {

            var shoppingCartsItems = await Context.CartItems.ToListAsync();
            //var shoppingCarts = _context.ShoppingCarts.Include(sc => sc.Items).ToList();
            var currencyMode = HttpContext.Session.GetString("CurrencyMode") ?? "USD";
            foreach (var item in shoppingCartsItems)
            {
                cart.TotalPrice += item.Price * item.Quantity;
            }
            var itemsHash = new HashSet<CartItem>();
            foreach (var item in shoppingCartsItems)
            {
                itemsHash.Add(item);
            }
            var viewModel = new ItemsInCartViewModel
            {
                Items = itemsHash,
                TotalItemsCount = shoppingCartsItems.Count,
                TotalPrice = cart.TotalPrice,
                CurrencyMode = currencyMode
            };

            if (viewModel.CurrencyMode == "USD")
            {
                foreach (var item in viewModel.Items)
                {
                    item.Price = Math.Round(item.Price / 10, 2);
                    item.PriceTotal = Math.Round(item.PriceTotal / 10, 2);
                }
                viewModel.TotalPrice = Math.Round(viewModel.TotalPrice / 10, 2);
            }

            return View(viewModel);


        }

        [HttpPost]
        public IActionResult UpdateCurrencyMode(string currencyMode)
        {
            HttpContext.Session.SetString("CurrencyMode", currencyMode);

            return Ok();
        }
        public IActionResult GetCount()
        {
            HttpContext.Session.GetInt32("TotalItemsCount");
            return Ok();
        }

        public IActionResult AddToCart(int id, int quantity)
        {
            Product product = _context.Products.FirstOrDefault(p => p.Id == id);
            // var _cart = ShoppingCart.GetCart(HttpContext.Session, _context);

            if (product == null)
            {
                return NotFound();
            }

            //If item exist
            var existingItem = _context.CartItems.FirstOrDefault(x => x.Product.Id == product.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
                existingItem.PriceTotal = existingItem.Quantity * existingItem.Price;
                cart.TotalPrice += existingItem.Price;
                _context.ShoppingCarts.Update(cart);
            }
            //New Item
            else
            {
                var cartItem = new CartItem();
                cartItem.Name = product.Name;
                cartItem.Quantity = quantity;
                cartItem.Price = product.Price;
                cartItem.PriceTotal = cartItem.Price * cartItem.Quantity;
                cartItem.Product = product;
                cartItem.ShoppingCart = cart;
                cartItem.ProductId = product.Id;

                cart.Items.Add(cartItem);
                cart.TotalPrice += cartItem.PriceTotal;

                _context.ShoppingCarts.Update(cart);
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        /// <summary>
        /// This method allows the user to changes the quantity of items in shopping cart
        /// </summary>
        /// <param name="id"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public async Task<IActionResult> UpdateQuantity(int id, int quantity)
        {
            //Get item with the chosen id
            var item = Context.CartItems.FirstOrDefault(i => i.Id == id);
            //The difference between former quantity and new quantity
            int quantityDiff;
            //Get the product of the item
            var productId = Context.CartItems
                                 .Where(c => c.Id == id)
                                 .Select(c => c.Product.Id)
                                 .FirstOrDefault();

            var product = Context.Products
                .Where(p => p.Id == productId)
                .FirstOrDefault();

            int formerQuantity = item.Quantity;

            if (formerQuantity < quantity)
            {
                item.Quantity = quantity;
                quantityDiff = quantity - formerQuantity;
                product.StockQuantity -= quantityDiff;
                cart.TotalPrice += item.Quantity * item.Price;
                item.PriceTotal = item.Price * item.Quantity;
            }
            if (formerQuantity > quantity)
            {
                item.Quantity = quantity;
                quantityDiff = formerQuantity - quantity;
                product.StockQuantity += quantityDiff;
                cart.TotalPrice -= item.Price;
                if (quantity == 0)
                {
                    await Delete(item.Id);
                }
                item.PriceTotal = item.Price * item.Quantity;
            }

            Context.ShoppingCarts.Update(cart);
            Context.Products.Update(product);
            Context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: ShoppingCarts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var productId = Context.CartItems
                                 .Where(c => c.Id == id)
                                 .Select(c => c.Product.Id)
                                 .FirstOrDefault();

            var product = Context.Products
                .Where(p => p.Id == productId)
                .FirstOrDefault();
            if (Context.ShoppingCarts == null)
            {
                return Problem("Entity set 'FoodStoreContext.ShoppingCarts'  is null.");
            }


            var item = Context.CartItems.FirstOrDefault(x => x.Id == id);

            //Add item's quantity to product stock
            product.StockQuantity += item.Quantity;
            //Delete cart item
            Context.CartItems.Remove(item);

            cart.TotalPrice -= item.Price;


            Context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EmptyCart()
        {
            var shoppingCartItems = await Context.CartItems.ToListAsync();
            if (shoppingCartItems.Count > 0)
            {
                foreach (var item in shoppingCartItems)
                {
                    Delete(item.Id);
                }

                Context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

using Ecommerce_assignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Food_Market.Controllers
{
    public class CheckoutsController : Controller
    {
        private readonly ApplicationContext Context;

        public CheckoutsController(ApplicationContext context)
        {
            Context = context;
        }

        public IActionResult Index()
        {
            var currency = HttpContext.Session.GetString("CurrencyMode") ?? "SEK";
            var cartItems = Context.CartItems.ToList();
            decimal cost = 0;
            if (cartItems.Count > 0)
            {
                foreach (var cartItem in cartItems)
                {
                    cost += cartItem.Price * cartItem.Quantity;
                }
                CheckoutViewModel viewModel = new CheckoutViewModel
                {
                    CartItems = cartItems,
                    CartTotal = cost,
                    Currency = currency
                };
                if (viewModel.Currency == "USD")
                {
                    foreach (var item in viewModel.CartItems)
                    {
                        item.PriceTotal = Math.Round(item.PriceTotal / 10, 2);
                    }
                    viewModel.CartTotal = Math.Round(cost / 10, 2);
                }
                return View(viewModel);
            }
            else
            {
                return RedirectToAction("Index", "Cart");
            }
        }
        public async Task<IActionResult> SubmitOrder(CheckoutViewModel checkoutVM)
        {
            var cartItems = await Context.CartItems.ToListAsync();

            Checkout checkout = new Checkout
            {
                CartItems = cartItems,
                FirstName = checkoutVM.FirstName,
                LastName = checkoutVM.LastName,
                Email = checkoutVM.Email,
                PhoneNumber = checkoutVM.PhoneNumber,
                Address = checkoutVM.Address,
                City = checkoutVM.City,
                State = checkoutVM.State,
                ZipCode = checkoutVM.ZipCode,
            };

            Context.Add(checkout);

            await Context.SaveChangesAsync();
            return RedirectToAction(nameof(Confirmation), new { checkoutId = checkout.Id });

        }
        public IActionResult Confirmation(int checkoutId)
        {
            CartController cartController = new CartController(Context);
            var checkout = Context.Checkout
                          .Include(c => c.CartItems)
                          .FirstOrDefault(c => c.Id == checkoutId);

            if (checkout == null)
            {
                return NotFound();
            }
            return View(checkout);
        }
    }
}

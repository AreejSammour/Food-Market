
using Food_Market.Models;
using Food_Market.Models.OrderModels;
using Food_Market.Models.ProductModels;
using Food_Market.Models.ShoppingCart;
using Microsoft.AspNetCore.Mvc;

namespace Food_Market.Controllers
{
	public class OrderController : Controller
	{
		private readonly ApplicationContext Context;

		public OrderController(ApplicationContext _Context)
		{
			Context = _Context;
		}

		public IActionResult Index()
		{
			List<OrderViewModel> OrdersToShow = new List<OrderViewModel>();
			List<Order> MyOrders = Context.orders.ToList();
			foreach (Order order in MyOrders)
			{
				OrderViewModel Order1 = new OrderViewModel();
				List<OrderDetail> OrdersList = Context.ordersDetail.Where(x => x.OrderId == order.OrderId).ToList();
				foreach (var orderDetail in OrdersList)
				{
					Checkout OrderCheckout = Context.Checkout.FirstOrDefault(x => x.Id == orderDetail.CheckoutId);
					orderDetail.OrderStatus = "Delivered";
					Order1.Id = orderDetail.Id;
					Order1.status = orderDetail.OrderStatus;
					Order1.UserEmail = OrderCheckout.Email;
					Order1.Date = orderDetail.PlacedDate.ToString("MM/dd/yyyy hh:mm tt");

					List<Cart> CartList = Context.ShoppingCarts.ToList();
					Cart LastCart = CartList.Last();

					orderDetail.OrderTotal = LastCart.TotalPrice;
					Order1.Total = orderDetail.OrderTotal;

					List<CartItem> GetCartItems = Context.CartItems.Where(x => x.ShoppingCartId == 0).ToList();

					foreach (CartItem item in GetCartItems)
					{
						Product Prod = Context.Products.FirstOrDefault(x => x.Id == item.ProductId);
						item.Product = Prod;
					}

					OrderCheckout.CartItems = GetCartItems;
					orderDetail.Checkout = OrderCheckout;
				}
				OrdersToShow.Add(Order1);
			}

			return View(OrdersToShow);
		}

		public IActionResult Details(int id)
		{
			Checkout GetCheckout = Context.Checkout.FirstOrDefault( x => x.Id == id);

			OrderDetail OrderDetail = new OrderDetail();
			OrderDetail.CheckoutId = GetCheckout.Id;
			OrderDetail.OrderStatus = "In-Progress";
			
			GetCheckout.CartItems = new List<CartItem>();
			
			List<Cart> CartList = Context.ShoppingCarts.ToList();
			Cart LastCart = CartList.Last();
			OrderDetail.OrderTotal = LastCart.TotalPrice;

			List<CartItem> GetCartItems = Context.CartItems.Where(x => x.ShoppingCartId == 0).ToList();

			foreach (CartItem item in GetCartItems)
			{
				Product Prod = Context.Products.FirstOrDefault(x => x.Id == item.ProductId);
				item.Product = Prod;
			}

			GetCheckout.CartItems = GetCartItems;
			OrderDetail.Checkout = GetCheckout;

			Order GetOrder = new Order();
			
			Context.orders.Add(GetOrder);
			Context.SaveChanges();
			OrderDetail.OrderId = GetOrder.OrderId;
			Context.ordersDetail.Add(OrderDetail);
			Context.SaveChanges();

			return View(OrderDetail);
		}

		//public IActionResult Details2(int id)
		//{
		//	OrderDetail OrderToShow = Context.ordersDetail.FirstOrDefault(x => x.Id == id);

		//	Checkout GetCheckout = Context.Checkout.FirstOrDefault(x => x.Id == OrderToShow.CheckoutId);

		//	GetCheckout.CartItems = new List<CartItem>();

		//	List<Cart> CartList = Context.ShoppingCarts.ToList();
		//	Cart LastCart = CartList.Last();
		//	OrderToShow.OrderTotal = LastCart.TotalPrice;

		//	List<CartItem> GetCartItems = Context.CartItems.Where(x => x.ShoppingCartId == 0).ToList();

		//	foreach (CartItem item in GetCartItems)
		//	{
		//		Product Prod = Context.Products.FirstOrDefault(x => x.Id == item.ProductId);
		//		item.Product = Prod;
		//	}

		//	GetCheckout.CartItems = GetCartItems;
		//	OrderToShow.Checkout = GetCheckout;


		//	return View(OrderToShow);
		//}
	}
}

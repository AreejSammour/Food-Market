
using Food_Market.Models.OrderModels;
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

		public Order Order1 = new Order
		{
			OrderId = 1,
			UserEmail = "Email1@hotmail.com",
			OrderTotal = 100,
			OrderStatus = "deliverd"
		};
		public Order Order2 = new Order
		{
			OrderId = 2,
			UserEmail = "Email2@hotmail.com",
			OrderTotal = 200,
			OrderStatus = "In Progress"
		};
		public Order Order3 = new Order
		{
			OrderId = 3,
			UserEmail = "Email3@hotmail.com",
			OrderTotal = 300,
			OrderStatus = "In Progress"
		};
		public IActionResult Index()
		{

			List<Order> MyOrders = new List<Order>();

			MyOrders.Add(Order1);
			MyOrders.Add(Order2);
			MyOrders.Add(Order3);
			return View(MyOrders);
		}

		public IActionResult Details(int Id)
		{
			OrderDetail OrderDetail1 = new OrderDetail();
			if (Id == 1)
			{
				OrderDetail1.OrderId = Id;
				OrderDetail1.UserInfo = Order1.UserEmail;
			}
			if (Id == 2)
			{
				OrderDetail1.OrderId = Id;
				OrderDetail1.UserInfo = Order2.UserEmail;
			}
			if (Id == 3)
			{
				OrderDetail1.OrderId = Id;
				OrderDetail1.UserInfo = Order3.UserEmail;
			}

			return View(OrderDetail1);
		}
	}
}

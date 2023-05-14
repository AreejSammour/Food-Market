using Food_Market.Models.ShoppingCart;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Food_Market.Models.OrderModels
{
	public class OrderDetail
	{
		public int Id { get; set; }
		public int CheckoutId { get; set; }
		public Checkout Checkout { get; set; }
		public int OrderId { get; set; }
		[Range(0.01, double.MaxValue)]
		[DataType(DataType.Currency)]
		[Column(TypeName = "decimal(18, 2)")]
		public decimal OrderTotal { get; set; }
		public DateTime PlacedDate { get; set; } = DateTime.Now;
		public string OrderStatus { get; set; }

	}
}

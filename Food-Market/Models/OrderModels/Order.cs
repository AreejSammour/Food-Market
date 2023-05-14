using System.ComponentModel.DataAnnotations;


namespace Food_Market.Models.OrderModels
{
	public class Order
	{
		public int OrderId { get; set; }
		public List<OrderDetail> OrderItems { get; set; }

	}
}

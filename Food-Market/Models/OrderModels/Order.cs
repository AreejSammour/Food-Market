using System.ComponentModel.DataAnnotations;

namespace Food_Market.Models.OrderModels
{
	public class Order
	{
		private string userEmail;

		public int OrderId { get; set; }
		[Required]
		public string UserEmail { get => userEmail; set => userEmail = value; }
		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public decimal OrderTotal { get; set; }
		public string OrderStatus { get; set; }
	}
}

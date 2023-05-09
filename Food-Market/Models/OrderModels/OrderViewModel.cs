namespace Food_Market.Models.OrderModels
{
	public class OrderViewModel
	{
		public int Id { get; set; }
		public string UserEmail { get; set; }
		public String Date { get; set; }
		public decimal Total { get; set; }
		public string status { get; set; }
	}
}

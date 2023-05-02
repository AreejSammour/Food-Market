namespace Ecommerce_assignment.Models
{
    public class CheckoutViewModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public decimal Subtotal { get; set; }
        public decimal ShippingRate { get; set; }
        public decimal Total { get; set; }

        public string Currency { get; set; }

        //public List<CartItemViewModel> CartItems { get; set; }
    }

}

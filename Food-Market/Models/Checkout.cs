namespace Ecommerce_assignment.Models
{
    public class Checkout
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string Cvc { get; set; }

        public void Validate()
        {
            // Validate user input for name, address, and card details
        }

        //public void ProcessOrder(List<Product> products)
        //{
        //    // Create a new Order object based on the user input and the products in the cart
        //}
    }

}

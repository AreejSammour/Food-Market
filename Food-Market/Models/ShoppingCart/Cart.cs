using System.ComponentModel.DataAnnotations;

namespace Food_Market.Models.ShoppingCart
{
    public class Cart
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        public HashSet<CartItem> Items { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
    }
    }


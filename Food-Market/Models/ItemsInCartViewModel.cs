using Food_Market.Models.ShoppingCart;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Food_Market.Models
{
    public class ItemsInCartViewModel
    {
        public HashSet<CartItem>? Items { get; set; }
        public int TotalItemsCount { get; set; }


        [Range(0.01, int.MaxValue)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Required]
        public decimal TotalPrice { get; set; }

        public string CurrencyMode { get; set; } // Krona or dollar
    }
}

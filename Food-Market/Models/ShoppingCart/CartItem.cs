using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Food_Market.Models.ShoppingCart
{
    public class CartItem
    {
        public int Id { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }  //Quantity of the same item

        [Required]
        public string Name { get; set; }  //Same as product name

        [Required]
        public int ProductId { get; set; }
        [Required]
        [MinLength(1)]
        public Product Product { get; set; }

        public int ShoppingCartId { get; set; }
        [Required]
        [MinLength(1)]
        public Cart Cart { get; set; }


        [Range(0.01, double.MaxValue)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Required]
        public decimal Price { get; set; }

        [Range(0.01, double.MaxValue)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Required]
        public decimal PriceTotal { get; set; }
    }
}

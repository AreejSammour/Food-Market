using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Food_Market.Models.ShoppingCart
{
    public class Cart
    {
        private ApplicationContext context;

        public Cart()
        {
            Items = new HashSet<CartItem>();
        }

        public Cart(ApplicationContext context)
        {
            this.context = context;
        }
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        public HashSet<CartItem> Items { get; set; }
        public int Count { get; set; }
		[Range(0.01, double.MaxValue)]
		[DataType(DataType.Currency)]
		[Column(TypeName = "decimal(18, 2)")]
		public decimal TotalPrice { get; set; }
    }
    }


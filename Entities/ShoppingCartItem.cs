using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace server.Entities
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ShoppingCart Cart { get; set; }
        public virtual Product Product { get; set; }

        public decimal TotalPriceAfterDiscount
        {
            get
            {
                return Product.NewPrice * Quantity;
            }
        }

        public decimal TotalDiscount
        {
            get
            {
                return (Product.OriginalPrice-Product.NewPrice) * Quantity;
            }
        }

        public decimal TotalPrice
        {
            get
            {
                return Product.OriginalPrice * Quantity;
            }
        }
    }
}

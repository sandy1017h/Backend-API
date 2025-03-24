using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Entities
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<ShoppingCartItem> Items { get; set; }

        public decimal TotalPriceAfterDiscount
        {
            get
            {
                // Sum the price of all items in the cart
                return Items.Sum(item => item.TotalPriceAfterDiscount);
            }
        }
        public decimal TotalDiscount
        {
            get
            {
                // Sum the price of all items in the cart
                return Items.Sum(item => item.TotalDiscount);
            }
        }
        public decimal TotalPrice
        {
            get
            {
                // Sum the price of all items in the cart
                return Items.Sum(item => item.TotalPrice);
            }
        }
        // Optional: A property to track the total number of items in the cart
        public int TotalItems
        {
            get
            {
                return Items.Sum(item => item.Quantity);
            }
        }
    }
}

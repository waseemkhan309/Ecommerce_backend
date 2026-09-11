
namespace Ecommerce_backend.Models
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set;  } = DateTime.Now;
        public int Subtotal { get; set; }
        public int TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public OrderStatus Status { get; set; } 

        public double ShippingFee { get; set; }

        public string ShippingAddress { get; set; } = string.Empty;

        public int BuyerId { get; set; }
        public Buyer Buyer { get; set; } = new Buyer();
    }

    public enum OrderStatus
    {
        Pending,
        Confirmed,
        Processing,
        Shipped,
        Delivered,
        Cancelled
    }
}

using EcommerceV1.Models;

namespace EcommerceV1.ViewModels
{
    public class CartItem
    {
        public Product product { get; set; }

        public int amount { get; set; }

        public double TotalMoney => amount * product.Price.Value;
    }
}

using EcommerceV1.Models;

namespace EcommerceV1.ViewModels
{
    public class ProductHomeVM
    {
        public Category category { get; set; }
        public List<Product> lsProducts { get; set; }   
    }
}

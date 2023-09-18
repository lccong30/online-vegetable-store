using EcommerceV1.Models;

namespace EcommerceV1.ViewModels
{
    public class HomeVM
    {
        public List<TinDang> TinTuc { get; set;}
        public List<ProductHomeVM> ProductHome { get; set;}
        public QuangCao QuangCao { get; set;}
    }
}
//public class ProductHomeVM
//{
//    public Category category { get; set; }
//    public List<Product> lsProducts { get; set; }
//}
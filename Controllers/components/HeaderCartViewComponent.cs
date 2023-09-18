using EcommerceV1.Extensions;
using EcommerceV1.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceV1.Controllers.components
{
    public class HeaderCartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            return View(cart);
        }
    }
}
 
using EcommerceV1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using EcommerceV1.Extensions;

namespace EcommerceV1.Controllers.components
{
    public class NumberCartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            return View(cart);
        }
    }
}

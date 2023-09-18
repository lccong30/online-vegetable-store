using Microsoft.AspNetCore.Mvc;

namespace EcommerceV1.Controllers
{
    public class AjaxContentController : Controller
    {
        public IActionResult HeaderCart()
        {
            return ViewComponent("HeaderCart");
        }

        public IActionResult HeaderFavourites()
        {
            return ViewComponent("NumberCart");
        }
    }
}

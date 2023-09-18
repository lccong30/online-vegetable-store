using EcommerceV1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceV1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SearchController : Controller
    {
        private readonly EcommerceV1Context _context;

        public SearchController(EcommerceV1Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        //GET: Search/FindProduct
        [HttpPost]
        public IActionResult FindProduct(string keyword)
        {
            List<Product> ls_product = new List<Product>();
            if (string.IsNullOrEmpty(keyword) || keyword.Length < 1)
            {
                return PartialView("ListProductSearchPartial", null);
            }
            ls_product = _context.Products.AsNoTracking().Include(a => a.Cat)
                                           .Where(x => x.ProductName.Contains(keyword))
                                           .OrderByDescending(x => x.ProductName)
                                           .Take(10)
                                           .ToList();

            if(ls_product == null)
            {
                return PartialView("ListProductSearchPartial", null);
            }
            else
            {
                return PartialView("ListProductSearchPartial", ls_product);
            }
        }
    }
}

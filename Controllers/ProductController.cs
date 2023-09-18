using AspNetCoreHero.ToastNotification.Abstractions;
using EcommerceV1.Helper;
using EcommerceV1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;

namespace EcommerceV1.Controllers
{
    public class ProductController : Controller
    {
        private readonly EcommerceV1Context _context;
        public INotyfService _notyfService { get; }

        public ProductController(EcommerceV1Context context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        [Route("shop.html", Name = "ShopProduct")]
        public IActionResult Index(int? page)
        {
            try
            {
                var pageNumber = page == null || page <= 0 ? 1 : page.Value;
                var pageSize = 10;
                var lsProduct = _context.Products.AsNoTracking().OrderByDescending(x => x.DateCreated);

                PagedList<Product> items = new PagedList<Product>(lsProduct, pageNumber, pageSize);
                ViewBag.CurrentPage = pageNumber;
                return View(items);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }

        }

        [Route("/danhmuc/{Alias}", Name = "ListProduct")]
        public IActionResult List(string Alias, int page = 1)
        {
            try
            {
                Console.WriteLine(Alias);
                var pageSize = 10;
                var categories = _context.Categories.AsNoTracking().SingleOrDefault(x => x.Alias == Alias);
                var lsProduct = _context.Products
                    .AsNoTracking()
                    .Where(x => x.CatId == categories!.CatId)
                    .OrderByDescending(x => x.DateCreated);
                PagedList<Product> models = new PagedList<Product>(lsProduct, page, pageSize);
                ViewBag.CurrentPage = page;
                ViewBag.CurrentCate = categories;
                return View(models);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }

        }

        [Route("/chi-tiet/{Alias}-{id}", Name = "ProductDetail")]
        public IActionResult Detail(int id)
        {

            try
            {
                var product = _context.Products.Include(p => p.Cat).FirstOrDefault(x => x.ProductId == id);

                var relateProducts = _context.Products.AsNoTracking()
                        
                        .Where(x => x.ProductId != id && x.CatId == product!.CatId && x.Active == true)
                        .OrderByDescending(x => x.DateCreated)
                        .Take(4)
                        .ToList();
                       

                if (product == null)
                {
                    return NotFound();
                }

                ViewBag.RelateProduct = relateProducts;

                return View(product);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }

        }
    }
}

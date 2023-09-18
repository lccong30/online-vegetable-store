using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using EcommerceV1.Models;
using EcommerceV1.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EcommerceV1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EcommerceV1Context _context;

        public HomeController(ILogger<HomeController> logger, EcommerceV1Context context)
        {
            _logger = logger;
            _context = context; 
        }

        public IActionResult Index()
        {
            HomeVM model = new HomeVM();
            
            var lsProducts = _context.Products
                .AsNoTracking()
                .Where(x => x.Active == true && x.HomeFlag == true)
                .OrderByDescending(x => x.DateCreated)
                .ToList();

            List<ProductHomeVM> lsProductViews = new List<ProductHomeVM>();

            var lsCates = _context.Categories
                .AsNoTracking()
                .Where(x => x.Published == true && x.ParentId == 0)
                .OrderByDescending(x => x.Ordering)
                .ToList();

            foreach(var item in lsCates)
            {
                ProductHomeVM productHome = new ProductHomeVM(); //lis_prd , cate; List_Prd_VM
                productHome.category = item;
                productHome.lsProducts = lsProducts.Where(x => x.CatId == item.CatId).ToList();
                lsProductViews.Add(productHome);
            }

            var quangCao = _context.QuangCaos
               .AsNoTracking()
               .FirstOrDefault(x => x.Active == true);

            var tinTuc = _context.TinDangs
                .AsNoTracking()
                .Where(x => x.Published == true && x.IsNewfeed == true)
                .OrderByDescending(x => x.CreatedDate)
                .Take(3)
                .ToList();

            model.ProductHome = lsProductViews;
            model.QuangCao = quangCao!;
            model.TinTuc = tinTuc;
            ViewBag.AllProducts = lsProducts;

            
            return View(model);
        }

        [Route("lien-he.html")]
        public IActionResult Contact()
        {
            return View();
        }

        [Route("gioi-thieu.html")]
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
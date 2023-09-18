using EcommerceV1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;

namespace EcommerceV1.Controllers
{
    public class PageController : Controller
    {
        private readonly EcommerceV1Context _context;

        public PageController(EcommerceV1Context context)
        {
            _context = context;
        }

        // GET: page/alias
        [Route("/page/{Alias}", Name = "PageDetail")]
        public IActionResult Details(string? Alias)
        {
            if(string.IsNullOrEmpty(Alias)) return RedirectToAction("Index","Home");

            var page = _context.Pages.AsNoTracking().SingleOrDefault(x => x.Alias == Alias);
            if (page == null)
            {
                return RedirectToAction("Index", "Home");
            }
           
            return View(page);
        }
    }
}

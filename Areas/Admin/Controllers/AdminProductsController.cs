using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using EcommerceV1.Models;
using EcommerceV1.Helper;

using AspNetCoreHero.ToastNotification.Abstractions;
using PagedList.Core;

namespace EcommerceV1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminProductsController : Controller
    {
        private readonly EcommerceV1Context _context;
        public INotyfService _notyfService { get; }

        public AdminProductsController(EcommerceV1Context context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: Admin/AdminProducts
        public IActionResult Index(int? page, int CatID = 0)
        {
            

            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 10;

            List<Product> lsProduct = new List<Product>();
            if(CatID != 0)
            {
               lsProduct = _context.Products
                            .AsNoTracking()
                            .Where(x => x.CatId ==  CatID)
                            .Include(p => p.Cat)
                            .OrderByDescending(x => x.DateCreated).ToList();
            }
            else
            {
                lsProduct = _context.Products
                           .AsNoTracking()
                           .Include(p => p.Cat)
                           .OrderByDescending(x => x.DateCreated).ToList();
            }
           


            PagedList<Product> models = new PagedList<Product>(lsProduct.AsQueryable(), pageNumber, pageSize);
            ViewBag.CurrentCateId = CatID;
            ViewBag.CurrentPage = pageNumber;
            ViewData["DanhMuc"] = new SelectList(_context.Categories, "CatId", "CatName");


            return View(models);
        }
        public IActionResult Filter(int CatID = 0)
        {
           var url = $"/Admin/AdminProducts?CatID={CatID}";
           if(CatID == 0)
            {
                url = "/Admin/AdminProducts";
            }
            return Json(new { status = "success", redirectUrl = url });
        }

        // GET: Admin/AdminProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Cat)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Admin/AdminProducts/Create
        public IActionResult Create()
        {
            ViewData["DanhMuc"] = new SelectList(_context.Categories, "CatId", "CatName");
            return View();
        }

        // POST: Admin/AdminProducts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,ShortDesc,Description,CatId,Price,Discount,Thumb,Video,DateCreated,DateModified,BestSellers,HomeFlag,Active,Tags,Title,Alias,MetaDesc,MetaKey,UnitsInStock")] Product product, Microsoft.AspNetCore.Http.IFormFile fThumb)
        {
            if (ModelState.IsValid)
            {
               
                product.ProductName = Utilities.ToTitleCase(product.ProductName);
                if(fThumb != null)
                {
                    string extension = Path.GetExtension(fThumb.FileName);
                    string image = Utilities.SEOUrl(product.ProductName) + extension;
                    product.Thumb = await Utilities.UploadFile(fThumb, @"products",image.ToLower());    
                }

                if (string.IsNullOrEmpty(product.Thumb)) product.Thumb = "default.jpg";
                if(product.UnitsInStock == 0) product.UnitsInStock = 0;
                product.Alias = Utilities.SEOUrl(product.ProductName);
                product.DateModified = DateTime.Now;

                if(!product.Price.HasValue) product.Price = 0;

                _context.Add(product);
                await _context.SaveChangesAsync();
                _notyfService.Success("Thêm thành công!");
                return RedirectToAction(nameof(Index));
            }
            ViewData["DanhMuc"] = new SelectList(_context.Categories, "CatId", "CatName", product.CatId);
            return View(product);
        }

        // GET: Admin/AdminProducts/Edit/5
        // View Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["DanhMuc"] = new SelectList(_context.Categories, "CatId", "CatName", product.CatId);
            return View(product);
        }

        // Edit Product
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,ShortDesc,Description,CatId,Price,Discount,Thumb,Video,DateCreated,DateModified,BestSellers,HomeFlag,Active,Tags,Title,Alias,MetaDesc,MetaKey,UnitsInStock")] Product product, Microsoft.AspNetCore.Http.IFormFile fThumb)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }
            int a = 1;

                Console.Write(a);

            //if (ModelState.IsValid)
            //{
                try
                {
                    Console.Write(fThumb);
                    product.ProductName = Utilities.ToTitleCase(product.ProductName);
                    if (fThumb != null && fThumb.Length > 0)
                    {
                        string extension = Path.GetExtension(fThumb.FileName);
                        string image = Utilities.SEOUrl(product.ProductName) + extension;
                        product.Thumb = await Utilities.UploadFile(fThumb, @"products", image.ToLower());
                    }
                  else if (string.IsNullOrEmpty(product.Thumb)) product.Thumb = "default.jpg";
                    product.Alias = Utilities.SEOUrl(product.ProductName);
                    product.DateModified = DateTime.Now;

                    _context.Update(product);
                    _notyfService.Success("Cập nhật thành công!");
                    await _context.SaveChangesAsync();
                  
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                    //if (!ProductExists(product.ProductId))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
                return RedirectToAction(nameof(Index));
            //}
            //ViewData["DanhMuc"] = new SelectList(_context.Categories, "CatId", "CatName", product.CatId);
            //return View(product);
        }

        // GET: Admin/AdminProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Cat)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/AdminProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'DbMarketsContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return (_context.Products?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}

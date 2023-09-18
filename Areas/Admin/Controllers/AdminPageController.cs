using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EcommerceV1.Models;
using EcommerceV1.Helper;

namespace EcommerceV1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminPageController : Controller
    {
        private readonly EcommerceV1Context _context;

        public AdminPageController(EcommerceV1Context context)
        {
            _context = context;
        }

        // GET: Admin/AdminPage
        public async Task<IActionResult> Index()
        {
              return _context.Pages != null ? 
                          View(await _context.Pages.ToListAsync()) :
                          Problem("Entity set 'EcommerceV1Context.Pages'  is null.");
        }

        // GET: Admin/AdminPage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pages == null)
            {
                return NotFound();
            }

            var page = await _context.Pages
                .FirstOrDefaultAsync(m => m.PageId == id);
            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }

        // GET: Admin/AdminPage/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminPage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PageId,PageName,Contents,Thumb,Published,Title,MetaDesc,MetaKey,Alias,CreatedDate,Ordering")] Page page, Microsoft.AspNetCore.Http.IFormFile fThumb)
        {
          
            if (ModelState.IsValid)
            {
                if(fThumb != null)
                {
                    string extension = Path.GetExtension(fThumb.FileName);
                    string imgName = Utilities.SEOUrl(page.PageName!) + extension;
                    page.Thumb = await Utilities.UploadFile(fThumb, @"pages",imgName);
                }
                if (fThumb == null) page.Thumb = "default.jpg";
                page.CreatedDate = DateTime.Now;
                page.Alias = Utilities.SEOUrl(page.Title);
                _context.Add(page);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(page);
        }

        // GET: Admin/AdminPage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pages == null)
            {
                return NotFound();
            }

            var page = await _context.Pages.FindAsync(id);
            if (page == null)
            {
                return NotFound();
            }
            return View(page);
        }

        // POST: Admin/AdminPage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PageId,PageName,Contents,Thumb,Published,Title,MetaDesc,MetaKey,Alias,CreatedDate,Ordering")] Page page, Microsoft.AspNetCore.Http.IFormFile fThumb)
        {
            if (id != page.PageId)
            {
                return NotFound();
            }
            
               try
                {
                if (fThumb != null)
                {
                    string extension = Path.GetExtension(fThumb.FileName);
                    string imgName = Utilities.SEOUrl(page.PageName!) + extension;
                    page.Thumb = await Utilities.UploadFile(fThumb, @"pages", imgName);
                }
              //  if (fThumb == null) page.Thumb = "default.jpg";
                _context.Update(page);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
            }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PageExists(page.PageId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        return View(page); 
                    }
            }
            //return View(page);
        }

        // GET: Admin/AdminPage/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pages == null)
            {
                return NotFound();
            }

            var page = await _context.Pages
                .FirstOrDefaultAsync(m => m.PageId == id);
            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }

        // POST: Admin/AdminPage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pages == null)
            {
                return Problem("Entity set 'EcommerceV1Context.Pages'  is null.");
            }
            var page = await _context.Pages.FindAsync(id);
            if (page != null)
            {
                _context.Pages.Remove(page);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PageExists(int id)
        {
          return (_context.Pages?.Any(e => e.PageId == id)).GetValueOrDefault();
        }
    }
}

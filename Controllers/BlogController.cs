﻿

using EcommerceV1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;

namespace EcommerceV1.Controllers
{
    public class BlogController : Controller
    {
        private readonly EcommerceV1Context _context;

        public BlogController(EcommerceV1Context context)
        {
            _context = context;
        }

        [Route("blogs.html", Name = ("Blog"))]
        public IActionResult Index(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 10;
            var lsTinDangs = _context.TinDangs
                .AsNoTracking()
                .OrderBy(x => x.PostId);
            PagedList<TinDang> models = new PagedList<TinDang>(lsTinDangs, pageNumber, pageSize);

            ViewBag.CurrentPage = pageNumber;
            return View(models);
        }

        [Route("/tin-tuc/{Alias}-{id}.html", Name = "TinChiTiet")]
        public IActionResult Details(int? id)
        {
            var tindang = _context.TinDangs.AsNoTracking().SingleOrDefault(x => x.PostId == id);
            if (tindang == null)
            {
                return RedirectToAction("Index");
            }
            var lsBaivietlienquan = _context.TinDangs
                .AsNoTracking()
                .Where(x => x.Published == true && x.PostId != id)
                .Take(3)
                .OrderByDescending(x => x.CreatedDate).ToList();
            ViewBag.Baivietlienquan = lsBaivietlienquan;
            return View(tindang);
        }


    }
}

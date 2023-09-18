using System;
using AspNetCoreHero.ToastNotification.Abstractions;

using EcommerceV1.Models;
using System.Collections.Generic;
using EcommerceV1.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EcommerceV1.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EcommerceV1.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly EcommerceV1Context _context;
        public INotyfService _notyfService { get; }

        public ShoppingCartController(EcommerceV1Context context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        public List<CartItem> GioHang
        {
            get
            {
                var gh = HttpContext.Session.Get<List<CartItem>>("GioHang");
                if (gh == default(List<CartItem>))
                {
                    gh = new List<CartItem>();
                }
                return gh;
            }
        }

        [HttpPost]
        [Route("api/cart/add")]
        public IActionResult AddToCart(int productId, int? amount)
        {
            List<CartItem> gioHang = GioHang;
            try
            {
                CartItem item = gioHang.SingleOrDefault(p => p.product.ProductId == productId);
                if (item != null)
                {
                    Console.WriteLine(item.amount);
                    item.amount = item.amount + amount.Value;
                    HttpContext.Session.Set<List<CartItem>>("GioHang", gioHang);
                    Console.WriteLine(item.amount);
                    Console.WriteLine(gioHang);
                }
                else
                {
                    Product newProduct = _context.Products.SingleOrDefault(p => p.ProductId == productId);
                    CartItem newItem = new CartItem
                    {
                        product = newProduct,
                        amount = amount.HasValue ? amount.Value : 1,
                    };
                    gioHang.Add(newItem);
                }

                Console.WriteLine(gioHang);

                HttpContext.Session.Set<List<CartItem>>("GioHang", gioHang);
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }

        }

        [HttpPost]
        [Route("api/cart/update")]
        public IActionResult Update(int productId, int? amount)
        {
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            try
            {
                if(cart != null)
                {
                    var item = cart.SingleOrDefault(p => p.product.ProductId == productId);
                    if (item != null)
                    {
                        item.amount = amount.Value; 
                    }
                    HttpContext.Session.Set<List<CartItem>>("GioHang", cart);
                }
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        [Route("api/cart/remove")]
        public IActionResult Remove(int productId)
        {
            try
            {
                List<CartItem> gioHang = GioHang;
                CartItem item = gioHang.SingleOrDefault(p => p.product.ProductId == productId);
                if (item != null)
                {
                    gioHang.Remove(item);
                }   
                HttpContext.Session.Set<List<CartItem>>("GioHang", gioHang);
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });

            }
        }

        [HttpGet]
        [Route("cart.html")]
        public IActionResult Index()
        {
            List<int> lsProductIds = new List<int>();
            var lsCarts = GioHang;
            foreach(var item in lsCarts) 
            { 
                lsProductIds.Add(item.product.ProductId);
            }
            List<Product> lsProducts = _context.Products
                .OrderByDescending(x => x.ProductId)
                .Where(x => !lsProductIds.Contains(x.ProductId) && x.BestSellers == true)
                .Take(6)
                .AsNoTracking()
                .ToList();

            ViewBag.lsSanPham = lsProducts;
            return View(GioHang);                                    
        }
    }
}

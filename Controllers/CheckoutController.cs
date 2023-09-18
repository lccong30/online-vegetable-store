using AspNetCoreHero.ToastNotification.Abstractions;
using EcommerceV1.Extensions;
using EcommerceV1.Helper;
using EcommerceV1.Models;
using EcommerceV1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EcommerceV1.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly EcommerceV1Context _context;
        public INotyfService _notyfService { get; }

        public CheckoutController(EcommerceV1Context context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        [Route("checkout.html", Name = "Checkout")]
        public IActionResult Index()
        {
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            var userId = HttpContext.Session.GetString("CustomerId");
            MuaHangVM model = new MuaHangVM();

            if (userId != null)
            {
                var customer = _context.Customers.AsNoTracking().SingleOrDefault(c =>
                    c.CustomerId == Convert.ToInt32(userId));

                model.CustomerId = customer!.CustomerId;
                model.FullName = customer.FullName!;
                model.Address = customer.Address!;
                model.Phone = customer.Phone!;
                model.Email = customer.Email!;
            }

            ViewData["lsTinhThanh"] = new SelectList(_context.Locations.Where(x => x.Levels == 1).OrderBy(x => x.Type).ToList(),"Location","Name");
            ViewBag.GioHang = cart;
            return View(model);
        }

        [HttpPost]
        [Route("checkout.html", Name = "Checkout")]
        public IActionResult Index(MuaHangVM muaHang)
        {
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            var taikhoanID = HttpContext.Session.GetString("CustomerId");
            MuaHangVM model = new MuaHangVM();
            if (taikhoanID != null)
            {
                var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.CustomerId == Convert.ToInt32(taikhoanID));
                Console.WriteLine(khachhang);
                Console.WriteLine(taikhoanID);
                model.CustomerId = khachhang.CustomerId;
                model.FullName = khachhang.FullName;
                model.Email = khachhang.Email;
                model.Phone = khachhang.Phone;
                model.Address = khachhang.Address;

                khachhang.LocationId = 1;
                khachhang.District = 2;
                khachhang.Ward = 3;
                khachhang.Address = "Ở đâu còn lâu mới nói!";
                Console.WriteLine(khachhang);
                _context.Customers.Update(khachhang);
                _context.SaveChanges();
            }
            try
            {
                Order order = new Order();
                order.CustomerId = model.CustomerId;
                order.Address = model.Address;
                order.LocationId = model.TinhThanh;
                order.District = model.QuanHuyen;
                order.Ward = model.PhuongXa;

                order.OrderDate = DateTime.Now;
                order.TransactStatusId = 1;
                order.Deleted = false;
                order.Paid = false;
                order.Note = Utilities.StripHTML(model.Note);
                order.TotalMoney = Convert.ToInt32(cart.Sum(x => x.TotalMoney));
                _context.Add(order);
                _context.SaveChanges();

                foreach(var item in cart)
                {
                    OrderDetail detail = new OrderDetail();
                    detail.ProductId = item.product.ProductId;
                    detail.OrderId = order.OrderId;
                    detail.Amount = item.amount;
                    detail.TotalMoney = order.TotalMoney;
                    detail.Price = item.product.Price;
                    detail.CreateDate= DateTime.Now;
                    _context.Add(detail);
                }
                _context.SaveChanges();
                HttpContext.Session.Remove("GioHang");
                _notyfService.Success("Đặt hàng thành công");
                return Redirect("order-success.html");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                ViewBag.GioHang = cart;
                return View(model);
            }
        }

        [HttpGet]
        [Route("order-success.html", Name ="OrderSuccess")]
        public IActionResult Success()
        {
            try
            {
                var taikhoanID = HttpContext.Session.GetString("CustomerId");
                if (string.IsNullOrEmpty(taikhoanID))
                {
                    return RedirectToAction("Login", "Accounts", new { returnUrl = "/dat-hang-thanh-cong.html" });
                }
                var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.CustomerId == Convert.ToInt32(taikhoanID));
                var donhang = _context.Orders
                    .Where(x => x.CustomerId == Convert.ToInt32(taikhoanID))
                    .OrderByDescending(x => x.OrderDate)
                    .FirstOrDefault();
                MuaHangSuccessVM successVM = new MuaHangSuccessVM();
                successVM.FullName = khachhang.FullName;
                successVM.DonHangID = donhang.OrderId;
                successVM.Phone = khachhang.Phone;
                successVM.Address = khachhang.Address;
                successVM.PhuongXa = GetNameLocation(donhang.Ward.Value);
                successVM.TinhThanh = GetNameLocation(donhang.District.Value);
                return View(successVM);
            }
            catch
            {
                return View();
            }
        }

        public string GetNameLocation(int idlocation)
        {
            try
            {
                var location = _context.Locations.AsNoTracking().SingleOrDefault(x => x.LocationId == idlocation);
                if (location != null)
                {
                    return location.NameWithType;
                }
            }
            catch
            {
                return string.Empty;
            }
            return string.Empty;
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Project_CarRental.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_CarRental.Utilities;
using System.ComponentModel.DataAnnotations.Schema;


namespace Project_CarRental.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductDetailController : Controller
	{
		private readonly DataContext _context;

		public ProductDetailController(DataContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
            var mnList = (from p in _context.ProductDetails
                          join m in _context.Products on p.ProductID equals m.ProductID
                          orderby p.ProductDetailID
                          select new ProductDetail
                          {
                              ProductDetailID = p.ProductDetailID,
                              ProductID = p.ProductID,
                              Images = p.Images,
                              Seats = p.Seats,
                              Mileage = p.Mileage,
                              Transmission = p.Transmission,
                              Color = p.Color,
                              Fuel = p.Fuel,
                              Description = p.Description,
                              OverTime = p.OverTime,
                              ExceedKm = p.ExceedKm,
                              OverNight = p.OverNight,
                              Holiday = p.Holiday,
                              LongRoad = p.LongRoad,
                              PricesHour = p.PricesHour,
                              PricesDay = p.PricesDay,
                              PricesMonth = p.PricesMonth,
                              IsActive = p.IsActive,
                              CarName = m.CarName
    }).ToList();

            return View(mnList);
        }

		public IActionResult Create()
		{
			var mnList = (from m in _context.Products
						  select new SelectListItem()
						  {
							  Text = m.CarName,
							  Value = m.ProductID.ToString(),
						  }).ToList();
			mnList.Insert(0, new SelectListItem()
			{
				Text = "---Select---",
				Value = string.Empty
			});
			ViewBag.mnList = mnList;
			return View();
		}
		[HttpPost]
		public IActionResult Create(ProductDetail productdetail)
		{
			if (ModelState.IsValid)
			{
				_context.Add(productdetail);
				_context.SaveChanges();
			}
			return RedirectToAction("Index");
		}

		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var mn = _context.ProductDetails.Find(id);
			if (mn == null)
			{
				return NotFound();
			}
			var mnList = (from m in _context.Products
						  select new SelectListItem()
						  {
							  Text = m.CarName,
							  Value = m.ProductID.ToString(),
						  }).ToList();
			mnList.Insert(0, new SelectListItem()
			{
				Text = "---Select---",
				Value = string.Empty
			});
			ViewBag.mnList = mnList;
			return View(mn);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(ProductDetail mn)
		{
			if (ModelState.IsValid)
			{
				_context.ProductDetails.Update(mn);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(mn);
		}

		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var mn = _context.ProductDetails.Find(id);
			if (mn == null)
			{
				return NotFound();
			}
			return View(mn);
		}
		[HttpPost]
		public IActionResult Delete(int id)
		{
			var deleProductDetail = _context.ProductDetails.Find(id);
			if (deleProductDetail == null)
			{
				return NotFound();
			}
			_context.ProductDetails.Remove(deleProductDetail);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}

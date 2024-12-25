using Microsoft.AspNetCore.Mvc;
using Project_CarRental.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_CarRental.Utilities;

namespace Project_CarRental.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly DataContext _context;

        public ProductController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var mnList = (from p in _context.Products
                          join m in _context.Menus on p.MenuID equals m.MenuID
                          orderby p.ProductID
                          select new Product
                          {
                              ProductID = p.ProductID,
                              CarName = p.CarName,
                              MenuID = p.MenuID,
                              Category = p.Category,
                              IsActive = p.IsActive,
                              MenuName = m.MenuName
                          }).ToList();

            return View(mnList);
        }

        public IActionResult Create()
        {
			var mnList = (from m in _context.Menus
						  where m.MenuName == "Xe 4 chỗ" || m.MenuName == "Xe 7 chỗ" || m.MenuName == "Xe 9 chỗ"
						  select new SelectListItem()
						  {
							  Text = m.MenuName,
							  Value = m.MenuID.ToString(),
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
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
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
            var mn = _context.Products.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
			var mnList = (from m in _context.Menus
						  where m.MenuName == "Xe 4 chỗ" || m.MenuName == "Xe 7 chỗ" || m.MenuName == "Xe 9 chỗ"
						  select new SelectListItem()
						  {
							  Text = m.MenuName,
							  Value = m.MenuID.ToString(),
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
        public IActionResult Edit(Product mn)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(mn);
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
            var mn = _context.Products.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            return View(mn);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var deleProduct = _context.Products.Find(id);
            if (deleProduct == null)
            {
                return NotFound();
            }
            _context.Products.Remove(deleProduct);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

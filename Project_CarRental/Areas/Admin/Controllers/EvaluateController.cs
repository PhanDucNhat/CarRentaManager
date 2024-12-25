using Microsoft.AspNetCore.Mvc;
using Project_CarRental.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_CarRental.Utilities;

namespace Project_CarRental.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class EvaluateController : Controller
	{
		private readonly DataContext _context;

		public EvaluateController(DataContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
            var mnList = (from p in _context.ViewEvaluates
                          join m in _context.Products on p.ProductID equals m.ProductID
                          orderby p.EvaluateID
                          select new ViewEvaluate
                          {
                              EvaluateID = p.EvaluateID,
                              ProductID = p.ProductID,
                              UserID = p.UserID,
                              Abstract = p.Abstract,
                              CreateDate = p.CreateDate,
                              IsActive = p.IsActive,
                              RangeStar = p.RangeStar,
                              FullName = p.FullName,
                              Avatar = p.Avatar,
                              CarName = m.CarName
                          }).ToList();

            return View(mnList);
        }

		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var mn = _context.Evaluates.Find(id);
			if (mn == null)
			{
				return NotFound();
			}
			return View(mn);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Evaluate mn)
		{
			if (ModelState.IsValid)
			{
				_context.Evaluates.Update(mn);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(mn);
		}
	}
}

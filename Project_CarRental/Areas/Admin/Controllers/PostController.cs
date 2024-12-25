using Microsoft.AspNetCore.Mvc;
using Project_CarRental.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_CarRental.Utilities;

namespace Project_CarRental.Areas.Admin.Controllers
{
	[Area("Admin")]	
	public class PostController : Controller
	{
		private readonly DataContext _context;

		public PostController(DataContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
            var mnList = (from p in _context.Posts
                          join m in _context.Menus on p.MenuID equals m.MenuID
                          orderby p.PostID
                          select new Post
                          {
                              PostID = p.PostID,
                              Title = p.Title,
                              Abstract = p.Abstract,
                              Contents = p.Contents,
                              Images = p.Images,
                              Author = p.Author,
                              CreateDate = p.CreateDate,
                              IsActive = p.IsActive,
                              MenuID = p.MenuID,
                              Category = p.Category,
                              MenuName = m.MenuName
                          }).ToList();

            return View(mnList);
        }

		public IActionResult Create()
		{
            var mnList = (from m in _context.Menus
                          where m.MenuName == "Địa điểm du lịch" || m.MenuName == "Những điều nên biết"
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
		public IActionResult Create(Post post)
		{
			if (ModelState.IsValid)
			{
				_context.Add(post);
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
			var mn = _context.Posts.Find(id);
			if (mn == null)
			{
				return NotFound();
			}
            var mnList = (from m in _context.Menus
                          where m.MenuName == "Địa điểm du lịch" || m.MenuName == "Những điều nên biết"
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
		public IActionResult Edit(Post mn)
		{
			if (ModelState.IsValid)
			{
				_context.Posts.Update(mn);
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
			var mn = _context.Posts.Find(id);
			if (mn == null)
			{
				return NotFound();
			}
			return View(mn);
		}
		[HttpPost]
		public IActionResult Delete(int id)
		{
			var delePost = _context.Posts.Find(id);
			if (delePost == null)
			{
				return NotFound();
			}
			_context.Posts.Remove(delePost);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}

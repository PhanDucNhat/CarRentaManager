using Project_CarRental.Models;
using Microsoft.AspNetCore.Mvc;


namespace Project_CarRental.Component
{
	[ViewComponent(Name = "PageAbout")]
	public class PageAboutComponent : ViewComponent
	{
		private readonly DataContext _context;
		public PageAboutComponent(DataContext context)
		{
			_context = context;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var listofAbout = (from p in _context.Abouts
							   where (p.IsActive == true)
							   orderby p.AboutID
							   select p).Take(2).ToList();

			return await Task.FromResult((IViewComponentResult)View("Default", listofAbout));
		}
	}
}

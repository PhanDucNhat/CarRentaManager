using Project_CarRental.Models;
using Microsoft.AspNetCore.Mvc;

namespace Project_CarRental.Component
{
	[ViewComponent(Name = "Footer")]
	public class FooterComponent : ViewComponent
	{
		private DataContext _context;
		public FooterComponent(DataContext context)
		{
			_context = context;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var listofFooter = (from m in _context.Footers
								where (m.IsActive == true)
								select m).Take(1).ToList();
			return await Task.FromResult((IViewComponentResult)View("Default", listofFooter));
		}
	}
}

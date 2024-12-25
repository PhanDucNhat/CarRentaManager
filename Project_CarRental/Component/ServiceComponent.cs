using Project_CarRental.Models;
using Microsoft.AspNetCore.Mvc;

namespace Project_CarRental.Component
{
	[ViewComponent(Name = "Service")]
	public class ServiceComponent : ViewComponent
	{
		private DataContext _context;
		public ServiceComponent(DataContext context)
		{
			_context = context;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var listofService = (from m in _context.Services
								 where (m.IsActive == true)
								 orderby m.ServiceID
								 select m).Take(4).ToList();
			return await Task.FromResult((IViewComponentResult)View("Default", listofService));
		}
	}
}

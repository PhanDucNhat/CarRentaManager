using Project_CarRental.Models;
using Microsoft.AspNetCore.Mvc;

namespace Project_CarRental.Component
{
	[ViewComponent(Name = "EvaluateProduct")]
	public class EvaluateProductComponent : ViewComponent
	{
		private DataContext _context;
		public EvaluateProductComponent(DataContext context)
		{
			_context = context;
		}
		public async Task<IViewComponentResult> InvokeAsync(int? id)
		{
			var listofEvaluateProduct = (from m in _context.ViewProducts
										 where (m.ProductID == id)
										 orderby m.ProductID descending
										 select m).ToList();
			return await Task.FromResult((IViewComponentResult)View("Default", listofEvaluateProduct));
		}
	}
}

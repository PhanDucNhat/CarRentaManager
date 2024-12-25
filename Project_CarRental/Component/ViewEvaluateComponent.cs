using Project_CarRental.Models;
using Microsoft.AspNetCore.Mvc;

namespace Project_CarRental.Component
{
    [ViewComponent(Name = "ViewEvaluate")]
    public class ViewEvaluateComponent : ViewComponent
    {
        private DataContext _context;
        public ViewEvaluateComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofViewEvaluate = (from m in _context.ViewEvaluates
                                      where (m.IsActive == true)
                                      orderby Guid.NewGuid()
                                      select m).Take(6).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofViewEvaluate));
        }
    }
}

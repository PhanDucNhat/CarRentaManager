using Project_CarRental.Models;
using Microsoft.AspNetCore.Mvc;

namespace Project_CarRental.Component
{
    [ViewComponent(Name = "Evaluate")]
    public class EvaluateComponent : ViewComponent
    {
        private DataContext _context;
        public EvaluateComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofEvaluate = (from m in _context.Evaluates
                                  where (m.IsActive == true)
                                  orderby m.EvaluateID descending
                                  select m).Take(5).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofEvaluate));
        }
    }
}

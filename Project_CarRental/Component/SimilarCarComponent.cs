using Project_CarRental.Models;
using Microsoft.AspNetCore.Mvc;

namespace Project_CarRental.Component
{
    [ViewComponent(Name = "SimilarCar")]
    public class SimilarCarComponent : ViewComponent
    {
        private DataContext _context;
        public SimilarCarComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofSimilar = (from m in _context.ViewProducts
                                 where (m.IsActive == true)
                                 orderby Guid.NewGuid()
                                 select m).Take(3).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofSimilar));
        }
    }
}

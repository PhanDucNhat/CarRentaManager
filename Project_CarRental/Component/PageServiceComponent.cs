using Project_CarRental.Models;
using Microsoft.AspNetCore.Mvc;

namespace Project_CarRental.Component
{
    [ViewComponent(Name = "PageService")]
    public class PageServiceComponent : ViewComponent
    {
        private DataContext _context;
        public PageServiceComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofService = (from m in _context.Services
                                 where (m.IsActive == true)
                                 orderby m.ServiceID
                                 select m).Take(5).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofService));
        }
    }
}

using Project_CarRental.Models;
using Microsoft.AspNetCore.Mvc;

namespace Project_CarRental.Component
{
    [ViewComponent(Name = "PageDiscoveryNews")]
    public class PageDiscoveryNewsComponent : ViewComponent
    {
        private DataContext _context;
        public PageDiscoveryNewsComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofPost2 = (from m in _context.Posts
                               where (m.IsActive == true) && (m.MenuID == 11)
                               orderby m.PostID descending
                               select m).Take(3).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofPost2));
        }
    }
}

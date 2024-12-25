using Project_CarRental.Models;
using Microsoft.AspNetCore.Mvc;

namespace Project_CarRental.Component
{
    [ViewComponent(Name = "PageTravelNews")]
    public class PageTravelNewsComponent : ViewComponent
    {
        private DataContext _context;
        public PageTravelNewsComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofTravel = (from m in _context.Posts
                               where (m.IsActive == true) && (m.MenuID == 10)
                               orderby m.PostID descending
                               select m).Take(3).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofTravel));
        }
    }
}

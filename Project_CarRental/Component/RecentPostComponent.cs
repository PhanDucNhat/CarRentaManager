using Microsoft.AspNetCore.Mvc;
using Project_CarRental.Models;

namespace Project_CarRental.Component
{
    [ViewComponent(Name = "RecentPost")]
    public class RecentPostComponent : ViewComponent
    {
        private DataContext _context;
        public RecentPostComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofPost = (from m in _context.Posts
                              where (m.IsActive == true)
                              orderby m.PostID
                              select m).Take(6).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofPost));
        }
    }
}

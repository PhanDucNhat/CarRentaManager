using Project_CarRental.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Project_CarRental.Component
{
    [ViewComponent(Name = "Post")]
    public class PostComponent : ViewComponent
    {
        private DataContext _context;
        public PostComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofPost = (from m in _context.Posts
                              where (m.IsActive == true)
                              orderby m.PostID
                              select m).Take(3).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofPost));
        }
    }
}

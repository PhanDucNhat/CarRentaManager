using Project_CarRental.Models;
using Microsoft.AspNetCore.Mvc;

namespace Project_CarRental.Component
{
    [ViewComponent(Name = "ViewComment")]
    public class ViewCommentComponent : ViewComponent
    {
        private DataContext _context;
        public ViewCommentComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int? id)
        {
            var listofViewComment = (from m in _context.ViewComments
                                     where (m.PostID == id) && (m.IsActive == true)
                                     orderby m.PostID descending
                                     select m).Take(3).ToList();

            return await Task.FromResult((IViewComponentResult)View("Default", listofViewComment));
        }
    }
}

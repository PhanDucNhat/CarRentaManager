using Project_CarRental.Models;
using Microsoft.AspNetCore.Mvc;

namespace Project_CarRental.Component
{
    [ViewComponent(Name = "About")]
    public class AboutComponent : ViewComponent
    {
        private DataContext _context;
        public AboutComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofAbout = (from m in _context.Abouts
                               where (m.IsActive == true)
                               orderby m.AboutID
                               select m).Take(1).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofAbout));
        }
    }
}

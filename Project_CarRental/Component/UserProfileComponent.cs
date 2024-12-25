using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_CarRental.Models;

namespace Project_CarRental.Component
{
    [ViewComponent(Name = "UserProfile")]
    public class UserProfileComponent : ViewComponent
    {
        private readonly DataContext _context;
        public UserProfileComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofUser = (from m in _context.Users
                               where (m.IsActive == true)
                               orderby m.UserID
                               select m).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofUser));
        }
    }
}

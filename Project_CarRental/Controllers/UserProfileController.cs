using Microsoft.AspNetCore.Mvc;
using Project_CarRental.Models;
using Project_CarRental.Utilities;

namespace Project_CarRental.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly DataContext _context;
        public UserProfileController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == Functions._Username);
            return View(user);
        }

        public IActionResult EditProfile()
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == Functions._Username);
            return View(user);
        }
        [HttpPost]
        public IActionResult UpdateProfile(User updatedUser)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == Functions._Username);
            if (user == null) return NotFound();

            user.FullName = updatedUser.FullName;
            user.Phone = updatedUser.Phone;
            user.Email = updatedUser.Email;
            user.Address = updatedUser.Address;

            _context.SaveChanges();

            TempData["SuccessMessage"] = "Cập nhật thông tin thành công!";
            return RedirectToAction("Index");
        }

		[HttpPost]
		public IActionResult ChangePassword(string currentPassword, string newPassword, string confirmPassword)
		{
			if (string.IsNullOrEmpty(currentPassword) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
			{
				TempData["ErrorMessage"] = "Vui lòng điền đầy đủ thông tin!";
				return RedirectToAction("Index");
			}

			var user = _context.Users.FirstOrDefault(u => u.Username == Functions._Username);
			if (user == null)
			{
				TempData["ErrorMessage"] = "Người dùng không tồn tại!";
				return RedirectToAction("Index");
			}

			if (Functions.MD5Password(currentPassword) != user.Password)
			{
				TempData["ErrorMessage"] = "Mật khẩu hiện tại không đúng!";
				return RedirectToAction("Index");
			}

			if (newPassword != confirmPassword)
			{
				TempData["ErrorMessage"] = "Mật khẩu mới và xác nhận không trùng khớp!";
				return RedirectToAction("Index");
			}

			user.Password = Functions.MD5Password(newPassword);
			_context.SaveChanges();

			TempData["SuccessMessage"] = "Thay đổi mật khẩu thành công!";
			return RedirectToAction("Index");
		}
	}
}

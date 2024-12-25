using Microsoft.AspNetCore.Mvc;
using Project_CarRental.Models;
using Project_CarRental.Utilities;
using System;
using System.Threading.Tasks;

namespace Project_CarRental.Controllers
{
	public class RentalController : Controller
	{
		private readonly DataContext _context;

		public RentalController(DataContext context)
		{
			_context = context;
		}

		// GET: /Rental/Index
		public IActionResult Index()
		{
			return View();
		}

		// POST: /Rental/BookCar
		[HttpPost]
		public async Task<IActionResult> BookCar(string pickup_location, string dropoff_location, DateTime pick_up_date, DateTime drop_off_date, string pick_up_time, int ProductID)
		{
			// Kiểm tra người dùng đã đăng nhập chưa
			if (string.IsNullOrEmpty(Functions._Username) || Functions._UserID == 0)
			{
				TempData["ErrorMessage"] = "Bạn cần đăng nhập để đặt xe.";
				return RedirectToAction("Index", "Login");
			}

			// Chuyển đổi pick_up_time từ string sang TimeSpan
			TimeSpan pickUpTimeParsed;
			try
			{
				pickUpTimeParsed = TimeSpan.Parse(pick_up_time);
			}
			catch
			{
				TempData["ErrorMessage"] = "Thời gian đón không hợp lệ.";
				return Redirect(Request.Headers["Referer"].ToString());
			}

			// Kiểm tra giá trị ngày
			if (pick_up_date == DateTime.MinValue || drop_off_date == DateTime.MinValue)
			{
				TempData["ErrorMessage"] = "Ngày không hợp lệ.";
				return Redirect(Request.Headers["Referer"].ToString());
			}

			// Kiểm tra ngày trả có trước ngày đón
			if (drop_off_date < pick_up_date)
			{
				TempData["ErrorMessage"] = "Ngày trả không thể trước ngày đón. Vui lòng nhập lại.";
				return Redirect(Request.Headers["Referer"].ToString());
			}

			// Tạo mới đối tượng Rental
			var rental = new Rental
			{
				UserID = Functions._UserID, // Lấy UserID từ thông tin đăng nhập
				ProductID = ProductID,     // Lấy ProductID từ form
				PickUpLocation = pickup_location,
				DropOffLocation = dropoff_location,
				PickUpDate = pick_up_date,
				DropOffDate = drop_off_date,
				PickUpTime = pickUpTimeParsed,
				Status = "Chờ xác nhận",
				IsActive = true
			};

			// Lưu rental vào cơ sở dữ liệu
			_context.Rentals.Add(rental);
			await _context.SaveChangesAsync();

			// Đặt thông báo trong TempData
			TempData["SuccessMessage"] = "Bạn đã đặt xe thành công, đang chờ xác nhận.";

			return RedirectToAction("Index", "Home");
		}

		public IActionResult History()
		{
			// Kiểm tra nếu người dùng chưa đăng nhập
			if (string.IsNullOrEmpty(Functions._Username) || Functions._UserID == 0)
			{
				TempData["ErrorMessage"] = "Bạn cần đăng nhập để xem lịch sử đặt xe.";
				return RedirectToAction("Index", "Login");
			}

			// Lấy danh sách các đơn đặt xe của người dùng từ cơ sở dữ liệu
			var rentalHistory = _context.Rentals
				.Where(r => r.UserID == Functions._UserID)
				.OrderByDescending(r => r.PickUpDate)
				.ToList();

			return View(rentalHistory);
		}
	}
}

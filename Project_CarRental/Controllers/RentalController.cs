using Microsoft.AspNetCore.Mvc;
using Project_CarRental.Models;
using Project_CarRental.Utilities;
using System;
using System.Threading.Tasks;
using SelectPdf;
using System.Diagnostics;

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

		[HttpPost]
		public async Task<IActionResult> BookCar(string pickup_location, string dropoff_location, DateTime pick_up_date, DateTime drop_off_date, string pick_up_time, int ProductID, decimal total_amount)
		{
			
			if (string.IsNullOrEmpty(Functions._Username) || Functions._UserID == 0)
			{
				TempData["ErrorMessage"] = "Bạn cần đăng nhập để đặt xe.";
				return RedirectToAction("Index", "Login");
			}

			
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

			
			if (pick_up_date == DateTime.MinValue || drop_off_date == DateTime.MinValue)
			{
				TempData["ErrorMessage"] = "Ngày không hợp lệ.";
				return Redirect(Request.Headers["Referer"].ToString());
			}

            
            if (pick_up_date.Date < DateTime.Now.Date)
            {
                TempData["ErrorMessage"] = "Ngày đón không thể trước ngày hiện tại. Vui lòng nhập lại.";
                return Redirect(Request.Headers["Referer"].ToString());
            }

            
            if (drop_off_date < pick_up_date)
			{
				TempData["ErrorMessage"] = "Ngày trả không thể trước ngày đón. Vui lòng nhập lại.";
				return Redirect(Request.Headers["Referer"].ToString());
			}

			
			var rental = new Rental
			{
				UserID = Functions._UserID,
				ProductID = ProductID,
				PickUpLocation = pickup_location,
				DropOffLocation = dropoff_location,
				PickUpDate = pick_up_date,
				DropOffDate = drop_off_date,
				PickUpTime = pickUpTimeParsed,
				Status = "Chờ xác nhận",
				IsActive = true,
				CreateDate = DateTime.Now,
				TotalAmount = total_amount
			};

			
			_context.Rentals.Add(rental);
			await _context.SaveChangesAsync();

			
			TempData["SuccessMessage"] = "Bạn đã đặt xe thành công, đang chờ xác nhận.";

			return RedirectToAction("History", "Rental");
		}

        public IActionResult History(DateTime? filterFromDate, DateTime? filterToDate, string filterStatus)
        {
            var query = from m in _context.Rentals
                        join n in _context.Products
                        on m.ProductID equals n.ProductID
                        where m.UserID == Functions._UserID
                        select new Rental
                        {
                            RentalID = m.RentalID,
                            UserID = m.UserID,
                            ProductID = m.ProductID,
                            PickUpLocation = m.PickUpLocation,
                            DropOffLocation = m.DropOffLocation,
                            PickUpDate = m.PickUpDate,
                            DropOffDate = m.DropOffDate,
                            PickUpTime = m.PickUpTime,
                            Status = m.Status,
                            IsActive = m.IsActive,
                            CarName = n.CarName,
                            CreateDate = m.CreateDate,
                            TotalAmount = m.TotalAmount
                        };

            if (filterFromDate.HasValue)
            {
                query = query.Where(r => r.CreateDate >= filterFromDate.Value);
            }
            if (filterToDate.HasValue)
            {
                var endDate = filterToDate.Value.AddDays(1).AddSeconds(-1);
                query = query.Where(r => r.CreateDate <= endDate);
            }

            if (!string.IsNullOrEmpty(filterStatus))
            {
                query = query.Where(r => r.Status == filterStatus);
            }

            var rentalHistory = query.ToList();
            return View(rentalHistory);
        }

        public IActionResult Contract(int id)
        {
            var rentalContract = (from m in _context.Rentals
                                  join n in _context.Products
                                  on m.ProductID equals n.ProductID
                                  join u in _context.Users
                                  on m.UserID equals u.UserID
                                  where m.RentalID == id
                                  select new Rental
                                  {
                                      RentalID = m.RentalID,
                                      UserID = m.UserID,
                                      ProductID = m.ProductID,
                                      PickUpLocation = m.PickUpLocation,
                                      DropOffLocation = m.DropOffLocation,
                                      PickUpDate = m.PickUpDate,
                                      DropOffDate = m.DropOffDate,
                                      PickUpTime = m.PickUpTime,
                                      Status = m.Status,
                                      IsActive = m.IsActive,
                                      CarName = n.CarName,
                                      CreateDate = m.CreateDate,
                                      TotalAmount = m.TotalAmount,
                                      FullName = u.FullName,
                                      Phone = u.Phone
                                  }).FirstOrDefault();

            if (rentalContract == null)
            {
                return NotFound();
            }

            return View(rentalContract);
        }
    }
}

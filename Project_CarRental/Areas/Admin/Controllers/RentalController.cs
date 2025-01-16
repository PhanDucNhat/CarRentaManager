using Microsoft.AspNetCore.Mvc;
using Project_CarRental.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_CarRental.Utilities;

namespace Project_CarRental.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RentalController : Controller
    {
        private readonly DataContext _context;

        public RentalController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login");
            var mnList = (from r in _context.Rentals
                          join p in _context.Products
                          on r.ProductID equals p.ProductID
                          join u in _context.Users
                          on r.UserID equals u.UserID
                          where r.Status == "Chờ xác nhận" || r.Status == "Đã xác nhận" || r.Status == "Đã hủy"
                          select new Rental
                          {
                              RentalID = r.RentalID,
                              UserID = r.UserID,
                              ProductID = r.ProductID,
                              PickUpLocation = r.PickUpLocation,
                              DropOffLocation = r.DropOffLocation,
                              PickUpDate = r.PickUpDate,
                              DropOffDate = r.DropOffDate,
                              PickUpTime = r.PickUpTime,
                              IsActive = r.IsActive,
                              CreateDate = r.CreateDate,
                              TotalAmount = r.TotalAmount,
                              Status = r.Status,
                              CarName = p.CarName,
                              FullName = u.FullName,
                              Phone = u.Phone,
                          }).OrderBy(m => m.RentalID).ToList();

            return View(mnList);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
			var mn = (from r in _context.Rentals
						  join p in _context.Products
						  on r.ProductID equals p.ProductID
						  join u in _context.Users
						  on r.UserID equals u.UserID
						  where r.RentalID == id
						  select new Rental
						  {
							  RentalID = r.RentalID,
							  UserID = r.UserID,
							  ProductID = r.ProductID,
							  PickUpLocation = r.PickUpLocation,
							  DropOffLocation = r.DropOffLocation,
							  PickUpDate = r.PickUpDate,
							  DropOffDate = r.DropOffDate,
							  PickUpTime = r.PickUpTime,
							  IsActive = r.IsActive,
                              CreateDate = r.CreateDate,
                              TotalAmount = r.TotalAmount,
							  Status = r.Status,
							  CarName = p.CarName,
							  FullName = u.FullName,
                              Phone = u.Phone
						  }).FirstOrDefault();
			if (mn == null)
            {
                return NotFound();
            }
            return View(mn);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int RentalID, string Status)
        {
            if (ModelState.IsValid)
            {
                var rental = _context.Rentals.FirstOrDefault(r => r.RentalID == RentalID);
                if (rental == null)
                {
                    return NotFound();
                }

                // Lưu trạng thái cũ để kiểm tra
                var oldStatus = rental.Status;

                // Cập nhật trạng thái mới cho đơn đặt xe
                rental.Status = Status;
                _context.Rentals.Update(rental);

                // Tìm xe tương ứng
                var product = _context.Products.FirstOrDefault(p => p.ProductID == rental.ProductID);
                if (product != null)
                {
                    // Kiểm tra các điều kiện chuyển trạng thái
                    if (Status == "Đã xác nhận" && oldStatus == "Chờ xác nhận")
                    {
                        // Chuyển trạng thái xe thành "Bận" khi xác nhận đặt xe
                        product.Status = "Bận";
                    }
                    else if (Status == "Hoàn thành" || Status == "Đã hủy")
                    {
                        // Chuyển trạng thái xe thành "Rảnh" khi đơn hàng hoàn thành hoặc bị hủy
                        product.Status = "Rảnh";
                    }

                    _context.Products.Update(product);
                }

                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult Detail(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = (from r in _context.Rentals
                      join p in _context.Products
                      on r.ProductID equals p.ProductID
                      join u in _context.Users
                      on r.UserID equals u.UserID
                      where r.RentalID == id
                      select new Rental
                      {
                          RentalID = r.RentalID,
                          UserID = r.UserID,
                          ProductID = r.ProductID,
                          PickUpLocation = r.PickUpLocation,
                          DropOffLocation = r.DropOffLocation,
                          PickUpDate = r.PickUpDate,
                          DropOffDate = r.DropOffDate,
                          PickUpTime = r.PickUpTime,
                          IsActive = r.IsActive,
                          TotalAmount = r.TotalAmount,
                          Status = r.Status,
                          CarName = p.CarName,
                          FullName = u.FullName,
                          Phone = u.Phone,
                          CreateDate = r.CreateDate
                      }).FirstOrDefault();
            if (mn == null)
            {
                return NotFound();
            }
            return View(mn);
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

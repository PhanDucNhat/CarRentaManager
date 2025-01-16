using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_CarRental.Models
{
    [Table("ViewProduct")]
    public class ViewProduct
    {
        [Key]
        public int ProductID { get; set; }
        public string? CarName { get; set; }
        public int MenuID { get; set; }
        public string? Status { get; set; }
        public int ProductDetailID { get; set; }
        public string? Images { get; set; }
        public int Seats { get; set; }
        public int Mileage { get; set; }
        public string? Transmission { get; set; }
        public string? Color { get; set; }
        public string? Fuel { get; set; }
        public string? Description { get; set; }
        public decimal? OverTime { get; set; }
        public decimal? ExceedKm { get; set; }
        public decimal? OverNight { get; set; }
        public decimal? Holiday { get; set; }
        public string? LongRoad { get; set; }
        public decimal? PricesHour { get; set; }
        public decimal? PricesDay { get; set; }
        public decimal? PricesMonth { get; set; }
        public bool? IsActive { get; set; }
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string? Avatar { get; set; }
        public int EvaluateID { get; set; }
        public string? Abstract { get; set; }
        public DateTime? CreateDate { get; set; }
        public int RangeStar { get; set; }
        public int Category {  get; set; }
    }
}

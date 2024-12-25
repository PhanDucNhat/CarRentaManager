using Microsoft.EntityFrameworkCore;
using Project_CarRental.Areas.Admin.Models;

namespace Project_CarRental.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<ViewProduct> ViewProducts { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Evaluate> Evaluates { get; set; }
        public DbSet<ViewEvaluate> ViewEvaluates { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ViewComment> ViewComments { get; set; }
        public DbSet<Footer> Footers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AdminMenu> AdminMenus { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
    }
}

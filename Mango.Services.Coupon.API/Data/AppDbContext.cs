using Mango.Services.Coupon.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.Coupon.API.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options) 
        {
            
        }
        public DbSet<Coupons> coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
             modelBuilder.Entity<Coupons>().HasData(new Coupons
             {
                 CounponId = 1,
                 CounponCode="100FF",
                 DiscountAmmount=10,
                 MinAmmount=20,
             });

            modelBuilder.Entity<Coupons>().HasData(new Coupons
            {
                CounponId = 2,
                CounponCode = "200FF",
                DiscountAmmount = 10,
                MinAmmount = 20,
            });
        }
    }
}

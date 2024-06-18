using CouponsV2.Models;
using Microsoft.EntityFrameworkCore;

namespace CouponsV2.Infrastructure.Data
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {
            
        }   
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<MarketplaceUser> MarketplaceUsers { get; set; }
        public DbSet<MarketingUser> MarketingUsers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

    }
}
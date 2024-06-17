using CouponsV2.Models;
using Microsoft.EntityFrameworkCore;

namespace CouponsV2.Data
{
    public class BaseContext(DbContextOptions<BaseContext> options) : DbContext(options)
    {
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<MarketplaceUser> MarketplaceUsers { get; set; }
        public DbSet<MarketingUser> MarketingUsers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }   
}
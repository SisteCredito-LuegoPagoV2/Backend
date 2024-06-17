using CouponsV2.Models;
using CouponsV2.Infrastructure.Data;
using CouponsV2.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CouponsV2.Application.Services.Repositories
{
    public class CouponsRepository : ICouponsRepository
    {   
        private readonly BaseContext _context;

        public CouponsRepository(BaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Coupon>> GetAllCouponsAsync()
        {
            return await _context.Coupons.ToListAsync();
        }

        public async Task<Coupon?> GetCouponByIdAsync(int id)
        {
            return await _context.Coupons.FirstOrDefaultAsync(c => c.id == id);
        }

        public async Task<Coupon> CreateCouponAsync(Coupon coupon)
        {
            _context.Coupons.Add(coupon);
            await _context.SaveChangesAsync();
            return coupon;
        }

        public async Task<Coupon> UpdateCouponAsync(Coupon coupon)
        {
            _context.Coupons.Update(coupon);
            await _context.SaveChangesAsync();
            return coupon;
        }

        public async Task<Coupon?> DeleteCouponAsync(int id)
        {
            var coupon = await _context.Coupons.FirstOrDefaultAsync(c => c.id == id);
            if (coupon != null)
            {
                coupon.status = "inactive";
                await _context.SaveChangesAsync();
            }
            return coupon;
        }

        public async Task<Coupon?> GetCouponsByCodeAsync(string code)
        {
            return await _context.Coupons.FirstOrDefaultAsync(c => c.code == code);
        }

        public async Task<Coupon?> RedemptionCouponAsync(string code)
        {
            var coupon = await _context.Coupons.FirstOrDefaultAsync(c => c.code == code);
            if (coupon != null)
            {
                coupon.status = "used";
                await _context.SaveChangesAsync();
            }
            return coupon;
        }
    }
}

using AutoMapper;
using CouponsV2.Dtos;
using CouponsV2.Models;
using CouponsV2.Infrastructure.Data;
using CouponsV2.Application.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace CouponsV2.Application.Services.Repositories
{
    public class CouponsRepository : ICouponsRepository
    {   
        private readonly BaseContext _context;
        private readonly IMapper _mapper;

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

        public async Task<Coupon> CreateCouponAsync(CouponsDTO couponDto)
        {
            Coupon coupon = new Coupon
            {
                // Map properties from CouponsDTO to Coupon
                id = couponDto.id,
                name = couponDto.name,
                description = couponDto.description,
                start_date = couponDto.start_date,
                end_date = couponDto.end_date,
                discount_type = couponDto.discount_type,
                discount_value = couponDto.discount_value,
                usage_limit = couponDto.usage_limit,
                min_purchase_amount = couponDto.min_purchase_amount,
                max_purchase_amount = couponDto.max_purchase_amount,
                status = couponDto.status,
                created_by = couponDto.created_by,
                code = couponDto.code,
                CreatedAt = couponDto.CreatedAt

            };

            _context.Coupons.Add(coupon);
            await _context.SaveChangesAsync();
            return coupon;

        }

        public async Task<Coupon> UpdateCouponAsync(int id ,CouponsDTO coupon)
        {
            var couponToUpdate = _context.Coupons.Find(id);
            _mapper.Map(coupon, couponToUpdate);
            _context.SaveChanges();
            return couponToUpdate;
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

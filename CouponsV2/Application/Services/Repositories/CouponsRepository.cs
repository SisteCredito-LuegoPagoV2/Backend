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

        public CouponsRepository(BaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Coupon>> GetAllCouponsAsync()
        {
            return await _context.Coupons.ToListAsync();
            // return await _context.Coupons.Include(c => c.MarketingUsers).ToListAsync();
        }

        public async Task<Coupon?> GetCouponByIdAsync(int id)
        {
            return await _context.Coupons.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Coupon> CreateCouponAsync(CouponsDTO coupon)
        {
            Coupon couponCreate = new Coupon
            {
                // Map properties from CouponsDTO to Coupon
                Id = coupon.Id,
                Name = coupon.Name,
                Description = coupon.Description,
                Code = coupon.Code,
                Start_Date = coupon.Start_Date,
                End_Date = coupon.End_Date,
                Discount_Type = coupon.Discount_Type,
                Discount_Value = coupon.Discount_Value,
                Usage_Limit = coupon.Usage_Limit,
                Min_Purchase_Amount = coupon.Min_Purchase_Amount,
                Max_Purchase_Amount = coupon.Max_Purchase_Amount,
                Status = coupon.Status,
                Created_By = coupon.Created_By,
                Created_At = coupon.Created_At,
                Uses = coupon.Uses
            };

            _context.Coupons.Add(couponCreate);
            await _context.SaveChangesAsync();
            return couponCreate;

        }

        public async Task<Coupon>? UpdateCouponAsync(int id ,CouponsDTO coupon)
        {
            var couponToUpdate = _context.Coupons.Find(id);
            _mapper.Map(coupon, couponToUpdate);
            _context.SaveChanges();
            return couponToUpdate;
        }

        public async Task<Coupon?> DeleteCouponAsync(int id)
        {
            var coupon = await _context.Coupons.FirstOrDefaultAsync(c => c.Id == id);
            if (coupon != null)
            {
                coupon.Status = "inactive";
                await _context.SaveChangesAsync();
            }
            return coupon;
        }

        public async Task<Coupon?> GetCouponsByCodeAsync(string code)
        {
            return await _context.Coupons.FirstOrDefaultAsync(c => c.Code == code);
        }

        public async Task<Coupon?> RedemptionCouponAsync(string code)
        {
            var coupon = await _context.Coupons.FirstOrDefaultAsync(c => c.Code == code);
            if (coupon != null)
            {
                coupon.Status = "used";
                await _context.SaveChangesAsync();
            }
            return coupon;
        }
    }
}

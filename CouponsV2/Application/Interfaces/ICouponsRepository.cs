using CouponsV2.Models;
using CouponsV2.Infrastructure.Data;
using CouponsV2.Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;


namespace CouponsV2.Application.Interfaces
{
    public interface ICouponsRepository
    {
         Task<IEnumerable<Coupon>> GetAllCouponsAsync();
         Task <Coupon> GetCouponByIdAsync(int id);
         Task<Coupon> CreateCouponAsync(Coupon coupon);
         Task<Coupon> UpdateCouponAsync(Coupon coupon);
         Task<Coupon> DeleteCouponAsync(int id);
         Task<Coupon> GetCouponsByCodeAsync(string code);
         Task<Coupon> RedemptionCouponAsync(string code);
    }
}




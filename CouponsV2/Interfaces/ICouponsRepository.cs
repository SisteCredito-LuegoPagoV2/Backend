using CouponsV2.Models;
using CouponsV2.Data;
using CouponsV2.Services;
using Microsoft.EntityFrameworkCore;


namespace CouponsV2.Repository
{
    public interface ICouponsRepository
    {
         Task<IEnumerable<Coupon>> GetAllCouponsAsync();
         Task <Coupon> GetCouponByIdAsync(int id);
         Task<Coupon> CreateCouponAsync(Coupon coupon);
         Task<Coupon> UpdateCouponAsync(Coupon coupon);
         Task<Coupon> DeleteCouponAsync(int id);
         Task<Coupon> GetCouponsByCodeAsync(int id);
         Task<Coupon> RedemptionCouponAsync(string code);
    }
}
using CouponsV2.Models;
using CouponsV2.Data;
using CouponsV2.Interfaces;
// using CouponsV2.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CouponsV2.Services
{
    public class CouponsRepository : ICouponsRepository
    {
        private readonly BaseContext _context;
        public CouponsRepository(CouponsRepository context)
        {
            _context = context;
        }

        public IEnumerable<Coupon> GetAllCouponsAsync()
        {
            return _context.Coupons.ToList();
        }
        public Coupon? GetCouponByIdAsync(int id)
        {
            return _context.Coupons.FirstOrDefault(c => c.id == id);
        }

        public Coupon? CreateCouponAsync(Coupon coupon)
        {
            _context.Coupons.Add(coupon);
            _context.SaveChanges();
            return coupon;
        }

        public Coupon? UpdateCouponAsync(Coupon coupon)
        {
            _context.Coupons.Update(coupon);
            _context.SaveChanges();
            return coupon;
        }

        public Coupon? DeleteCouponAsync(int id)
        {
            var coupon = _context.Coupons.FirstOrDefault(c => c.id == id);
            coupon.status = "inactive";
            _context.SaveChanges();
            return coupon;
        }

        public Coupon? GetCouponsByCodeAsync(string code)
        {
            return _context.Coupons.FirstOrDefault(c => c.code == code);
        }


    }
}
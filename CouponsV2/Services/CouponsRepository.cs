using CouponsV2.Models;
using CouponsV2.Data;
using CouponsV2.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CouponsV2.Repository;

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
    }
}
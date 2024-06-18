using CouponsV2.Application.Interfaces;
using CouponsV2.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CouponsV2.Application.Controllers.Coupons
{
    public class CouponsController : ControllerBase
    {
        private readonly ICouponsRepository _coupons;

        public CouponsController(ICouponsRepository coupons)
        {
            _coupons = coupons;
        }

        [HttpGet]
        [Route("api/coupons")]
        public async Task<IActionResult> GetAllCoupons()
        {
            var coupons = await _coupons.GetAllCouponsAsync();
            Console.WriteLine("...................");
            Console.WriteLine(coupons);
            return Ok(coupons);
        }

        [HttpGet]
        [Route("api/coupons/{id}")]
        public async Task<IActionResult> GetCouponById(int id)
        {
            var coupon = await _coupons.GetCouponByIdAsync(id);
            if (coupon == null)
            {
                return NotFound();
            }
            return Ok(coupon);
        }

    }
}
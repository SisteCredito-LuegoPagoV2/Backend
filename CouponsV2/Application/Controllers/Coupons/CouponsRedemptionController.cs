using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponsV2.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CouponsV2.Application.Controllers.Coupons
{
    public class CouponRedemptionController : ControllerBase
    {
        private readonly ICouponsRepository _coupons;

        public CouponRedemptionController(ICouponsRepository coupons)
        {
            _coupons = coupons;
        }


        [HttpPatch]
        [Route("api/coupons/{code}/redemption")]
        public async Task<IActionResult> RedemptionCoupon(string code)
        {
            var coupon = await _coupons.RedemptionCouponAsync(code);
            if (coupon != null)
            {
                return Ok(new { message = "This coupon was marked as used" });
            }
            else
            {
                return NotFound("Coupon not found");
            }
        }

    }
}
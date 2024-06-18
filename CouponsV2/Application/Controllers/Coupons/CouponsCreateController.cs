using CouponsV2.Dtos;
using CouponsV2.Models;
using Microsoft.AspNetCore.Mvc;
using CouponsV2.Application.Interfaces;

namespace CouponsV2.Application.Controllers.Coupons
{
    public class CouponsCreateController : ControllerBase
    {
        private readonly ICouponsRepository _coupons;

        public CouponsCreateController(ICouponsRepository coupons)
        {
            _coupons = coupons;
        }

        [HttpPost]
        [Route("api/coupons/create")]
        public async Task<IActionResult> CreateCoupon([FromBody] CouponsDTO couponDTO)
        {
            if (couponDTO == null)
            {
                return BadRequest("Invalid coupon data, nothing was entered(null).");
            }

            try
            {
                var createdCoupon = await _coupons.CreateCouponAsync(couponDTO);
                return CreatedAtAction(nameof(CreateCoupon), new { id = createdCoupon.Id }, createdCoupon);
            }
            catch (Exception ex)
            {
                // Log exception here
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

    }
}
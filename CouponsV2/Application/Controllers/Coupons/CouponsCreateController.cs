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
        public IActionResult CreateCoupon([FromBody]CouponsDTO coupon)
        {
            return Ok(_coupons.CreateCouponAsync(coupon));
        }
    }
}
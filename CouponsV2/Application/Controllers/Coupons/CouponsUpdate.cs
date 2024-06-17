using CouponsV2.Dtos;
using CouponsV2.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CouponsV2.Application.Interfaces;

namespace CouponsV2.Application.Controllers.Coupons
{
    public class CouponsUpdate : ControllerBase
    {
        private readonly ICouponsRepository _coupons;

        public CouponsUpdate(ICouponsRepository coupons)
        {
            _coupons = coupons;
        }

        [HttpPut]
        [Route("api/coupons/{id}/update")]
        public IActionResult UpdateCoupon([FromBody] int id , CouponsDTO coupon)
        {
            return Ok(_coupons.UpdateCouponAsync(id , coupon));
        }
    }
}
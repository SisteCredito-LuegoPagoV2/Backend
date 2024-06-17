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
        public IActionResult GetAllCoupons()
        {
            return Ok(_coupons.GetAllCouponsAsync());
        }

        [HttpGet]
        [Route("api/coupons/{id}")]
        public IActionResult GetCouponById(int id)
        {
            return Ok(_coupons.GetCouponByIdAsync(id));
        }
    }
}
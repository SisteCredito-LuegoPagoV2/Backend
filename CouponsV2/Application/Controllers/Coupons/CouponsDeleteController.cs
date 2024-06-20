using Microsoft.AspNetCore.Mvc;
using CouponsV2.Application.Services;
using CouponsV2.Application.Interfaces;

namespace CouponsV2.Application.Controllers.Coupons
{
    public class CouponsDelete : ControllerBase
    {
        private readonly ICouponsRepository _coupons;

        public CouponsDelete(ICouponsRepository coupons){
            _coupons = coupons;
        } 

        [HttpDelete]
        [Route("api/coupons/{id}/delete")]
        public IActionResult DeleteCoupon(int id)
        {
            return Ok(_coupons.DeleteCouponAsync(id));
        }
    }
}
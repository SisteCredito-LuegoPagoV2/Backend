using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CouponsV2.Models;
using CouponsV2.Application.Interfaces;
using CouponsV2.Application.Services;


namespace CouponsV2.Application.Controllers.Coupons
{
    public class CouponsController : ControllerBase
    {
        private readonly ICouponsRepository _coupons;        // private readonly ApiChecker _apiChecker;

        private bool _apiChecked = false;

        public CouponsController(ICouponsRepository coupons)
        {
            _coupons = coupons;
            // _apiChecker = apiChecker;
        }

        [HttpGet]
        [Route("api/coupons/list")]
         public async Task<IEnumerable<Coupon>> GetAllCoupons()
        {
            Webhook webhook = new Webhook();
            webhook.SendWebhook();
            // Verificar la API solo si no se ha verificado anteriormente
            // if (!_apiChecked)
            // {
            //     await _apiChecker.CheckApiAsync();
            //     _apiChecked = true;
            // }
            // Return the list of coupons
            return await _coupons.GetAllCouponsAsync();
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
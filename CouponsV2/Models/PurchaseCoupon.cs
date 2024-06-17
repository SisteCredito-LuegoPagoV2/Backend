using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CouponsV2.Models
{
    public class PurchaseCoupon
    {
        public int id {get;set;}

        [Required(ErrorMessage = "This field is necessary")]
        public int purchase_id {get;set;}

        [Required(ErrorMessage = "This field is necessary")]
        public int coupon_id {get;set;}

        //Relaciòn: PurchaseCoupon lists to Coupons -
        public Coupon? Coupons {get;set;}

        //Relaciòn: PurchaseCoupon lists to Purchases -
        public Purchase? Purchases {get;set;}
        

    }
}
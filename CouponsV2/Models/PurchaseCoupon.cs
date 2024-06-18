using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CouponsV2.Models
{
    public class PurchaseCoupon
    {
        public int Id {get;set;}

        [Required(ErrorMessage = "This field is necessary")]
        [ForeignKey("Purchases")]
        public int Purchase_Id {get;set;}

        [Required(ErrorMessage = "This field is necessary")]
        [ForeignKey("Coupons")]
        public int Coupon_Id {get;set;}

        // //Relaciòn: PurchaseCoupon lists to Coupons -
        // public Coupon? Coupons {get;set;}

        // //Relaciòn: PurchaseCoupon lists to Purchases -
        // public Purchase? Purchases {get;set;}
        

    }
}
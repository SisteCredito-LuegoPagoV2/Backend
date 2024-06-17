using System.ComponentModel.DataAnnotations;

namespace CouponsV2.Models
{
    public class CouponUsage
    {
        public int id {get; set; }
        [Required(ErrorMessage = "This field is necessary")]
        public int coupon_id {get; set; }
        [Required(ErrorMessage = "This field is necessary")]
        public int user_id {get; set; }
        [Required(ErrorMessage = "This field is necessary")]
        public DateTime usage_date {get; set; }
        [Required(ErrorMessage = "This field is necessary")]
        public int ? transaction_amount {get; set; }

        //Relaciòn: CouponUsages lists to MarketplaceUsers - 
        
        public MarketplaceUser? marketplaceUser {get; set; }

        //Relaciòn: CouponUsages lists to Coupons -
        public Coupon? Coupon {get; set; }

    }
}
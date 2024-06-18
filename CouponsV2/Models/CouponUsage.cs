using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CouponsV2.Models
{
    public class CouponUsage
    {
        public int Id {get; set; }
        [Required(ErrorMessage = "This field is necessary")]
        
        [ForeignKey("Coupons")]
        public int Coupon_Id {get; set; }
        [Required(ErrorMessage = "This field is necessary")]
        
        [ForeignKey("MarketplaceUsers")]
        public int User_Id {get; set; }
        [Required(ErrorMessage = "This field is necessary")]
        public DateOnly Usage_Date {get; set; }
        [Required(ErrorMessage = "This field is necessary")]

        public int ? Transaction_Amount {get; set; }

        //Relaciòn: CouponUsages lists to MarketplaceUsers - 
        
        // public MarketplaceUser? marketplaceUser {get; set; }

        // //Relaciòn: CouponUsages lists to Coupons -
        // public Coupon? Coupon {get; set; }

    }
}
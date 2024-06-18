using Microsoft.EntityFrameworkCore;
using CouponsV2.Infrastructure.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CouponsV2.Models
{
    public class CouponHistory
    {
        public int Id {get; set;}

        [Required(ErrorMessage = "This field is necessary")]
        [ForeignKey("Coupons")]
        public int Coupon_Id {get; set;}

        public DateOnly Change_Date {get; set;}
        public string ? Field_Changed {get; set;}
        public string ? Old_Value {get; set;}
        public string ? New_Value {get; set;}

        //Relaciòn: CouponHistory list to Coupons -
        // public Coupon? coupon {get;set;}
        

    }
}
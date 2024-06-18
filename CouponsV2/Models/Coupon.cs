using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using CouponsV2.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CouponsV2.Models
{
    public class Coupon
    {
        public int ? Id { get; set; }

        [Required(ErrorMessage = "This field is necessary")]
        public string ? Name { get; set; }

        [Required(ErrorMessage = "This field is necessary")]
        public string ? Description { get; set; }

        [Required(ErrorMessage = "This field is necessary")]
        public string? Code {get; set;}

        [Required(ErrorMessage = "This field is necessary")]
        public DateOnly ? Start_Date { get; set; }

        [Required(ErrorMessage = "This field is necessary")]
        public DateOnly ? End_Date { get; set; }

        [Required(ErrorMessage = "This field is necessary")]
        public string ? Discount_Type { get; set; }
        [Required(ErrorMessage = "This field is necessary")]

        public decimal ? Discount_Value { get; set; }
        [Required(ErrorMessage = "This field is necessary")]
        public int ? Usage_Limit {get; set;}
        [Required(ErrorMessage = "This field is necessary")]

        public decimal ? Min_Purchase_Amount {get; set; }
        [Required(ErrorMessage = "This field is necessary")]
        public decimal ? Max_Purchase_Amount {get; set; }
        [Required(ErrorMessage = "This field is necessary")]
        public string ? Status {get; set; }
   
        // public MarketingUser ? MarketingUsers {get;set;}

        [Required(ErrorMessage = "This field is necessary")]
        public DateOnly? Created_At {get; set;}

        [Required(ErrorMessage = "This field is necessary")]
        public int? Uses {get; set;}

        [Required(ErrorMessage = "This field is necessary")]
        [ForeignKey ("MarketingUsers")]
        public int? Created_By {get; set; }

        
        //Relaciòn: Coupon is listed by CouponUsage - 

        // [JsonIgnore]
        // public List<CouponUsage>? CouponUsages {get;set;}

        // //Relaciòn: Coupon is listed by PurchaseCoupon - 
        // [JsonIgnore]
        // public List<PurchaseCoupon>? PurchaseCoupons {get;set;}

        // //Relaciòn: Coupon is listed by CouponHistory -

        // [JsonIgnore]
        // public List<CouponHistory>? CouponHistories {get;set;}

        //Relaciòn: Coupon lists to MarketingUser - 

        //public MarketingUser? MarketingUsers {get;set;}

    }
}
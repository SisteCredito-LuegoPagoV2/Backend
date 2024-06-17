using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CouponsV2.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CouponsV2.Models
{
    public class Coupon
    {
        public int ? id { get; set; }

        [Required(ErrorMessage = "This field is necessary")]
        public string ? name { get; set; }

        [Required(ErrorMessage = "This field is necessary")]
        public string ? description { get; set; }

        [Required(ErrorMessage = "This field is necessary")]
        public DateOnly ? start_date { get; set; }

        [Required(ErrorMessage = "This field is necessary")]
        public DateOnly ? end_date { get; set; }

        [Required(ErrorMessage = "This field is necessary")]
        public string ? discount_type { get; set; }
        [Required(ErrorMessage = "This field is necessary")]

        public string ? discount_value { get; set; }
        [Required(ErrorMessage = "This field is necessary")]
        public int ? usage_limit {get; set;}
        [Required(ErrorMessage = "This field is necessary")]

        public decimal ? min_purchase_amount {get; set; }
        [Required(ErrorMessage = "This field is necessary")]
        public decimal ? max_purchase_amount {get; set; }
        [Required(ErrorMessage = "This field is necessary")]
        public string ? status {get; set; }
        [Required(ErrorMessage = "This field is necessary")]
        public int? created_by {get; set; }
        [Required(ErrorMessage = "This field is necessary")]
        public string? code {get; set;}
        [Required(ErrorMessage = "This field is necessary")]
        public DateOnly? CreatedAt {get; set;}
        
        //Relaciòn: Coupon is listed by CouponUsage - 

        [JsonIgnore]
        public ICollection<CouponUsage>? CouponUsages {get;set;}

        //Relaciòn: Coupon is listed by PurchaseCoupon - 
        [JsonIgnore]
        public ICollection<PurchaseCoupon>? PurchaseCoupons {get;set;}

        //Relaciòn: Coupon is listed by CouponHistory -

        [JsonIgnore]
        public ICollection<CouponHistory>? CouponHistories {get;set;}

        //Relaciòn: Coupon lists to MarketingUser - 

        public MarketingUser? MarketingUsers {get;set;}

    }
}
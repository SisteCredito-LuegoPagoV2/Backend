namespace CouponsV2.Models
{
    public class CouponUsage
    {
        public int id {get; set; }
        public int coupon_id {get; set; }
        public int user_id {get; set; }
        public DateTime usage_date {get; set; }
        public int ? transaction_amount {get; set; }
    }
}
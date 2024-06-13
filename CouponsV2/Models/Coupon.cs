using CouponsV2.Data;
using Microsoft.EntityFrameworkCore;

namespace CouponsV2.Models
{
    public class Coupon
    {
        public int ? id { get; set; }
        public string ? name { get; set; }
        public string ? description { get; set; }
        public DateTime ? start_date { get; set; }
        public DateTime ? end_date { get; set; }
        public string ? discount_type { get; set; }
        public string ? discount_value { get; set; }
        public int ? usage_limit {get; set;}
        public decimal ? min_purchase_amount {get; set; }
        public decimal ? max_purchase_amount {get; set; }
        public string ? status {get; set; }
        public int? created_by {get; set; }

    }
}
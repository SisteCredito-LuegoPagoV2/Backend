using Microsoft.EntityFrameworkCore;
using CouponsV2.Infrastructure.Data;

namespace CouponsV2.Models
{
    public class CouponHistory
    {
        public int id {get; set;}
        public int coupon_id {get; set;}
        public DateTime change_date {get; set;}
        public string ? field_changed {get; set;}
        public string ? old_value {get; set;}
        public string ? new_value {get; set;}
        

    }
}
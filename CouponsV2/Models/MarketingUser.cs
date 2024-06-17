using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CouponsV2.Models
{
    public class MarketingUser
    {
        public int id {get;set;}
        [Required(ErrorMessage = "This field is necessary")]
        public string ? username {get;set;}

        [Required(ErrorMessage = "This field is necessary")]
        public string ? password {get;set;}

        [Required(ErrorMessage = "This field is necessary")]
        public string ? email {get;set;}

        //Relaciòn : MarketingUser is listed by Coupon -

        [JsonIgnore]
        public ICollection<Coupon>? Coupons {get;set;}

        //Relaciòn : MarketingUser lists to UserRole -
        public UserRole? UserRoles {get;set;}

    }
}

